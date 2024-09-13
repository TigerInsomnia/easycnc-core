using easycnc_core.Areas.System.Interface;
using easycnc_core.Areas.System.Models;
using easycnc_core.Data;

namespace easycnc_core.Areas.System.Service
{
    public class PermissionService : IPermissionService
    {
        private readonly AppDbContext appDbContext;
        public PermissionService(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }


        public List<Permission>? FindByUsername(string username)
        {
            
            var result=appDbContext.Permissions.Where(p=>p.Roles.Any(r=>r.Users.Any(u=>u.Username==username))).ToList();
            return result;
            
            
        }
    }
}
