using System;
using System.Collections.Generic;
using System.Text;

using AssetManagement.Models.DTOs;

namespace AssetManagement.Services.Interfaces;
public interface IUserService
{
    LoginResponseDto Login(LoginRequestDto request);
}
