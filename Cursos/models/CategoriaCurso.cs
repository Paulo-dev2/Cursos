using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cursos.models
{
    [Table("CategoriaCurso")]
    public class CategoriaCurso
    {
        [Key] 
        public int CategoriaId { get; set; }
        public int CursoId { get; set; }
    }
}