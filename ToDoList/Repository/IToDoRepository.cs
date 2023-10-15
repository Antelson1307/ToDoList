using ToDoList.Models;
using ToDoList.Models.ViewModel;

namespace ToDoList.Repository
{
    public interface IToDoRepository
    {
        List<ToDoVM> GetToDoListForGrid();
        List<ToDo> GetToDoList();
        ToDo GetToDoById(int id);
        bool SaveToDo(ToDo obj);
        bool UpdateToDo(ToDo obj);
    }
}
