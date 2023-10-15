using Microsoft.AspNetCore.Mvc;
using ToDoList.Data;
using ToDoList.Models;
using ToDoList.Models.ViewModel;

namespace ToDoList.Controllers
{
    public class SettingsController : Controller
    {
        private readonly ApplicationDbContext _context;
        public SettingsController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            SettingsVM settingsVM = LoadData();
            
            return View(settingsVM);
        }
        [HttpPost]
        public IActionResult Index(SettingsVM toDo)
        {
            if (toDo.ToDoType.ToDoTypeId > 0)//edit
            {
                //var res = _context.ToDoType.Where(x => x.ToDoTypeId == toDo.ToDoType.ToDoTypeId).SingleOrDefault();
                _context.ToDoType.Update(toDo.ToDoType);
                _context.SaveChanges();
            }
            else if (_context.ToDoType.Where(x => x.Name == toDo.ToDoType.Name).SingleOrDefault() == null)
            {
                _context.ToDoType.Add(toDo.ToDoType);
                _context.SaveChanges();
            }
            //SettingsVM settingsVM = LoadData();
            return RedirectToAction("Index");
        }

        private SettingsVM LoadData()
        {
            SettingsVM settingsVM = new SettingsVM();
            List<SettingObj> Settings = new List<SettingObj>();
            foreach (var obj in _context.ToDoType.ToList())
            {
                Settings.Add(new SettingObj { Id = obj.ToDoTypeId, Name = obj.Name });
            }
            settingsVM.Settings = Settings;
            settingsVM.ToDoType = new ToDoType();
            return settingsVM;
        }

        [HttpDelete]
        public bool DeleteToDoType(int id)
        {
            var obj = _context.ToDoType.Where(x => x.ToDoTypeId == id).SingleOrDefault();
            var res=_context.ToDoType.Remove(obj);
            _context.SaveChanges();
            return true;
        }
    }
}
