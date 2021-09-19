namespace DIOflix
{
    using System;
    public class Serie : Filme
    {
        private int numEpisodes { get; set; }

        public Serie(int id, EGenero genero, string titulo, int ano, string sinopse, string actressLead, string actorLead, int numEpisodes) 
        : base(id, genero, titulo, ano, sinopse, actressLead, actorLead)
        {
            this.numEpisodes = numEpisodes;
        }

        public override string ToString()
        {
            string message = base.ToString();

            message += "Episódios: " + this.numEpisodes + Environment.NewLine;

            return message;
        }       
    }
}