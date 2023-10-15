using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ToDoList.Data;
using ToDoList.Models;
using ToDoList.Models.ViewModel;
using ToDoList.Repository;

namespace ToDoList.Controllers
{
    public class ToDoController : Controller
    {
        private readonly IToDoRepository _repo;
        private readonly IToDoTypeRepository _typeRepo;
        public ToDoController(IToDoRepository repo, IToDoTypeRepository typeRepo)
        {
            _repo = repo;
            _typeRepo = typeRepo;

        }
        public IActionResult Index()
        {
            var res = _repo.GetToDoList();
            List<ToDoModel> list = new List<ToDoModel>();
            foreach (var item in res)
            {
                var typeName = _typeRepo.GetTypeById(item.ToDoType).Name;
                list.Add(new ToDoModel
                {
                    Description = item.Description,
                    From = item.From,
                    FromTime = item.FromTime,
                    Id = item.Id,
                    To = item.To,
                    ToDoType = item.ToDoType,
                    ToTime = item.ToTime,
                    ToDoTypeName = typeName
                });
            }
            ToDoVM vm = new ToDoVM();
            vm.ToDoList = list;
            return View(vm);
        }

        public IActionResult Create()
        {
            var selectList = _typeRepo.GetAllType();
            var selectItemToDoType = new List<SelectListItem>();
            foreach (var item in selectList)
            {
                selectItemToDoType.Add(new SelectListItem { Text = item.Name, Value = item.ToDoTypeId.ToString() });
            }
            ViewBag.SelectItemToDoType = selectItemToDoType;
            ToDo obj = new ToDo();
            return View(obj);
        }

        [HttpPost]
        public IActionResult Create(ToDo obj)
        {
            _repo.SaveToDo(obj);
            var selectList = _typeRepo.GetAllType();
            var selectItemToDoType = new List<SelectListItem>();
            foreach (var item in selectList)
            {
                selectItemToDoType.Add(new SelectListItem { Text = item.Name, Value = item.ToDoTypeId.ToString() });
            }
            ViewBag.SelectItemToDoType = selectItemToDoType;
            return View(obj);
        }

        public IActionResult Edit(int id)
        {
            var todoObj = _repo.GetToDoById(id);
            var selectList = _typeRepo.GetAllType();
            var selectItemToDoType = new List<SelectListItem>();
            foreach (var item in selectList)
            {
                if (todoObj.ToDoType == item.ToDoTypeId)
                {
                    selectItemToDoType.Add(new SelectListItem { Text = item.Name, Value = item.ToDoTypeId.ToString(), Selected = true });
                }
                else
                {
                    selectItemToDoType.Add(new SelectListItem { Text = item.Name, Value = item.ToDoTypeId.ToString() });
                }
            }
            ViewBag.SelectItemToDoType = selectItemToDoType;
            return View(todoObj);
        }

        [HttpPost]
        public IActionResult Edit(ToDo obj)
        {
            _repo.UpdateToDo(obj);
            return RedirectToAction("Index");
        }
    }
}
