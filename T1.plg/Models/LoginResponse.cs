namespace T1.plg.Models
{
    public class LoginResponse
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FatherName { get; set; }
        public string Phone { get; set; }
        public int RoleId { get; set; }
        public decimal Cash { get; set; }
        public string Token { get; set; }

        public int Status { get; set; }
        public string StatusMessage { get; set; }
    }

}
