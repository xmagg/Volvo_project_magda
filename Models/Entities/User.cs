namespace NewsPlatform2.Models.Entities
{
    public class User
    {
        public Guid Id { get; set; }
        public string Login { get; set; }

        public string Password { get; set; }
        public int Level { get; set; }  // 1-admin  2-advanced  3-regular
    }
}
