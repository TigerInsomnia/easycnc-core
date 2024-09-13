using easycnc_core.Areas.Auth.Interface;
using easycnc_core.Areas.System.Models;
using easycnc_core.Data;

namespace easycnc_core.Areas.Auth.Service
{
    public class AuthService : IAuthService
    {
        private readonly AppDbContext _dbContext;
        public AuthService(AppDbContext dbContext) { 
            _dbContext = dbContext;
        }


        public User? VerifyUser(string username, string password)
        {
            var user = _dbContext.Users.SingleOrDefault(u => u.Username == username);

            if (user != null)
            {
                if (BCrypt.Net.BCrypt.Verify(password, user.Password))
                {
                    return user;
                }
                else
                {
                    throw new Exception("密码不正确");
                }
            }
            return null;
        }
    }
}
