using Microsoft.EntityFrameworkCore;

namespace ASPNetCoreWebAPIDemo.Models
{
    public class EmpContext : DbContext
    {
        public EmpContext(DbContextOptions options) : base(options) { }
        DbSet<Employees>? Employees
        {
            get;
            set;
        }
    }
}
