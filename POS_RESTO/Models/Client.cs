namespace POS_RESTO.Models
{
    public class Client
    {
        public int ClientId { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Gender { get; set; } // "M" ou "F"
        public string Phone { get; set; }
        public string Email { get; set; }
        public decimal DebtAmount { get; set; }
        
        public string FullName => $"{FirstName} {LastName}";
        public string GenderText => Gender == "M" ? "Masculin" : "Féminin";
    }
}