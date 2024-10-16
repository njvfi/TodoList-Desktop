using SQLite;

namespace TodoList_Maui.Models
{
    [Table("Goals")]
    public class Goals
    {
        [PrimaryKey, AutoIncrement, Column("Id")]
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public Category Category { get; set; }
        public bool Status { get; set; }
    }

    public enum Category
    {
        Work,
        Study,
        Sport,
        House,
        Other
    }
}