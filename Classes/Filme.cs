namespace DIOflix
{
    using System;
    public class Filme
    {
        protected int id { get; set; }
        protected EGenero genero { get; set; }
        protected string titulo { get; set; }
        protected int ano { get; set; }
        protected string sinopse { get; set; }
        protected string actressLead { get; set; }
        protected string actorLead { get; set; }
        protected bool deleted { get; set; }

        public Filme(int id, EGenero genero, string titulo, int ano, string sinopse, string actressLead, string actorLead)
        {
            this.id = id;
            this.genero = genero;
            this.titulo = titulo;
            this.ano = ano;
            this.sinopse = sinopse;
            this.actressLead = actressLead;
            this.actorLead = actorLead;
            this.deleted = false;
        }

        public bool IsDeleted(){
            return this.deleted;
        }

        public void Delete(){
            this.deleted = true;
        }

        public int RetornaId(){
            return this.id;
        }

        public string RetornaTitulo(){
            return this.titulo;
        }

        public string RetornaDelete(){
            if(this.deleted){
                return "[REMOVIDO]";
            }

            return "";
        }

        public override string ToString()
        {
            string message = "";

            if(this.deleted){
                message += "[REMOVIDO]" + Environment.NewLine;
            }

            message += "Título: " + this.titulo + Environment.NewLine;
            message += "Gênero: " + this.genero + Environment.NewLine;

            if(string.IsNullOrEmpty(actressLead)){
                message += "Casting: " + this.actorLead + Environment.NewLine;

            } else if(string.IsNullOrEmpty(actorLead)){
                message += "Casting: " + this.actressLead + Environment.NewLine;

            } else {
                message += "Casting: " + this.actressLead;
                message += ", " + this.actorLead + Environment.NewLine;
            }
            
            message += "Ano: " + this.ano + Environment.NewLine;
            message += "Sinopse: " + this.sinopse + Environment.NewLine;

            return message;
        }
    }
}