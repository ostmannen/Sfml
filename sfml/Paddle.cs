using System.Drawing;
using System.Reflection.Emit;
using System;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace sfml
{
    public class Paddle
    {
        public Sprite sprite;
        public const float width = 64.0f;
        public const float length = 14.0f;
        public float speed = 300.0f;
        public Vector2f size;

        public Paddle(){
            sprite = new Sprite();
            sprite.Texture = new Texture("assets/paddle.png");
            sprite.Position = new Vector2f(250, 650);
            Vector2f paddleTextureSize = (Vector2f) sprite.Texture.Size;
            sprite.Origin = 0.5f * paddleTextureSize;
            sprite.Scale = new Vector2f(
                width / paddleTextureSize.X,
                length / paddleTextureSize.Y);
            size = new Vector2f(
                sprite.GetGlobalBounds().Width,
                sprite.GetGlobalBounds().Height
            );


        }
        public void Update(Ball ball, float deltaTime){
            var newPos = sprite.Position;
            
            if (Keyboard.IsKeyPressed(Keyboard.Key.Right)){
                newPos.X += deltaTime * speed;
            }
            if (Keyboard.IsKeyPressed(Keyboard.Key.Left)){
                newPos.X -= deltaTime * speed;
            }
            if (newPos.X > Program.ScreenW - width * 0.5){
                newPos.X = Program.ScreenW - width * 0.5f;
            }
            if (newPos.X < 0 + width * 0.5f){
                newPos.X = 0 + width * 0.5f;
            }
            if (Collision.CircleRectangle(ball.sprite.Position, Ball.Radius, 
                this.sprite.Position, size, out Vector2f hit)){
                ball.sprite.Position += hit;
                ball.Reflect(hit.Normalized());
                //Fråga Emil!!! -_-
            }

            sprite.Position = newPos;
        }
        public void Draw(RenderTarget target){
            target.Draw(sprite);
        }
    }
}
