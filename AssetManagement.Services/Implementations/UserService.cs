using System;
using System.Collections.Generic;
using System.Text;

using AssetManagement.Models.DTOs;
using AssetManagement.Repositories.Interfaces;
using AssetManagement.Services.Interfaces;

namespace AssetManagement.Services.Implementations;
public class UserService: IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public LoginResponseDto Login(LoginRequestDto request)
    {
        var user = _userRepository.GetUserByUsername(request.Username);

        if (user == null || user.Password != request.Password)
        {
            throw new Exception("Invalid username or password");
        }

        return new LoginResponseDto
        {
            UserId = user.Id,
            Username = user.Username,
            Role = user.Role
        };
    }
}
