using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using sprint0.Interfaces;

namespace sprint0.Factories
{
    public class ProjectileSpriteFactory
    {

        private Texture2D projectileSpriteSheet;
        // any other textures needed

        private static ProjectileSpriteFactory instance = new ProjectileSpriteFactory();

        public static ProjectileSpriteFactory Instance
        {
            get { return instance; }
        }

        private ProjectileSpriteFactory()
        {
        }

        public void LoadAllTextures(ContentManager content)
        {
            //projectileSpriteSheet = content.Load<Texture2D>("Projectile");
        }

        /*
         * Add create Item functions when classes have been made
        public ISprite CreateProjectileSprite()
        {
            return new ProjectileSprite();
        }
        */
    }
}
