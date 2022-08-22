using System;
using Cursos.Data;
using Cursos.models;

namespace Cursos.Screens
{
    public class Student
    {
        public String mensagem = "";

        public Student()
        {
            Console.Clear();
            int opcao;
            string name, password, bio, slug, cpf, image, email = "";

            Console.WriteLine("[1] Cadastro de Aluno\n [2] Apagar Aluno\n [3] Listagem de Alunos\n [4] Editar Aluno");
            opcao = Convert.ToInt32(Console.ReadLine());
            using (var context = new CursosDataContext())
            {
                switch (opcao)
                {
                    case 1:
                        Console.WriteLine("Qual o nome do aluno: \n");
                        name = Console.ReadLine();
                        Console.WriteLine("Qual o cpf do aluno: \n");
                        cpf = Console.ReadLine();
                        Console.WriteLine("Qual o email do aluno: \n");
                        email = Console.ReadLine();
                        Console.WriteLine("Qual a senha do aluno: \n");
                        password = Console.ReadLine();
                        Console.WriteLine("Qual a imagem do aluno: \n");
                        image = Console.ReadLine();
                        Console.WriteLine("Qual o slug do aluno: \n");
                        slug = Console.ReadLine();
                        Console.WriteLine("Qual a bio do aluno: \n");
                        bio = Console.ReadLine();
                        CadastroAluno(name, password, bio, slug, cpf, image, email, context);
                        break;
                    case 2:
                        Console.WriteLine("Apagando Alunos\n");
                        ApagaAluno(context);
                        break;
                    case 3:
                        ConsultaAluno(context);
                        break;
                    case 4:
                        AlterarAluno(context);
                        break;
                    default:
                        Console.WriteLine("Opcao Invalida");
                        break;
                }
            }

            static void CadastroAluno(string name, string password, string bio, string slug, string cpf, string image, string email, CursosDataContext context)
            {
                var alunos = new Students { Name = name, Cpf = cpf, Email = email, PasswordHash = password, Slug = slug, Image = image, Bio = bio };
                context.Alunos.Add(alunos);
                try
                {
                    context.SaveChanges();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }

            static void ConsultaAluno(CursosDataContext context)
            {
                Console.WriteLine("Alunos: \n");
                foreach (var aluno in context.Alunos)
                {
                    Console.WriteLine($"{ aluno.Matricula } - { aluno.Name} - { aluno.Cpf } - {aluno.Email}");
                }
            }

            static void AlterarAluno(CursosDataContext context)
            {
                int id = 0;
                string name, password, bio, slug, cpf, image, email = "";

                ConsultaAluno(context);

                Console.WriteLine("Qual o nome do aluno: \n");
                name = Console.ReadLine();
                Console.WriteLine("Qual o cpf do aluno: \n");
                cpf = Console.ReadLine();
                Console.WriteLine("Qual o email do aluno: \n");
                email = Console.ReadLine();
                Console.WriteLine("Qual a senha do aluno: \n");
                password = Console.ReadLine();
                Console.WriteLine("Qual a imagem do aluno: \n");
                image = Console.ReadLine();
                Console.WriteLine("Qual o slug do aluno: \n");
                slug = Console.ReadLine();
                Console.WriteLine("Qual a bio do aluno: \n");
                bio = Console.ReadLine();

                var aluno = context.Alunos.Find(id);
                aluno.Name = name;
                aluno.Cpf = cpf;
                aluno.Email = email;

                aluno.PasswordHash = password;
                aluno.Image = image;
                aluno.Slug = slug;
                aluno.Bio = bio;
                context.SaveChanges();
            }

            static void ApagaAluno(CursosDataContext context)
            {
                var Alunos = context.Alunos;
                foreach (var aluno in Alunos)
                {
                    context.Alunos.Remove(aluno);
                }

                context.SaveChanges();
            }
        }
    }
}
