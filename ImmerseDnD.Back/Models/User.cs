namespace ImmerseDnD.Back.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public List<int> Characters{ get; set; } = new List<int>(); //list of character ids
    }
}
