namespace BlueStone_Admin.Data
{
    
    public class UserReport
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public DateTime? LoginTime { get; set; }
        public DateTime? LogoutTime { get; set; }
        public string? Text { get; set; }
    }

}
