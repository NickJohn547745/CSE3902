using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sprint0.Interfaces
{
    public interface IItem
    {
        void SetBaseDurability(int maxDurability);
        int GetBaseDurability();

        void SetBasePower(int basePower);
        int GetBasePower();

        void Update(GameTime gameTime);
    }
}
