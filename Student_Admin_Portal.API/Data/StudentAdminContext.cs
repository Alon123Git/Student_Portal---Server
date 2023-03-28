using Microsoft.EntityFrameworkCore;
using Student_Admin_Portal.API.Models;

namespace Student_Admin_Portal.API.Data
{
    public class StudentAdminContext : DbContext
    {
        public StudentAdminContext(DbContextOptions<StudentAdminContext> options) : base(options)
        {

        }
        
        public DbSet<Student> Student { get; set; }
        public DbSet<Gender> Gender { get; set; }
        public DbSet<Address> Address { get; set; }
    }
}