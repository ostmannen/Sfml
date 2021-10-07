using System;
using SFML.System;
using SFML.Window;
using SFML.Graphics;

namespace sfml
{
    class Program
    {

        public const int ScreenW = 500;
        public const int ScreenH = 700;
        static void Main(string[] args)
        {
            using (var window = new RenderWindow(new VideoMode(ScreenW, ScreenH), "SFML"))
            {
                window.Closed += (s, e) => window.Close();

                Clock clock = new Clock();
                Ball ball = new Ball();
                Paddle paddle = new Paddle();
                Tiles tiles = new Tiles();
                
                

                // Set up game objects here

                while (window.IsOpen)
                {
                    float deltaTime = clock.Restart().AsSeconds();
                    window.DispatchEvents();
                    ball.Update(deltaTime);
                    paddle.Update(ball, deltaTime);
                    tiles.Update(deltaTime, ball);
                    if (ball.health <= 0){
                        ball = new Ball();
                        paddle = new Paddle();
                        tiles = new Tiles();
                    
                    }
                    window.Clear(new Color(131, 197, 235));
                    ball.Draw(window);
                    paddle.Draw(window);
                    tiles.Draw(window);

                    // Put rendering code here 

                    window.Display();
                }
            }
        }
    }
}