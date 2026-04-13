using System;
using System.Collections.Generic;
using System.Text;

using AssetManagement.Models.Entities;

namespace AssetManagement.Repositories.Interfaces;

public interface IUserRepository
{
    User GetUserByUsername(string username);
    void AddUser(User user);
}
