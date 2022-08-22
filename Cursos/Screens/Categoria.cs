using System;
using Cursos.Data;
using Cursos.models;

namespace Cursos.Screens
{
    public class Categoria
    {
        public String mensagem = "";

        public Categoria()
        {
            Console.Clear();
            int opcao = 0;
            string nome, slug, description = "";

            Console.WriteLine("[1] Cadastro de Categorias\n [2] Apagar Categorias\n [3] Listagem de categorias\n [4] Editar categoria");
            opcao = Convert.ToInt32(Console.ReadLine());
            using (var context = new CursosDataContext())
            {
                switch (opcao)
                {
                    case 1:
                        Console.WriteLine("Qual o nome da categoria: \n");
                        nome = Console.ReadLine();
                        Console.WriteLine("Qual o slug da categoria: \n");
                        slug = Console.ReadLine();
                        Console.WriteLine("Qual a descricao da categoria: \n");
                        description = Console.ReadLine();
                        CadastroCategoria(nome, description, slug, context);
                        break;
                    case 2:
                        Console.WriteLine("Apagando Categorias\n");
                        ApagaCategorias(context);
                        break;
                    case 3:
                        ConsultaCategoria(context);
                        break;
                    case 4:
                        AlterarCategoria(context);
                        break;
                    default:
                        Console.WriteLine("Opcao Invalida");
                        break;
                }
            }

            static void CadastroCategoria(string name, string description, string slug, CursosDataContext context)
            {
                var categoria = new Category
                {
                    Name = name,
                    Description = description,
                    Slug = slug
                };
                context.Categorias.Add(categoria);
                try
                {
                    context.SaveChanges();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }

            static void ConsultaCategoria(CursosDataContext context)
            {
                Console.WriteLine("Categorias: \n");
                foreach (var categoria in context.Categorias)
                {
                    Console.WriteLine($"{ categoria.Id} - { categoria.Name} - { categoria.Slug }");
                }
            }

            static void AlterarCategoria(CursosDataContext context)
            {
                int id = 0;
                string nome, slug, description = "";

                ConsultaCategoria(context); 

                Console.WriteLine("Digite o Id da categoria");
                id = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Qual o novo nome da categoria: \n");
                nome = Console.ReadLine();
                Console.WriteLine("Qual o novo slug da categoria: \n");
                slug = Console.ReadLine();
                Console.WriteLine("Qual a nova descricao da categoria: \n");
                description = Console.ReadLine();

                var categoria = context.Categorias.Find(id);
                categoria.Name = nome;
                categoria.Slug = slug;
                categoria.Description = description;
                context.SaveChanges();
            }

            static void ApagaCategorias(CursosDataContext context)
            {
                var categorias = context.Categorias;
                foreach (var categoria in categorias)
                {
                    context.Categorias.Remove(categoria);
                }

                context.SaveChanges();
            }
        }
    }
}
