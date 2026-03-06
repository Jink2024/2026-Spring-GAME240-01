using System;
// Question 1
int y;
y = 0;
while (y < 5)
{
    y = y + 1;
    Console.WriteLine(y);
}
// Question 2
int z;
z = 99;
while (z < 150)
{
    z = z + 1;
    Console.WriteLine(z);
}
// Question 3
int a;
a = -2;
while (a < 100)
{
    a = a + 2;
    Console.WriteLine(a);
}
// Question 4
int b;
b = 21;
while (b > -20)
{
    b = b - 1;
    Console.WriteLine(b);
}
// Question 5
int c;
c = -2;
while (c < 100)
{
    c = c + 3;
    Console.WriteLine(c);
}
// Question 6
int d;
d = 1;
while (d < 1024)
{
    Console.WriteLine(d);
    d = d * 2;
}

// Question 7

string response;
do
{
    Console.WriteLine("Do you want to end the loop?");
    response = Console.ReadLine();
} while (response == "no");

// Question 8
// I REALLY DIDNT WANT THIS TO BE INFINITE if i did i would write:
// while (g = 7)
int g = 7;
while (g < 100)
{
    g = g + 1;
    Console.WriteLine("True");
    Console.WriteLine("False");
}

// Question 9
int h;
h = -1;
int i;
i = 0;
while (h < 20)
{
    h = h + 2;
    Console.WriteLine($"{h} is odd");
    i = i + 2;
    Console.WriteLine($"{i} is even");
}

// Question 10
// Like this?
string[] Shakespeare = ["once", "upon", "a", "midnight", "dreary"];
Shakespeare[0] = "once";
int j;
j = -2;
while (j < 3)
{
    j = j + 1;
    Console.WriteLine(Shakespeare[j +1]);
}