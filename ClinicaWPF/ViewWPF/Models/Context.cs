
using System.Data.Entity;
using ViewWPF.Models;

namespace ViewWPF.Models
{
    class Context : DbContext
    {
        public Context() : base("strConn")
        {

        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Medico> Medicos { get; set; }
        public DbSet<Paciente> Pacientes { get; set; }
        


    }
}
