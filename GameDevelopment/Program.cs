//// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");

using System;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace GameDevelopment
{
    class Program
    {
        static void Main(string[] args)
        {
            List<GameObject> gameObjects = InitializeGameObjects(1000);

            //In this scenario, Parallel.ForEach is used to update the physics for thousands
            //of game objects simultaneously, thereby improving the game’s performance and
            //responsiveness.
            Parallel.ForEach(gameObjects, gameObject =>
            {
                gameObject.UpdatePhysics();
            });

            Console.WriteLine("Physics update completed.");

        }

        static List<GameObject> InitializeGameObjects(int count)
        {
            List<GameObject> gameObjects = new List<GameObject>();

            for (int i = 0; i < count; i++)
            {
                gameObjects.Add(new GameObject());

            }

            return gameObjects;
        }
    }


    class GameObject
    {
        public void UpdatePhysics()
        {
            // Simulate complex physics calculations
            Task.Delay(10).Wait();
        }
    }

}
