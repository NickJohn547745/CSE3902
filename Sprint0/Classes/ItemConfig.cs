using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using sprint0.Interfaces;
using sprint0.PlayerClasses;

namespace sprint0.Classes
{
    public class ItemConfig
    {
        private List<IItem> items;
        private int currItem;

        public ItemConfig()
        {
            items = new List<IItem>();
            currItem = 0;
        }

        public List<IItem> ItemsList() { return items; }

        public IItem CurrentItem() { return items[currItem]; }

        public void Add(IItem item)
        {
            this.items.Add(item);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            //Draw
        }

        public void Update()
        {

        }

        public void NextItem()
        {
            currItem = (currItem < (items.Count - 1)) ? currItem++ : 0;
        }

        public void PreviousItem()
        {
            currItem = (currItem > 0) ? currItem-- : (items.Count - 1);
        }
    }
}
