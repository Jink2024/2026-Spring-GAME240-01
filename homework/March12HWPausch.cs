
int[] number = [33, 44, 55, 66, 21];
// sum the numbers in the array ???
int biggest;
int smallest;

if (number[0] > number[1] && number[0] > number[2] && number[0] > number[3] && number[0] > number[4])
{
    Console.WriteLine("the biggest number is", number[0]);
}
if (number[1] > number[0] && number[1] > number[2] && number[1] > number[3] && number[1] > number[4])
{
    Console.WriteLine($"the biggest number is",number[1]);
}
if (number[2] > number[0] && number[2] > number[1] && number[2] > number[3] && number[2] > number[4])
{
    Console.WriteLine($"the biggest number is",number[2]);
}
if (number[3] > number[0] && number[3] > number[1] && number[3] > number[2] && number[3] > number[4])
{
    Console.WriteLine($"the biggest number is",number[3]);
}
if (number[4] > number[0] && number[4] > number[1] && number[4] > number[2] && number[4] > number[3])
{
    Console.WriteLine($"the biggest number is",number[4]);
}

if (number[0] < number[1] && number[0] < number[2] && number[0] < number[3] && number[0] < number[4])
{
    Console.WriteLine($"the smallest number is", number[0]);
}
if (number[1] < number[0] && number[1] < number[2] && number[1] < number[3] && number[1] < number[4])
{
    Console.WriteLine($"the smallest number is",number[1]);
}
if (number[2] < number[0] && number[2] < number[1] && number[2] < number[3] && number[2] < number[4])
{
    Console.WriteLine($"the smallest number is",number[2]);
}
if (number[3] < number[0] && number[3] < number[1] && number[3] < number[2] && number[3] < number[4])
{
    Console.WriteLine($"the smallest number is",number[3]);
}
if (number[4] < number[0] && number[4] < number[1] && number[4] < number[2] && number[4] < number[3])
{
    Console.WriteLine($"the smallest number is",number[4]);
}