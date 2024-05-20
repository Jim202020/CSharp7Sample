// See https://aka.ms/new-console-template for more information
//1
//int GetPrimesCount(int start, int count)
//{
//    return
//    System.Linq.ParallelEnumerable.Range(start, count).Count(n =>
//      Enumerable.Range(2, (int)Math.Sqrt(n) - 1).All(i => n % i > 0));
//}

//void DisplayPrimeCounts()
//{
//    for (int i = 0; i < 10; i++)
//        Console.WriteLine(GetPrimesCount(i * 1000000 + 2, 1000000) +
//          " primes between " + (i * 1000000) + " and " + ((i + 1) * 1000000 - 1));
//    Console.WriteLine("Done! ");
//}

//DisplayPrimeCounts();

//2
//int GetPrimesCount(int start, int count)
//{
//    return
//    System.Linq.ParallelEnumerable.Range(start, count).Count(n =>
//      Enumerable.Range(2, (int)Math.Sqrt(n) - 1).All(i => n % i > 0));
//}
//void DisplayPrimeCounts()
//{
//    for (int i = 0; i < 10; i++)
//        Console.WriteLine(GetPrimesCount(i * 1000000 + 2, 1000000) +
//          " primes between " + (i * 1000000) + " and " + ((i + 1) * 1000000 - 1));
//    Console.WriteLine("Done! ");
//}

//Task.Run(DisplayPrimeCounts);


//3
//Task<int> GetPrimesCountAsync(int start, int count)
//{
//    return Task.Run(() =>
//        ParallelEnumerable.Range(start, count).Count(n =>
//        Enumerable.Range(2, (int)Math.Sqrt(n) - 1).All(i => n % i > 0)));
//}

//for (int i = 0; i < 10; i++)
//{
//    var awaiter = GetPrimesCountAsync(i * 1000000 + 2, 1000000).
//GetAwaiter();
//    awaiter.OnCompleted(() =>
//      Console.WriteLine(awaiter.GetResult() + " primes between... "));
//}
//Console.WriteLine("Done");

//4
//Task<int> GetPrimesCountAsync(int start, int count)
//{
//    return Task.Run(() =>
//        ParallelEnumerable.Range(start, count).Count(n =>
//        Enumerable.Range(2, (int)Math.Sqrt(n) - 1).All(i => n % i > 0)));
//}
//void DisplayPrimeCounts()
//{
//    DisplayPrimeCountsFrom(0);
//}

//void DisplayPrimeCountsFrom(int i)
//{
//    var awaiter = GetPrimesCountAsync(i * 1000000 + 2, 1000000).GetAwaiter();
//    awaiter.OnCompleted(() =>
//    {
//        Console.WriteLine(awaiter.GetResult() + " primes between...");
//        if (++i < 10) DisplayPrimeCountsFrom(i);
//        else Console.WriteLine("Done");
//    });
//}

//DisplayPrimeCounts();

//5
//Task DisplayPrimeCountsAsync()
//{
//    var machine = new PrimesStateMachine();
//    machine.DisplayPrimeCountsFrom(0);
//    return machine.Task;
//}

//DisplayPrimeCountsAsync();

//class PrimesStateMachine
//{
//    TaskCompletionSource<object> tcs = new TaskCompletionSource<object>();
//    public Task Task { get { return tcs.Task; } }
//    Task<int> GetPrimesCountAsync(int start, int count)
//    {
//        return Task.Run(() =>
//            ParallelEnumerable.Range(start, count).Count(n =>
//            Enumerable.Range(2, (int)Math.Sqrt(n) - 1).All(i => n % i > 0)));
//    }
//    public void DisplayPrimeCountsFrom(int i)
//    {
//        var awaiter = GetPrimesCountAsync(i * 1000000 + 2, 1000000).GetAwaiter();
//        awaiter.OnCompleted(() =>
//        {
//            Console.WriteLine(awaiter.GetResult());
//            if (++i < 10) DisplayPrimeCountsFrom(i);
//            else { Console.WriteLine("Done"); tcs.SetResult(null); }
//        });
//    }
//}

//6
//Task<int> GetPrimesCountAsync(int start, int count)
//{
//    return Task.Run(() =>
//        ParallelEnumerable.Range(start, count).Count(n =>
//        Enumerable.Range(2, (int)Math.Sqrt(n) - 1).All(i => n % i > 0)));
//}
//async Task DisplayPrimeCountsAsync()
//{
//    for (int i = 0; i < 10; i++)
//        Console.WriteLine(await GetPrimesCountAsync(i * 1000000 + 2, 1000000) +
//          " primes between " + (i * 1000000) + " and " + ((i + 1) * 1000000 - 1));
//    Console.WriteLine("Done! ");
//}

//await DisplayPrimeCountsAsync();