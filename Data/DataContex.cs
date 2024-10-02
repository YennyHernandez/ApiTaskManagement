using Microsoft.EntityFrameworkCore;
using webApi.Models;

namespace webApi.Data
{
    public class DataContex : DbContext
    {
        public DataContex(DbContextOptions<DataContex>options):base(options)
        {
            
        }
        public DbSet<Tarea> Tareas { get; set; }
        public DbSet<State> States { get; set; }

    }
}