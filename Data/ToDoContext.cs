using System.ComponentModel.DataAnnotations;

namespace BlueStone_Admin.Data
{
    public class ToDoContext
{
        [Key] public string? EmailId { get; set; }
        public string Description { get; set; } = "";
        public DateTime Deadline { get; set; } = DateTime.UtcNow;
        public bool IsCompleted { get; set; }

    }
}
