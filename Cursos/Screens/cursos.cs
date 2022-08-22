using System;
using Cursos.Data;
using Cursos.models;

namespace Cursos.Screens
{
    public class Course
    {
        public String mensagem = "";

        public Course()
        {
            Console.Clear();
            int opcao, TimeDuration = 0;
            string title, slug, description = "";
            bool IsActive = false;
            float valor = 0;

            Console.WriteLine("[1] Cadastro de Cursos\n [2] Apagar Cursos\n [3] Listagem de Cursos\n [4] Editar Curso");
            opcao = Convert.ToInt32(Console.ReadLine());
            using (var context = new CursosDataContext())
            {
                switch (opcao)
                {
                    case 1:
                        Console.WriteLine("Qual o nome do curso: \n");
                        title = Console.ReadLine();
                        Console.WriteLine("Qual o tempo em minutos do curso: \n");
                        TimeDuration = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Qual o valor do curso: \n");
                        valor = float.Parse(Console.ReadLine());
                        Console.WriteLine("O curso esta ativo: \n");
                        IsActive = Convert.ToBoolean(Console.ReadLine());
                        Console.WriteLine("Qual o slug do curso: \n");
                        slug = Console.ReadLine();
                        Console.WriteLine("Qual a descricao do curso: \n");
                        description = Console.ReadLine();
                        CadastroCurso(title, description, TimeDuration, slug,valor, IsActive, context);
                        break;
                    case 2:
                        Console.WriteLine("Apagando Cursos\n");
                        ApagaCurso(context);
                        break;
                    case 3:
                        ConsultaCurso(context);
                        break;
                    case 4:
                        AlterarCurso(context);
                        break;
                    default:
                        Console.WriteLine("Opcao Invalida");
                        break;
                }
            }

            static void CadastroCurso(string title, string description, int TimeDuration, string slug, float valor, bool IsActive, CursosDataContext context)
            {
                var curso = new Courses { Description = description, TimeDuration = TimeDuration, Title = title, IsActive = IsActive, Slug = slug, Value= valor };
                context.Cursos.Add(curso);
                try
                {
                    context.SaveChanges();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }

            static void ConsultaCurso(CursosDataContext context)
            {
                Console.WriteLine("Cursos: \n");
                foreach (var curso in context.Cursos)
                {
                    Console.WriteLine($"{ curso.Id} - { curso.Title} - { curso.Value } - {curso.Description}");
                }
            }

            static void AlterarCurso(CursosDataContext context)
            {
                int id = 0;
                int opcao, TimeDuration = 0;
                string title, slug, description = "";
                bool IsActive = false;
                float valor = 0;

                ConsultaCurso(context);

                Console.WriteLine("Digite o Id do curso");
                id = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Qual o nome do curso: \n");
                title = Console.ReadLine();
                Console.WriteLine("Qual o tempo em minutos do curso: \n");
                TimeDuration = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Qual o valor do curso: \n");
                valor = float.Parse(Console.ReadLine());
                Console.WriteLine("O curso esta ativo: \n");
                IsActive = Convert.ToBoolean(Console.ReadLine());
                Console.WriteLine("Qual o slug do curso: \n");
                slug = Console.ReadLine();
                Console.WriteLine("Qual a descricao do curso: \n");
                description = Console.ReadLine();

                var curso = context.Cursos.Find(id);
                curso.Title = title;
                curso.Slug = slug;
                curso.Description = description;

                curso.Value = valor;
                curso.IsActive = IsActive;
                curso.TimeDuration = TimeDuration;
                context.SaveChanges();
            }

            static void ApagaCurso(CursosDataContext context)
            {
                var cursos = context.Cursos;
                foreach (var curso in cursos)
                {
                    context.Cursos.Remove(curso);
                }

                context.SaveChanges();
            }
        }
    }
}
