using System;
using Cursos.Data;
using Cursos.models;

namespace Cursos.Screens
{
    public class Authores
    {
        public String mensagem = "";

        public Authores()
        {
            Console.Clear();
            int opcao;
            string name, password, bio, slug, cpf, image, email = "";

            Console.WriteLine("[1] Cadastro de Author\n [2] Apagar Author\n [3] Listagem de Author\n [4] Editar Author");
            opcao = Convert.ToInt32(Console.ReadLine());
            using (var context = new CursosDataContext())
            {
                switch (opcao)
                {
                    case 1:
                        Console.WriteLine("Qual o nome do author: \n");
                        name = Console.ReadLine();
                        Console.WriteLine("Qual o cpf do author: \n");
                        cpf = Console.ReadLine();
                        Console.WriteLine("Qual o email do author: \n");
                        email = Console.ReadLine();
                        Console.WriteLine("Qual a senha do author: \n");
                        password = Console.ReadLine();
                        Console.WriteLine("Qual a imagem do author: \n");
                        image = Console.ReadLine();
                        Console.WriteLine("Qual o slug do author: \n");
                        slug = Console.ReadLine();
                        Console.WriteLine("Qual a bio do author: \n");
                        bio = Console.ReadLine();
                        CadastroAuthor(name, password, bio, slug, cpf, image, email, context);
                        break;
                    case 2:
                        Console.WriteLine("Apagando Authores\n");
                        ApagaAuthor(context);
                        break;
                    case 3:
                        ConsultaAuthor(context);
                        break;
                    case 4:
                        AlterarAuthor(context);
                        break;
                    default:
                        Console.WriteLine("Opcao Invalida");
                        break;
                }
            }

            static void CadastroAuthor(string name, string password, string bio, string slug, string cpf, string image, string email, CursosDataContext context)
            {
                var authores = new Author { Name = name, Cpf = cpf, Email = email, PasswordHash = password, Slug = slug, Image = image, Bio = bio };
                context.Autores.Add(authores);
                try
                {
                    context.SaveChanges();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }

            static void ConsultaAuthor(CursosDataContext context)
            {
                Console.WriteLine("Autores: \n");
                foreach (var author in context.Autores)
                {
                    Console.WriteLine($"{ author.Id} - { author.Name} - { author.Cpf } - {author.Email}");
                }
            }

            static void AlterarAuthor(CursosDataContext context)
            {
                int id = 0;
                string name, password, bio, slug, cpf, image, email = "";

                ConsultaAuthor(context);

                Console.WriteLine("Qual o nome do author: \n");
                name = Console.ReadLine();
                Console.WriteLine("Qual o cpf do author: \n");
                cpf = Console.ReadLine();
                Console.WriteLine("Qual o email do author: \n");
                email = Console.ReadLine();
                Console.WriteLine("Qual a senha do author: \n");
                password = Console.ReadLine();
                Console.WriteLine("Qual a imagem do author: \n");
                image = Console.ReadLine();
                Console.WriteLine("Qual o slug do author: \n");
                slug = Console.ReadLine();
                Console.WriteLine("Qual a bio do author: \n");
                bio = Console.ReadLine();

                var author = context.Autores.Find(id);
                author.Name = name;
                author.Cpf = cpf;
                author.Email = email;

                author.PasswordHash = password;
                author.Image = image;
                author.Slug = slug;
                author.Bio = bio;
                context.SaveChanges();
            }

            static void ApagaAuthor(CursosDataContext context)
            {
                var Authores = context.Autores;
                foreach (var author in Authores)
                {
                    context.Autores.Remove(author);
                }

                context.SaveChanges();
            }
        }
    }
}
