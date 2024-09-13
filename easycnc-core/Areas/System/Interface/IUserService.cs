using easycnc_core.Areas.System.Models;
using easycnc_core.Areas.System.Request;
using easycnc_core.Areas.System.Models;
using easycnc_core.Data;


namespace easycnc_core.Areas.System.Interface
{
    public interface IUserService
    {
        Page<User> FindAll(UserRequest userRequest);
        List<Role> FindRolesByUsername(string username);
        List<Permission> FindPermissionsByUsername(string username);
    }
}
