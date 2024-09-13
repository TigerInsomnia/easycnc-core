using easycnc_core.Areas.System.Models;
using easycnc_core.Areas.System.Request;
using easycnc_core.Areas.System.Interface;

using easycnc_core.Data;
using Microsoft.EntityFrameworkCore;

namespace easycnc_core.Areas.System.Service
{
    public class UserService : IUserService
    {
        private readonly AppDbContext _dbContext;
        private readonly IDeptService _deptService;
        public UserService(AppDbContext dbContext, IDeptService deptService)
        {
            _dbContext = dbContext;
            _deptService = deptService;
        }

        /// <summary>
        /// 查询员工列表
        /// </summary>
        /// <param name="userRequest"></param>
        /// <returns>分页Page</returns>
        public Page<User> FindAll(UserRequest userRequest)
        {
            var query = _dbContext.Users.AsQueryable();

            if (!string.IsNullOrEmpty(userRequest.Username))
            {
                query = query.Where(u => u.Username == userRequest.Username);
            }

            if (userRequest.DeptId != 0 && userRequest.DeptId != 9999)
            {
                var deptIdList = _deptService.GetDownDeptIds(userRequest.DeptId);
                query = query.Where(u => deptIdList.Contains(u.DeptId));
            }


            query = query.Include(u => u.Address);
            query = query.Include(u => u.Dept);

            var total = query.Count();
            var content = query.Skip(userRequest.Start).Take(userRequest.Limit).ToList();

            return new Page<User>(total, content);
        }

        /// <summary>
        /// 根据用户名查找用户权限
        /// </summary>
        /// <param name="username">用户名</param>
        /// <returns>用户权限集合</returns>
        public List<Permission> FindPermissionsByUsername(string username)
        {
            return _dbContext.Users.Where(u => u.Username == username)
                .SelectMany(u=>u.Roles.SelectMany(r=>r.Permissions)).ToList();
            
        }

        public List<Role> FindRolesByUsername(string username)
        {
            return _dbContext.Users.Where(u => u.Username == username)
                .SelectMany(u=>u.Roles).ToList();
        }
    }
}
