using easycnc_core.Areas.System.Models;

namespace easycnc_core.Areas.System.Interface
{
    public interface IPermissionService
    {

        List<Permission>? FindByUsername(string username);
    }
}
