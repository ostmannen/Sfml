using System.Net.Mime;
using System;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace sfml
{
    public class Ball
    {
        public Sprite sprite;
        public const float Diameter = 20.0f;  
        public const float Radius= Diameter * .5f;
        public Vector2f direction = new Vector2f(-1,1) / MathF.Sqrt(2.0f);
        public float speed = 200.0f;
        public int health = 3;
        public int score = 0;
        public Text gui;
                

        public Ball(){
            sprite = new Sprite();
            sprite.Texture = new Texture("assets/ball.png");
            //Hämtar in bilden av bollen
            sprite.Position = new Vector2f(250, 300);
            //sätter position

            Vector2f ballTextureSize = (Vector2f) sprite.Texture.Size;
            //sparar ner storleken av bilden i en vector2
            sprite.Origin = 0.5f * ballTextureSize;
            //sätter bildens mittpunkt
            sprite.Scale = new Vector2f(
                Diameter / ballTextureSize.X,
                Diameter / ballTextureSize.Y);
                //bilden blir 20 pixlar hög och bred
            gui = new Text();
            gui.CharacterSize = 24;
            gui.Font = new Font("assets/future.ttf");
        }
        public void Update(float deltaTime){
            var newPos = sprite.Position;
            //sparar ner spelarens postion
            newPos += direction * deltaTime * speed;
            //adderar på spelarens postion, så att den rör på sig
            if (newPos.X > Program.ScreenW - Radius //spelarens mittpunkt
            )
            //kollar ifall spelaren är utanför skärmen
            {
                newPos.X = Program.ScreenW - Radius;
                //sätter spelarens postionen innnanför skärmen
                Reflect(new Vector2f(-1,0));
                //reflecterar spelaren
            }
            if (newPos.X < 0 + Radius){
                newPos.X = 0 + Radius;
                Reflect(new Vector2f(1,0));
            }
            if (newPos.Y > Program.ScreenH - Radius){
                newPos.Y = Program.ScreenH - Radius;
                health--;
                newPos = resetBall();
            }
            if (newPos.Y < 0 + Radius){
                newPos.Y = 0 + Radius;
                Reflect(new Vector2f(0,1));
            }

            sprite.Position = newPos;
            //sparar ner spelarens nya postion

        }
        public void Draw(RenderTarget target){
            target.Draw(sprite);
            //ritar bilden

            gui.DisplayedString = $"Health {health}";
            gui.Position = new Vector2f(12, 8);
            target.Draw(gui);
            gui.DisplayedString = $"Score: {score}";
            gui.Position = new Vector2f(Program.ScreenW - gui.GetGlobalBounds().Width - 12,8);
            target.Draw(gui);
        }
        public void Reflect(Vector2f normal){
            direction -= normal * (2 * (direction.X * normal.X + direction.Y * normal.Y));
            //formel för att reflectera riktningar
        }
        public Vector2f resetBall(){
            Random random = new Random();
            Vector2f tempDirection = new Vector2f();
            int chooseDirection = random.Next() % 2;
            if (chooseDirection == 1){
                tempDirection = new Vector2f(1, 1);
            }
            else{
                tempDirection = new Vector2f(-1, 1);
            }
            this.direction = tempDirection / MathF.Sqrt(2.0f);
            return new Vector2f(250, 300);     
        }
    }
}