using easycnc_core.Models;

namespace easycnc_core.Areas.System.Interface;

public interface IDeptService
{
    Tree GetDeptTree();

    List<int> GetDownDeptIds(int deptId);
}