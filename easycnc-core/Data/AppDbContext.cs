using easycnc_core.Areas.System.Models;
using easycnc_core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Cryptography.Xml;
using WorkflowCore.Persistence.EntityFramework.Models;

namespace easycnc_core.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options) { }



        public DbSet<User> Users { get; set; }
        public DbSet<Address> Address { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<RolePermission> RolePermissions { get; set; }
        public DbSet<Dept> Depts { get; set; }
        public DbSet<Post> Posts { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasMany(e => e.Roles).WithMany(e => e.Users).UsingEntity<UserRole>();
            modelBuilder.Entity<Role>().HasMany(e=>e.Permissions).WithMany(e => e.Roles).UsingEntity<RolePermission>();


            modelBuilder.Entity<Dept>().HasData(
                    new Dept {DeptId=1, DeptName = "张氏工厂", ParentId = 9999 },
                    new Dept { DeptId = 2, DeptName = "技术部", ParentId = 1 },
                    new Dept { DeptId = 3, DeptName = "销售部", ParentId = 1 },
                    new Dept { DeptId = 4, DeptName = "销售1部", ParentId = 3 },
                    new Dept { DeptId = 5, DeptName = "销售2部", ParentId = 3 }
            
                    );
            modelBuilder.Entity<Role>().HasData(
                    new Role { RoleId=1,RoleName="管理员",RoleCode="admin"},
                    new Role { RoleId = 2, RoleName = "用户", RoleCode = "user" }
                );
            modelBuilder.Entity<Permission>().HasData(
                    new Permission { PermissionId=1,PermissionCode="read",PermissionName="读"},
                    new Permission { PermissionId = 2, PermissionCode = "write", PermissionName = "写" }

                );
            modelBuilder.Entity<User>().HasData(
                    new User {UserId=1,Username="zhangsan",Password= "$2a$10$kPaZzYn4dB0oUHwwOQ6Uuuwg48GBcS/3TbCn/CVMzJD70t.hIBgiy",DeptId=2 ,AddressId=1},
                    new User { UserId = 2, Username = "lisi", Password = "$2a$10$kPaZzYn4dB0oUHwwOQ6Uuuwg48GBcS/3TbCn/CVMzJD70t.hIBgiy", DeptId = 3, AddressId = 2 },
                    new User { UserId = 3, Username = "wangwu", Password = "$2a$10$kPaZzYn4dB0oUHwwOQ6Uuuwg48GBcS/3TbCn/CVMzJD70t.hIBgiy", DeptId = 4, AddressId = 3 }
                );
            modelBuilder.Entity<UserRole>().HasData(
                    new UserRole { UserId=1,RoleId=1},
                    new UserRole { UserId = 1, RoleId = 2},
                    new UserRole { UserId=2,RoleId=1},
                    new UserRole { UserId=3,RoleId=2}
                );
            modelBuilder.Entity<RolePermission>().HasData(
                    new RolePermission {RoleId=1,PermissionId=1 },
                    new RolePermission { RoleId = 1, PermissionId = 2 },
                    new RolePermission { RoleId = 2, PermissionId = 1 }
                );

            modelBuilder.Entity<Address>().HasData(
                    new Address { AddressId=1,Province="浙江省",City="嘉兴市",County="嘉善县",Detail="罗星街道"},
                    new Address { AddressId = 2, Province = "浙江省", City = "嘉兴市", County = "嘉善县", Detail = "罗星街道" },
                    new Address { AddressId = 3, Province = "浙江省", City = "嘉兴市", County = "嘉善县", Detail = "罗星街道" }
                );
        }
    }


    
}
