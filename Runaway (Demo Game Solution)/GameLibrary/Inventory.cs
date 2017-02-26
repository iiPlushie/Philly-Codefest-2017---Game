using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLibrary
{
    public class Inventory
    {
        private Item[] inventory;
        private int currentSize = 0;

        /// <summary>
        /// Inventory system that will hold objects
        /// </summary>
        public Inventory(int Size)
        {
            if (Size > 0)
            {
                inventory = new Item[Size];
            }
            else
            {
                throw new Exception("Inventory size must be greater than zero: " + Size);
            }
        }

        public void Add(Item Item)
        {
            if(currentSize + 1 <= inventory.Length)
            {
                inventory[currentSize] = Item;
                currentSize++;
            }
        }

        public void Remove(int Slot)
        {
            //
        }
    }
}
