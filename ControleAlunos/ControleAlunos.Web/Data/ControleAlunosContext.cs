using ControleAlunos.Web.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace ControleAlunos.Web.Data
{
    public class ControleAlunosContext : DbContext
    {
        public ControleAlunosContext() : base("ConectionStringBDAlunos")
        {
            //Database.SetInitializer<ControleAlunosContext>(new ControleAlunosContextInicializar());
        }

        public DbSet<Usuario> Usuarios { get; set; }

        public DbSet<Aluno> Alunos { get; set; }

        public DbSet<Cidade> Cidades { get; set; }

        public DbSet<Pais> Pais { get; set; }
        
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            base.OnModelCreating(modelBuilder);
        }

        
    }
    public class ControleAlunosContextInicializar : DropCreateDatabaseAlways<ControleAlunosContext>
    {

    }
}