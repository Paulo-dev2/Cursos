using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cursos.models
{
    [Table(name: "Students")]
    public class Students
    {
        [Key]
        public int Matricula { get; set; }
        public string? Name { get; set; }
        public string? Cpf { get; set; }
        public string? Email { get; set; }
        public string? PasswordHash { get; set; }
        public string? Image { get; set; }
        public string? Slug { get; set; }
        public string? Bio { get; set; }
        public DateTime DataCriacao { get; set; }
    }
}