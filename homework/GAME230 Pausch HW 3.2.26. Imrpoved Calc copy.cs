


Console.WriteLine(
    "Write This calculator can perform 5 operations: addition (+), subtraction (-), multiplication (*), and division.");
Console.WriteLine("Please type a mathematical expression in the form of: a + b, or type \"quit\" to shut down the calculator.");

string equation = Console.ReadLine();

while (equation.ToLower() != "quit")
{
    string[] blah;
    blah = equation.Split(' ');

    bool isNumber = double.TryParse(blah[0], out double number);
    while (blah.Length != 3 || isNumber == false)
    {
        Console.WriteLine("Try again, shawty. Mama hasn't hear of that one.");
        equation = Console.ReadLine();
        equation = equation.ToLower();
        blah = equation.Split(' ');
        isNumber = double.TryParse(blah[0], out double number1);

        if (equation == "quit")
        {
            Console.WriteLine("Good bye!");
            return;
        }
    }
    
    equation = equation.ToLower();
    blah = equation.Split(' ');
    double a = double.Parse(blah[0]);
    double b = double.Parse(blah[2]);
    
    if (b == 0 && blah[1] == "/" || b == 0 && blah[1] == "%")
    {
        Console.WriteLine("Do you know how math works?");
    }
    
    else if (blah[1] == "/")
    {
        Console.WriteLine(a / b);
    }
    else if (blah[1] == "+")
    {
        Console.WriteLine(a + b);
    }
    else if (blah[1] == "-")
    {
        Console.WriteLine(a - b);
    }
    else if (blah[1] == "*")
    {
        Console.WriteLine(a * b);
    }
    else if (blah[1] == "%")
    {
        Console.WriteLine(a % b);
    }
    else
    {
        Console.WriteLine("Try again, shawty");
    }
    
    Console.WriteLine("Please type a mathematical expression, or type \"quit\" to shut down the calculator.");
    equation = Console.ReadLine();
    equation = equation.ToLower();
}

Console.WriteLine("Fine, bitch. See you later. :P");