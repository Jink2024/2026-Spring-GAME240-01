//namespace PauschHWApril28;
string fishmongerLog = " ";
string specialName = " ";
int totalFish = 0;
int totalSpecialFish = 0;
string specialFileName = " ";
string fishmongerFileName = " ";
// Making sure the file exists in the while loop and putting the content
// in the files (named by the user) into variables
while (!File.Exists(fishmongerFileName))
{
    Console.WriteLine("What is the file path for your fishmonger log?");
    fishmongerFileName = Console.ReadLine();
    try
    {
        StreamReader fishmongerFile = new StreamReader(fishmongerFileName);
        fishmongerLog = fishmongerFile.ReadToEnd();
    }
    
    catch (Exception ex)
    {
        fishmongerLog = " ";
    }
}

while (!File.Exists(specialFileName))
{
    Console.WriteLine("What is the file path for the special of the day?");
    specialFileName = Console.ReadLine();
try
    {
        StreamReader specialFile = new StreamReader(specialFileName);
        specialName = specialFile.ReadLine();
    }
    catch (Exception ex)
    {
        specialName = " ";
    }
}
// taking the variables we created, that now have the (confirmed existing)
// text information inside, we can use them

//trim the fat first
specialName = specialName.Trim();

// put the text content into an array so we can find the fish name
string[] specialArray =  specialName.Split(" ");
specialName = specialArray[^1];

//trim the fat first
fishmongerLog = fishmongerLog.Trim();

// put the text content into an array, and split it by line
string[] fishmongerLogArray = fishmongerLog.Split("\n");

// if the new line contains the special fish, add it to totalSpecialFish variable
foreach (string fishmongerLogNewLine in fishmongerLogArray)
{
    //splitting the line by space
    string[] newWordInCurrentLine = fishmongerLogNewLine.Split(" ");
    //put the first item in this new array (just the current line) into an integer, since it will always be a #
    int firstNumberInCurrentLine = int.Parse(newWordInCurrentLine[0]);
    // just naming the fish name so we can check if its the special fish or nah
    string currentFishName = newWordInCurrentLine[1];
    
    // if it is the special fish, add the number of it to that total
    if (currentFishName == specialName)
    {
        totalFish = totalFish + firstNumberInCurrentLine;
        totalSpecialFish = totalSpecialFish + firstNumberInCurrentLine;
    }

    if (currentFishName != specialName)
    {
        totalFish = totalFish + firstNumberInCurrentLine;
    }
}

Console.WriteLine($"Today's Special is: {specialName}");
Console.WriteLine($"Total Special fish: {totalSpecialFish}");
Console.WriteLine($"Total fish: {totalFish}");








