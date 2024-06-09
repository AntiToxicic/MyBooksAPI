using Microsoft.AspNetCore.Mvc;
using MyBooks.Core.Entities;
using MyBooks.Core.Interfaces;
using MyBooksAPI.DTOs;

namespace MyBooksAPI.Controllers;

[ApiController]
[Route("api/users")]
public class UserController : ControllerBase
{
    private readonly IUserRepository _userRepository;

    public UserController(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    [HttpPost("register")]
    public async Task<IActionResult> PostUser([FromBody] UserDto userDto)
    {
        User user = new User(userDto.UserName, userDto.Password)
        {
            Name = userDto.Name,
            SurName = userDto.SurName
        };

        var createdUser = await _userRepository.Create(user);
        return Ok(createdUser);
    }

    [HttpPost("login")]
    public async Task<IActionResult> LoginUser([FromBody] LoginDto loginDto)
    {
        var user = await _userRepository.GetByUserName(loginDto.Username);
        if (user == null) return NotFound();
        if (user.Password != loginDto.Password) return Unauthorized();
        return Ok(user);
    }

    [HttpGet("{userId}")]
    public async Task<IActionResult> GetUser(uint userId)
    {
        var user = await _userRepository.Get(userId);
        if (user == null) return NotFound();
        return Ok(user);
    }

    [HttpPut("{userId}")]
    public async Task<IActionResult> UpdateUser(uint userId, [FromBody] UserDto userDto)
    {
        var existingUser = await _userRepository.Get(userId);
        if (existingUser == null) return NotFound();

        existingUser.Name = userDto.Name;
        existingUser.SurName = userDto.SurName;

        await _userRepository.Update(existingUser);
        return Ok();
    }

    [HttpPut("{userId}/password")]
    public async Task<IActionResult> UpdateUserPassword(uint userId, [FromBody] UserDtoPassword userDtoPassword)
    {
        var existingUser = await _userRepository.Get(userId);
        if (existingUser == null) return NotFound();

        if (existingUser.Password != userDtoPassword.OldPassword) return Unauthorized();
            
            existingUser.Password = userDtoPassword.NewPassword;

        await _userRepository.Update(existingUser);
        return Ok();
    }
    
    [HttpDelete("{userId}")]
    public async Task<IActionResult> DeleteUser(uint userId)
    {
        var existingUser = await _userRepository.Get(userId);
        if (existingUser == null) return NotFound();

        await _userRepository.Delete(existingUser);
        return Ok();
    }
}