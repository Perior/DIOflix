using System;
namespace DIOflix.Exceptions
{
    public class ItemNotExist : Exception
    {
        public ItemNotExist()
            : base("Item inexistente ou excluido"){
        }
    }
}