namespace ClinicAPI.Models
{
    public class Doctor
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public DateTime DateOfJoin { get; set; }
        public string Specialization { get; set; }
        public int Experience { get; set; }
        public string Designation { get; set; }
    }
}
