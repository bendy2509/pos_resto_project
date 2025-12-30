namespace POS_RESTO.Models
{
    public class Client
    {
        public int ClientId { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string FullName => $"{LastName} {FirstName}";
        public string Gender { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public decimal DebtAmount { get; set; }
    }
}