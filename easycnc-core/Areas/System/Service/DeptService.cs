using easycnc_core.Areas.System.Interface;
using easycnc_core.Areas.System.Models;
using easycnc_core.Data;
using easycnc_core.Models;

namespace easycnc_core.Areas.System.Service;

public class DeptService : IDeptService
{
    private readonly AppDbContext _dbContext;

    public DeptService(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Tree GetDeptTree()
    {
        var deptList = _dbContext.Depts.ToList();
        var deptTree = new Tree();
        foreach (var dept in deptList)
        {
            if (dept.ParentId.Equals(9999))
            {
                var newTree = new Tree
                {
                    Id = dept.DeptId,
                    Name = dept.DeptName,
                    Pid = dept.ParentId
                };
                var children = GenDeptTree(deptList, dept.DeptId);
                if (children.Count > 0)
                {
                    newTree.Children = children;
                }
                else
                {
                    newTree.Leaf = true;
                }
                deptTree = newTree;
            }

        }
        return deptTree;

    }

    public List<Tree> GenDeptTree(List<Dept> deptList, int id)
    {
        var list = new List<Tree>();
        foreach (var dept in deptList)
        {
            var newTree = new Tree();
            if (dept.ParentId == id)
            {
                newTree.Id = dept.DeptId;
                newTree.Name = dept.DeptName;
                newTree.Pid = dept.ParentId;
                var children = GenDeptTree(deptList, dept.DeptId);
                if (children.Count > 0)
                {
                    newTree.Children = children;
                }
                else
                {
                    newTree.Leaf = true;
                }
                list.Add(newTree);
            }

        }

        return list;
    }

    public List<int> GetDownDeptIds(int deptId)
    {
        var deptList = _dbContext.Depts.ToList();
        var result = GenDownDeptIds(deptList, deptId);
        result.Add(deptId);
        return result;
    }

    public List<int> GenDownDeptIds(List<Dept> deptList, int deptId)
    {
        var list = new List<int>();
        foreach (var dept in deptList)
        {
            if (dept.ParentId == deptId)
            {
                list.Add(dept.DeptId);
                var children = GenDownDeptIds(deptList, dept.DeptId);
                list.AddRange(children);
            }

        }

        return list;
    }
}