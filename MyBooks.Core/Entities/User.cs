namespace MyBooks.Core.Entities;

public class User : EntityBase
{
    public User(string userName, string password)
    {
        UserName = userName;
        Password = password;
    }
    
    public string UserName { get; set; }
    
    public string Password { get; set; }
    
    public string? Name { get; set; }
    
    public string? SurName { get; set; }
    
    public List<Book> Books { get; set; }
}