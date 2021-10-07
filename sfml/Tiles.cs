using System.Collections.Generic;
using System.Net.Mime;
using System;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace sfml
{
    public class Tiles
    {
        public Sprite sprite;
        public const float width = 64.0f;
        public const float length = 24.0f;
        public Vector2f size;
        public List<Vector2f> positions;
        public Tiles(){
            positions = new List<Vector2f>();
            for (int i = -2; i <= 2; i++)
            {
                for (int j = -2; j < 2; j++)
                {
                    var pos = new Vector2f(
                        Program.ScreenW * 0.5f + i * 96.0f,
                        Program.ScreenH * 0.3f + j * 48.0f
                    );
                    positions.Add(pos);
                }
            }
    
            sprite = new Sprite();
            sprite.Texture = new Texture("assets/tileBlue.png");

            Vector2f tileTextureSize = (Vector2f) sprite.Texture.Size;
            sprite.Origin = 0.5f * tileTextureSize;
            sprite.Scale = new Vector2f(
                width / tileTextureSize.X,
                length / tileTextureSize.Y
            );
            size = new Vector2f(
                sprite.GetGlobalBounds().Width,
                sprite.GetGlobalBounds().Height
            );

        }
        public void Update(float deltaTime, Ball ball){
            for (int i = 0; i < positions.Count; i++)
            {
                var pos = positions[i];
                if (Collision.CircleRectangle(ball.sprite.Position, Ball.Radius, 
                pos, size, out Vector2f hit)){
                    ball.sprite.Position += hit;
                    ball.Reflect(hit.Normalized());
                    positions.RemoveAt(i);
                    i = 0;
                    //collitoin fungerar inte. fråga emil
                }
            }
        }
        public void Draw(RenderTarget target){
            for (int i = 0; i < positions.Count; i++)
            {
                sprite.Position = positions[i];
                target.Draw(sprite);
            }
        }
    }
}
