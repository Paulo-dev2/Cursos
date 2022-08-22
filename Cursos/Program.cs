using System;
using Cursos.Screens;

namespace Cursos
{
    class Program
    {
        public static void Main(string[] args)
        {
            int opcao = 0;
            Console.WriteLine("[1] Categorias\n [2] Cursos\n [3] Author\n [4] Alunos\n [5] Categoria_Cursos\n [6] Aluno_Curso");
            opcao = Convert.ToInt32(Console.ReadLine());
            switch (opcao)
            {
                case 1:
                    Categoria categoria = new Categoria();
                    break;
                case 2:
                    Course cursos = new Course();
                    break;
                case 3:
                    Authores authores = new Authores();
                    break;
                case 4:
                    Student student = new Student();
                    break;
                case 5:
                    
                    break;
                case 6:
                    
                    break;
                default:
                    Console.WriteLine("Opcao Invalida");
                    break;
            }

        }
    }

}