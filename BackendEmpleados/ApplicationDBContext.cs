using BackendEmpleados.Models;
using Microsoft.EntityFrameworkCore;

namespace BackendEmpleados
{
    public class ApplicationDBContext: DbContext
    {
        public DbSet<Empleados> Empleado { get; set; }
        public DbSet<Cargo> Cargos { get; set; }

        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {

        }
    }
}
