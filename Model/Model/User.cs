namespace Database.Model
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime RegisterDate { get; set; }
        public string Password { get; set; }
    }
}