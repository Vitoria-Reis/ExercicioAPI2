using Microsoft.EntityFrameworkCore;
using exercicio.Models;

namespace exercicio.Data
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            :base(options)
        {
        }

        public DbSet<Prestacao> Prestacao { get; set; }
        public DbSet<Contrato> Contrato { get; set; }
    }
}