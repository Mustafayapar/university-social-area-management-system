using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;


namespace DataAccessLayer.Concrete
{
    public class Context: DbContext
    {
        public Context():base(nameOrConnectionString: "MyConnection") 
        {  
        
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Student> Students { get; set; } 
        public DbSet<Staff> Staff { get; set; }
        public DbSet<Manager> Managers { get; set; }
        public DbSet<EventRegisteration> EventRegisterations { get; set; }
        public DbSet<Events> Eventss { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<CourseRegisteration> CourseRegisterations { get; set; }
        public DbSet<CourseMessage> CourseMessages { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<CommunityRegisteration> CommunityRegisterations { get; set; }
        public DbSet<CommunityMessage> CommunityMessages { get; set; }
        public DbSet<Community> Communities { get; set; }
        public DbSet<Announcement> Announcements { get; set; }

    }
}
