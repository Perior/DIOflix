using System;
namespace DIOflix.Exceptions
{
    public class ItemExist : Exception
    {
        public ItemExist()
            : base("Item já cadastrado.")
        {
        }
        
    }
}