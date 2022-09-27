using Microsoft.Xna.Framework.Graphics;

namespace sprint0.Interfaces; 

public interface ILinkState {
    
    public void Draw(SpriteBatch spriteBatch);
    void Update();
    void MoveUp();
    void MoveDown();
    void MoveLeft();
    void MoveRight();
    //more controls later?
}