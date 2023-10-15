using ToDoList.Models;

namespace ToDoList.Repository
{
    public interface IToDoTypeRepository
    {
        List<ToDoType> GetAllType();

        ToDoType GetTypeById(int id);
    }
}
