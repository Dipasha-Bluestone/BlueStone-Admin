using System;
using System.ComponentModel.DataAnnotations;

namespace Data
{
    public class HomeContext
    {

        public string? EmailId { get; set; }
        [Key] public DateTime Date { get; set; }
        [Required] public DateTime TimeIn { get; set; }
        public DateTime? TimeOut { get; set; }
        public string? Report { get; set; }
    }
}
