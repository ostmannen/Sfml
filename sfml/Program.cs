using System;
using SFML.System;
using SFML.Window;
using SFML.Graphics;

class Program
{
    static void Main(string[] args)
    {
        using (var window = new RenderWindow(new VideoMode(800, 600), "Hello SFML")) 
        {
            window.Closed += (s,e) => window.Close();

            Clock clock= new Clock();

            // Set up game objects here

            while (window.IsOpen) 
            {
                float deltaTime= clock.Restart().AsSeconds();
                window.DispatchEvents();
                window.Clear(new Color(131, 197, 235));

                // Put rendering code here 

                window.Display();
            }
        }
    }
}