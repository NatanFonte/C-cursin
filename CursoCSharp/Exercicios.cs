using System;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CursoCSharp
{
    public class Livro
    {
        private string titulo;
        private string autor;
        private int anoPublicacao;
        private string autorPublicacao;
        private int numeroPaginas;


        public string Titulo
        {
            get { return titulo; }
            set { titulo = value; }
        }

        public string Autor
        {
            get { return autor; }
            set { autor = value; }
        }

        public int AnoPublicacao
        {
            get { return anoPublicacao; }
            set { anoPublicacao = value; }
        }

        public string AutorPublicacao
        {
            get { return autorPublicacao; }
            set { autorPublicacao = value; }
        }

        public int NumeroPaginas
        {
            get { return numeroPaginas; }
            set { numeroPaginas = value; }
        }

        public Livro(string titulo, string autor, int anoPublicacao, string autorPublicacao, int numeroPaginas)
        {
            this.titulo = titulo;
            this.autor = autor;
            this.anoPublicacao = anoPublicacao;
            this.autorPublicacao = autorPublicacao;
            this.numeroPaginas = numeroPaginas;
        }


        public void ExibirDetalhes()
        {
            Console.WriteLine(Titulo);
            Console.WriteLine(Autor);
            Console.WriteLine(AnoPublicacao);
            Console.WriteLine(AutorPublicacao);
        }
    }


    public class Biblioteca
    {
      private List<Livro> acervo  =  new List<Livro>();


        public void AdicionarLivro(Livro livro)                                
        {
            acervo.Add(livro);
        }

        public void RemoverLivro(string titulo) 
        {
            var livroParaRemover = acervo.SingleOrDefault(l => l.Titulo == titulo);

            if (livroParaRemover != null)
            {
                acervo.Remove(livroParaRemover);
               
            }            
        }



    }



}




