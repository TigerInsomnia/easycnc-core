using easycnc_core.Areas.System.Models;

namespace easycnc_core.Areas.System.Interface
{
    public interface IRoleService
    {
        List<Role>? FindByUsername(string username);
    }
}
