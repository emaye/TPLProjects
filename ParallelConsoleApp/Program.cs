//// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");


class Program
{
    static void Main()
    {

        Task.Run(() => Console.WriteLine("Hello from Task!")).Wait();
        Console.WriteLine("Hello from Main!");


        //The Task class is fundamental to TPL. You can create and start tasks with it.
        Task myTask = Task.Run(() =>
        {
            // your code here
            Console.WriteLine("Doing some work...");

        });

        myTask.Wait();

        if (myTask.Status == TaskStatus.RanToCompletion)
        {
            Console.WriteLine("Task finished successfully.");
        }

        //Continuations allow tasks to chain together, meaning one task can start once another completes.
        Task firstTask = Task.Run(() => Console.WriteLine("First Task"));
        Task continuation = firstTask.ContinueWith(t => Console.WriteLine("Continuation Task"));

        continuation.Wait();

        //Limiting the maximum degree of parallelism to 2
        var options = new ParallelOptions()
        {
            MaxDegreeOfParallelism = 2
        };
        // using Parallel.For to iterate over a range of numbers.
        Parallel.For(0, 10, options, i =>
        {
            Console.WriteLine($"Processing number: {i}");

        });


        //Parallel.ForEach works similarly like Parallel.For  but is used for collections.
        List<int> numbers = new List<int> { 1, 2, 3, 4, 5 };
        Parallel.ForEach(numbers, number =>
        {
            Console.WriteLine($"Processing number: {number}");

        });

        //catching exceptions
        try
        {
            Parallel.ForEach(numbers, number =>
            {
                if (number == 3)
                {
                    throw new InvalidOperationException("Number 3 is not allowed!");
                }
                Console.WriteLine($"Processing number: {number}");
            });

        }
        catch (AggregateException ae)
        {
            foreach (var ex in ae.InnerExceptions)
            {
                Console.WriteLine(ex.Message);
            }
        }


        //This snippet demonstrates how to cancel a long-running task using a CancellationToken.
        CancellationTokenSource cts = new CancellationTokenSource();

        Task longRunningTask = Task.Run(() =>
        {
            for (int i = 0; i < 10; i++)
            {
                cts.Token.ThrowIfCancellationRequested();

                Console.WriteLine($"Working... {i}");
                Thread.Sleep(1000); // Simulate work
            }
        }, cts.Token);

        Thread.Sleep(3000); // Let the task run for a bit
        cts.Cancel();

        try
        {
            longRunningTask.Wait();
        }
        catch (AggregateException ae)
        {
            Console.WriteLine("Task was cancelled.");
        }


        //These combinators wait for all or any tasks to complete and then execute the continuation function.
        Task task1 = Task.Delay(2000);
        Task task2 = Task.Delay(1000);

        Task.WhenAll(task1, task2).ContinueWith(_ => Console.WriteLine("Both tasks completed"));
        Task.WhenAny(task1, task2).ContinueWith(t => Console.WriteLine("A task completed"));

        //The async/await pattern simplifies writing asynchronous code.
        async Task ProcessDataAsync()
        {
            await Task.Run(() =>
            {
                // Simulated async workload
                Thread.Sleep(2000);

                Console.WriteLine("Data processed.");

            });
            await ProcessDataAsync();

            Console.WriteLine("Processing done.");
        }


        //converting the LINQ query to a parallel query to process data collections more efficiently
        var data = Enumerable.Range(1, 100).ToList();
        var parallelQuery = data.AsParallel().Where(x => x % 2 == 0).ToList();

        parallelQuery.ForEach(Console.WriteLine);



    }



}
