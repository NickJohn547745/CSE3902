using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using sprint0.Interfaces;

namespace sprint0
{
    public class EnemySpriteFactory
    {

        private Texture2D enemySpriteSheet;
        // any other textures needed

        private static EnemySpriteFactory instance = new EnemySpriteFactory();

        public static EnemySpriteFactory Instance
        {
            get { return instance; }
        }

        private EnemySpriteFactory()
        {
        }

        public void LoadAllTextures(ContentManager content)
        {
            //enemySpriteSheet = content.Load<Texture2D>("Enemy");
        }

        /*
         * Add create Enemy functions when classes have been made
        public ISprite CreateEnemySprite()
        {
            return new EnemySprite();
        }
        */
    }
}
