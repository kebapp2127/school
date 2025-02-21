using System.Diagnostics.Metrics;
using static System.Runtime.InteropServices.JavaScript.JSType;
int counter = 0;
List<double> numbersWithoutShortcut = new List<double>();
double removeEven(double value)
{
    double newNumber = 0;

    List<double> numbersBeforeRemoving = new List<double>();
    List<double> numbersAfterRemoving = new List<double>();
    for (; ; )
    {
        numbersBeforeRemoving.Add(Math.Floor(value / 10000));
        numbersBeforeRemoving.Add(Math.Floor(value / 1000) % 10);
        numbersBeforeRemoving.Add((Math.Floor(value / 100) % 100) % 10);
        numbersBeforeRemoving.Add((Math.Floor(value / 10) % 1000) % 10);
        numbersBeforeRemoving.Add((Math.Floor(value) % 10000) % 10);
        break;
    }
    foreach (double n in numbersBeforeRemoving)
    {
        if (n % 2 == 1)
        {
            numbersAfterRemoving.Add(n);
        }
    }
    if (numbersAfterRemoving.Count == 0)
    {
        return 0;
    }
    foreach (double n in numbersAfterRemoving)
    {
        newNumber = 10 * newNumber + n;
    }
    return newNumber;
}

foreach (string line in File.ReadLines("skrot_przyklad.txt"))
{
    double doubleLine = double.Parse(line);
    if (removeEven(doubleLine) == 0)
    {
        counter++;
        numbersWithoutShortcut.Add(doubleLine);
    }
}
Console.Write("ilość liczb bez skrótu: ");
Console.WriteLine(counter);
Console.Write("największa liczba bez skrótu: ");
Console.WriteLine(numbersWithoutShortcut.Max());


double gcd(double value1, double value2)
{
    while (value2 != 0)
    {
        double temp = value2;
        value2 = Math.IEEERemainder(value1, value2);
        value1 = temp;
    }

    return Math.Abs(value1);
}
Console.WriteLine("\nliczy których nwd liczby i skrótu jest równe 7:");
foreach (string line in File.ReadLines("skrot2_przyklad.txt"))
{
    if (gcd(double.Parse(line), removeEven(double.Parse(line))) == 7)
    {
        Console.WriteLine(line);
    }
}