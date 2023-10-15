using ToDoList.Data;
using ToDoList.Models;

namespace ToDoList.Repository
{
    public class ToDoTypeRepository : IToDoTypeRepository
    {
        private readonly ApplicationDbContext _context;
        public ToDoTypeRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public List<ToDoType> GetAllType()
        {
            return _context.ToDoType.ToList();  
        }

        public ToDoType GetTypeById(int id)
        {
            return _context.ToDoType.Where(x => x.ToDoTypeId == id).SingleOrDefault();
        }
    }
}
