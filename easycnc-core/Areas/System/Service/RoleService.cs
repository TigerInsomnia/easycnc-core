using easycnc_core.Areas.System.Controllers;
using easycnc_core.Areas.System.Interface;
using easycnc_core.Areas.System.Models;
using easycnc_core.Data;

namespace easycnc_core.Areas.System.Service
{
    public class RoleService : IRoleService
    {
        private readonly AppDbContext dbContext;
        public RoleService(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public List<Role>? FindByUsername(string username)
        {
            
            return dbContext.Roles.Where(r => r.Users.Any(u => u.Username == username)).ToList();
           
           
            
        }
    }
}
