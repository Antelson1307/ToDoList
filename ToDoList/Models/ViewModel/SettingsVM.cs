namespace ToDoList.Models.ViewModel
{
    public class SettingsVM
    {
        public List<SettingObj> Settings { get; set; }=new List<SettingObj>();
        public ToDoType ToDoType { get; set; }
    }

    public class SettingObj
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
