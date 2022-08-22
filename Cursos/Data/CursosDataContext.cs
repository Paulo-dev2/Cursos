using Microsoft.EntityFrameworkCore;
using Cursos.models;

namespace Cursos.Data
{
    public class CursosDataContext : DbContext
    {
        const string connectionString = @"Data Source=usinacompany.com;User ID=usina_usrmentoria;Password=Abc12345;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        protected override void OnConfiguring( DbContextOptionsBuilder options) => options.UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\abdie\OneDrive\Documents\Faculdade.mdf;Integrated Security=True;Connect Timeout=30");

        public DbSet<Students>? Alunos { get; set; }

        public DbSet<AlunoCurso>? AlunoCursos { get; set; }
        public DbSet<Author>? Autores { get; set; }
        public DbSet<Category>? Categorias { get; set; }
        public DbSet<CategoriaCurso>? CategoriaCursos { get; set; }
        public DbSet<Courses>? Cursos { get; set; }
    }
}
