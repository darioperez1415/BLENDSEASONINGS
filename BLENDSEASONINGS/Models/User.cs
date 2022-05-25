namespace BLENDSEASONINGS.Models
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string email { get; set; }

        public bool IsAdmin { get; set; }
    }
}
