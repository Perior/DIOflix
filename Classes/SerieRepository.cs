using System;
using System.Collections.Generic;
using DIOflix.Interfaces;
using DIOflix.Exceptions;

namespace DIOflix
{
    public class SerieRepository : IRepository<Serie>
    {
        private List<Serie> seriesList = new List<Serie>();

        public void Insere(Serie entity)
        {
            if(seriesList.Contains(entity)){
                throw new ItemExist();
            } else {
                seriesList.Add(entity);
            }
        }

        public void Atualiza(int id, Serie entity)
        {
            if(!seriesList.Contains(seriesList[id]) || seriesList[id].IsDeleted()){
                throw new ItemNotExist(); 
            }
            seriesList[id] = entity;
        }

        public void Exclui(int id)
        {
            if(seriesList[id].IsDeleted() || !seriesList.Contains(seriesList[id])){
                throw new ItemNotExist(); 
            }
            seriesList[id].Delete();
        }

        public List<Serie> Lista()
        {
            return seriesList;
        }

        public int ProximoId()
        {
            return seriesList.Count;
        }

        public Serie RetornaPorId(int id)
        {
            if(seriesList[id].IsDeleted() || !seriesList.Contains(seriesList[id])){
                throw new ItemNotExist(); 
            }
            return seriesList[id];
        }
    }
}