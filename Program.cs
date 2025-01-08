using System;
using System.Runtime.InteropServices;
using System.Threading;

class Program
{
    // Import the GetAsyncKeyState function from user32.dll
    [DllImport("user32.dll")]
    private static extern short GetAsyncKeyState(int vKey);

    // Virtual key codes for 'E' and 'Q'
    private const int VK_E = 0x45;
    private const int VK_Q = 0x51;

    // The speed at which the songs are performed, found in Dark and Darker character sheet. Capped at 50%
    private static double manualDexterity = 1.3;

    static void Main(string[] args)
    {
        Console.WriteLine("Hello, Welcome to bard autoplay made by Martin Mohns!");
        Console.WriteLine("Press any Key to continue");
        Console.ReadKey(); Console.Clear(); Menu();
    }

    static void Menu()
    {
        Console.Clear();
        Console.WriteLine("Press 1 to start AutoPlay");
        Console.WriteLine("Press 2 to change Manual Dextery");

        var userInput = Console.ReadKey();

        switch (userInput.Key)
        {
            case ConsoleKey.D1:
                break;
            case ConsoleKey.D2:
                ChangeManualDexterity();
                break;
            default:
                Console.WriteLine("Invalid selection. Please try again.");
                Menu(); // Show the menu again
                break;
        }
    }

    static void ChangeManualDexterity()
    {
        Console.Clear();
        Console.WriteLine("Enter the manual dexterity," +
                          "this can be found in game on your" +
                          " character sheet as a percentage (1-50):");

        while (true)
        {
            string input = Console.ReadLine();


            if (double.TryParse(input, out double newManualDexterity) && newManualDexterity >= 1 && newManualDexterity <= 50)
            {
                manualDexterity = (newManualDexterity / 100) + 1;
                Console.WriteLine($"Manual dexterity set to {(manualDexterity*100)-100}%");
                Console.ReadKey();
                Menu();
                break; 
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a number between 1 and 50:");
            }
        }
    }

}