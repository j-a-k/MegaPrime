// See https://aka.ms/new-console-template for more information
//no error check here as not clear this is needed
Console.WriteLine("Enter max");
var result = Console.ReadLine();
var max = uint.Parse(result);
var megaprimes = MegaPrime.MegaPrimeChecker.GetMegaPrimes(max);
megaprimes.ForEach(Console.WriteLine);
Console.WriteLine("done");
