using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cursos.models
{
    [Table("Courses")]
    public class Courses
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int TimeDuration { get; set; }
        public float Value { get; set; }
        public string Slug { get; set; }
        public Boolean IsActive { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime LastUpdateDate { get; set; }
    }
}