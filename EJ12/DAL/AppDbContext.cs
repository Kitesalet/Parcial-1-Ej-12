using EJ12.Models;
using Microsoft.EntityFrameworkCore;

namespace EJ12.DAL
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {



        }

        public DbSet<Empleado> Empleados { get; set; }


    }
}
