using ToDoList.Data;
using ToDoList.Models;
using ToDoList.Models.ViewModel;

namespace ToDoList.Repository
{
    public class ToDoRepository : IToDoRepository
    {
        private readonly ApplicationDbContext _context;
        public ToDoRepository(ApplicationDbContext context)
        {
            _context=context;
        }

        public ToDo GetToDoById(int id)
        {
            return _context.ToDo.Where(x => x.Id == id).SingleOrDefault();
        }

        public List<ToDo> GetToDoList()
        {
            return _context.ToDo.ToList();
        }

        public List<ToDoVM> GetToDoListForGrid()
        {
            throw new NotImplementedException();
        }

        public bool SaveToDo(ToDo obj)
        {
            _context.ToDo.Add(obj);
            _context.SaveChanges();
            return true;
        }

        public bool UpdateToDo(ToDo obj)
        {
            _context.ToDo.Update(obj);
            _context.SaveChanges();
            return true;
        }
    }
}
