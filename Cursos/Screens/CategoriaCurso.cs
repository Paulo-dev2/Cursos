using System;
using Cursos.Data;
using Cursos.models;

namespace Cursos.Screens
{
    public class CategoriaCursoRel
    {
        public String mensagem = "";

        public CategoriaCursoRel()
        {
            Console.Clear();
            int opcao,id_curso, id_categoria = 0;

            Console.WriteLine("[1] Cadastro de relacionamento\n [2] Apagar relacionamentos\n [3] Listagem de relacionamentos\n [4] Editar relacionamento");
            opcao = Convert.ToInt32(Console.ReadLine());
            using (var context = new CursosDataContext())
            {
                switch (opcao)
                {
                    case 1:
                        Console.WriteLine("Cursos: \n");
                        foreach (var curso in context.Cursos)
                        {
                            Console.WriteLine($"{ curso.Id} - { curso.Title }");
                        }

                        Console.WriteLine("Categorias: \n");
                        foreach (var categoria in context.Categorias)
                        {
                            Console.WriteLine($"{ categoria.Id} - { categoria.Name }");
                        }

                        Console.WriteLine("Qual o id da categoria: \n");
                        id_categoria = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Qual o id do curso: \n");
                        id_curso = Convert.ToInt32(Console.ReadLine());
                        CadastroRel(id_categoria, id_curso, context);
                        break;
                    case 2:
                        Console.WriteLine("Apagando Categorias\n");
                        ApagaRel(context);
                        break;
                    case 3:
                        ConsultaRel(context);
                        break;
                    case 4:
                        AlterarRel(context);
                        break;
                    default:
                        Console.WriteLine("Opcao Invalida");
                        break;
                }
            }

            static void CadastroRel(int id_categoria, int id_curso, CursosDataContext context)
            {
                var rel = new CategoriaCurso
                {
                    CategoriaId = id_categoria,
                    CursoId = id_curso,
                };
                context.CategoriaCursos.Add(rel);
                try
                {
                    context.SaveChanges();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }

            static void ConsultaRel(CursosDataContext context)
            {
                Console.WriteLine("Relacionamentos: \n");
                foreach (var rel in context.CategoriaCursos)
                {
                    Console.WriteLine($"{ rel.CategoriaId} - { rel.CursoId }");
                }
            }

            static void AlterarRel(CursosDataContext context)
            {
                int id, id_curso, id_categoria = 0; ;
                string nome, slug, description = "";

                ConsultaRel(context);

                Console.WriteLine("Digite o Id ro rel");
                id = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Qual o id da categoria: \n");
                id_categoria = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Qual o id do curso: \n");
                id_curso = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Qual a nova descricao da categoria: \n");
                description = Console.ReadLine();

                var categoria = context.CategoriaCursos.Find(id);
                categoria.CategoriaId = id_categoria;
                categoria.CursoId = id_curso;
                context.SaveChanges();
            }

            static void ApagaRel(CursosDataContext context)
            {
                var rel = context.CategoriaCursos;
                foreach (var r in rel)
                {
                    context.CategoriaCursos.Remove(r);
                }

                context.SaveChanges();
            }
        }
    }
}
