using System.ComponentModel.DataAnnotations;

namespace ToDoList.Models
{
    public class ToDoType
    {
        [Key]
        public int ToDoTypeId { get; set; }
        public string Name { get; set; }
    }
}
