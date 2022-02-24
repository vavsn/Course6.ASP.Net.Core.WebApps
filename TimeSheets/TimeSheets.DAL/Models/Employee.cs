namespace TimeSheets.DAL.Models
{
    public class Employee : Person
    {
        public int Division { get; set; }
        public int Department{ get; set; }
    }
}
