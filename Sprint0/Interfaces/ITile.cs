using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sprint0;
public interface ITile
{
    Point Location { get; set; }

    void Update(GameTime gameTime);

    void Draw(SpriteBatch spriteBatch);
}