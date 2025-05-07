namespace Labb3Blazor
{
    public class User
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Email { get; set; }
        public bool IsAdmin { get; set; }
    }

}
