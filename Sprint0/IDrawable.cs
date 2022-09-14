using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0
{
    public interface IDrawable : IDrawableKernel
    {
        /* New Methods */
        public void MoveLeft(int p_pixels);
        public void MoveRight(int p_pixels);
        public void MoveUp(int p_pixels);
        public void MoveDown(int p_pixels);
    }
}
