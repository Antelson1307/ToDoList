namespace ToDoList.Models.ViewModel
{
    public class ToDoVM
    {
        public List<ToDoModel> ToDoList { get; set; }
    }

    public class ToDoModel: ToDo
    {
        public string ToDoTypeName { get; set; }
    }
}
