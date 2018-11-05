using System.Data.Entity;

namespace DALayer.Model
{
    public class SalesContext : DbContext
    {
        public SalesContext() : base("name=SalesConnectionString")
        {
           //Database.SetInitializer();
        }

        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
    }
}