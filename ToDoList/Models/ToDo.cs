namespace ToDoList.Models
{
    public class ToDo
    {
        public int Id { get; set; }
        public int ToDoType { get; set; }
        public string Description { get; set; }
        public DateTime From { get; set; }
        public string FromTime { get; set; }
        public DateTime To { get; set; }
        public string ToTime { get; set; }
    }
}
