using System;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace sfml
{
    public class Ball
    {
        public Sprite sprite;

        public Ball(){
            sprite = new Sprite();
            sprite.Texture = new Texture("assets/ball.png");
            sprite.Position = new Vector2f(250,300);
        }
        public void Update(float deltaTime){

        }
        public void Draw(RenderTarget target){
            target.Draw(sprite);
        }

    }
}
