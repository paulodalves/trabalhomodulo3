using Microsoft.EntityFrameworkCore;

namespace AgenciaViagemDC.Models
{
    public class ContextoGeral : DbContext // Representa o nosso banco
    {
        public ContextoGeral(DbContextOptions options) :
            base(options)
        { }

        // Representa as tabelas do banco no contexto
        public DbSet<Cliente> Cliente { get; set; }

        public DbSet<Destino> Destino { get; set; }

        public DbSet<Viaja> Viaja { get; set; }
    }
}
