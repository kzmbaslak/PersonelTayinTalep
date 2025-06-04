using Core.Entities.Concrete;
using Core.Utilities.Results;
using Core.Utilities.Security.JWT;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IAuthService
    {
        IDataResult<User> Register(RegisterDto userForRegisterDto, string password);
        IDataResult<User> Login(LoginDto loginDto);
        IResult UserExists(string registryName);
        IDataResult<AccessToken> CreateAccessToken(User user);
    }
}
