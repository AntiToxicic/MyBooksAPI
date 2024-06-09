namespace MyBooksAPI.DTOs;

public class UserDto
{
    public string UserName { get; set; }
    
    public string Password { get; set; }
    
    public string? Name { get; set; }
    
    public string? SurName { get; set; }
}