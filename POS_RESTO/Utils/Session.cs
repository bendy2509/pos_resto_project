namespace POS_RESTO.Utils
{
    public static class Session
    {
        public static int UserId { get; set; }
        public static string Username { get; set; }
        public static string Role { get; set; } // "admin", "staff", "user"
        
        public static void Clear()
        {
            UserId = 0;
            Username = string.Empty;
            Role = string.Empty;
        }
        
        public static bool IsAdmin => Role == "admin";
        public static bool IsStaff => Role == "staff" || Role == "admin";
        public static bool IsLoggedIn => UserId > 0;
    }
}