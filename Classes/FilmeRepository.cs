using System;
using System.Collections.Generic;
using DIOflix.Interfaces;
using DIOflix.Exceptions;

namespace DIOflix
{
    public class FilmeRepository : IRepository<Filme>
    {
        private List<Filme> filmList = new List<Filme>();

        public void Atualiza(int id, Filme entity)
        {
            if(filmList[id].IsDeleted() || !filmList.Contains(filmList[id])){
                throw new ItemNotExist(); 
            }
            filmList[id] = entity;
        }

        public void Exclui(int id)
        {
            if(filmList[id].IsDeleted() || !filmList.Contains(filmList[id])){
                throw new ItemNotExist(); 
            }
            filmList[id].Delete();
        }

        public void Insere(Filme entity)
        {
            if(filmList.Contains(entity)){
                throw new ItemExist();
            } else {
                filmList.Add(entity);
            }
        }

        public List<Filme> Lista()
        {
            return filmList;
        }

        public int ProximoId()
        {
            return filmList.Count;
        }

        public Filme RetornaPorId(int id)
        {
            if(filmList[id].IsDeleted() || !filmList.Contains(filmList[id])){
                throw new ItemNotExist(); 
            }
            return filmList[id];
        }
    }
}