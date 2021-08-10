using System;

namespace Cadastro_Serie
{
    public class Series : EntidadeBase
    {
          // Atributos
        private Genero Genero{get;set;}
        private string Titulo {get;set;}
        private string Descrição {get;set;}
        private int Ano {get;set;}
        private bool Excluido {get;set;}

        //Metodos
        public Series(int id, Genero genero, string titulo, string descrição, int ano)
        {
            this.Id = id;
            this.Genero = genero;
            this.Titulo = titulo;
            this.Descrição = descrição;
            this.Ano = ano;
            this.Excluido = false;
        }

        public Series()
        {
        }

        public override string ToString()
        {
            string retorno ="";
            retorno += "Genero: "+ this.Genero + Environment.NewLine;
            retorno += "Titulo: "+ this.Titulo + Environment.NewLine;
            retorno += "Descrição: "+ this.Descrição + Environment.NewLine;
            retorno += "Ano de Inicio: "+ this.Ano + Environment.NewLine; 
            retorno += "Excluido: "+ this.Excluido + Environment.NewLine; 
            return retorno;
        }
        public string retornaTitulo()
        {
            return this.Titulo;
        }
        internal int RetornaId()
        {
            return this.Id;
        }

        public void Excluir()
        {
            this.Excluido = true;
        }
        
        public bool retornaExcluido()
        {
            return this.Excluido;
        }

    }
}