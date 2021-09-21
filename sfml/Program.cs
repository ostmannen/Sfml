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
                


                // Set up game objects here

                while (window.IsOpen)
                {
                    float deltaTime = clock.Restart().AsSeconds();
                    window.DispatchEvents();
                    ball.Update(deltaTime);
                    window.Clear(new Color(131, 197, 235));
                    ball.Draw(window);

                    // Put rendering code here 

                    window.Display();
                }
            }
        }
    }
}