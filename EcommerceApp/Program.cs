//// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace EcommerceApp
{

    //This code demonstrates running multiple product search operations concurrently
    //, improving the user experience by reducing the time to return search results.
    class Program
    {
        static void Main(string[] args)
        {
            List<string> searchTerms = new List<string> { "laptop", "smartphone", "camera" };
            List<Task<List<string>>> searchTasks = searchTerms.Select(term =>  Task.Run(() => SearchProducts(term))).ToList();

            Task.WhenAll(searchTasks);

            foreach (var task in searchTasks)
            {
                var result = task.Result;

                Console.WriteLine($"Search completed for {result.Count} products.");

            }
        }

        static List<string> SearchProducts(string term)
        {
            // Simulate product search operation
            Task.Delay(1000).Wait();

            return new List<string> { $"{term} 1", $"{term} 2", $"{term} 3" };

        }

    }
}