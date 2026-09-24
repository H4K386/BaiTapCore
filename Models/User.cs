namespace _0306241284_NguyenKhanhHuy.Models
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string FullName { get; set; } = string.Empty;
        public bool isAdmin { get; set; } = false;
    }
}
