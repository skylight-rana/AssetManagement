using Microsoft.AspNetCore.Mvc;
using AssetManagement.Services.Interfaces;
using AssetManagement.Models.DTOs;

namespace AssetManagement.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AccountController : ControllerBase
{
    private readonly IUserService _userService;

    public AccountController(IUserService userService)
    {
        _userService = userService; 
    }

    [HttpPost("login")]
    public IActionResult Login([FromBody] LoginRequestDto request)
    {
        try
        {
            var response = _userService.Login(request);
            return Ok(response);
        } catch (Exception ex)
        {
            return Unauthorized(ex.Message);
        }
    }
}