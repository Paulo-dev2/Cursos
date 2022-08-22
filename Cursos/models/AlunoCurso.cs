using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cursos.models
{
    [Table("AlunosCurso")]
    public class AlunoCurso
    {
        [Key] 
        public Guid CourseId { get; set; }
        public Guid StudentId { get; set; }
        public int Progress { get; set; }
        public DateTime DataInit { get; set; }
        public DateTime DateLastUpdate { get; set; }
    }
}