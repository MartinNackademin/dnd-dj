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
    private double actionSpeed = 1,3;

    static void Main(string[] args)
    {
        Console.WriteLine("Hello, Welcome to bard autoplay made by Martin Mohns!");
        Console.WriteLine("Press any Key to continue");
        Console.ReadKey();
        Console.Clear();

        // Call the method to monitor key presses
        Menu();
    }

    static void Menu()
    {
        Console.WriteLine("Press 1 to start AutoPlay");
        Console.WriteLine("Press 2 to change Manual Dextery");
        var userInput = Console.ReadKey();

        switch (key.Key)
        {
            case ConsoleKey.D1:
                StartAutoPlay();
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

    static void MonitorKeyPresses()
    {
        Console.WriteLine("Press 'E' or 'Q' to test key presses. Press 'Esc' to exit.");

        while (true)
        {
            // Check if 'E' key is pressed
            if ((GetAsyncKeyState(VK_E) & 0x8000) != 0)
            {
                Console.WriteLine("E key pressed");
            }

            // Check if 'Q' key is pressed
            if ((GetAsyncKeyState(VK_Q) & 0x8000) != 0)
            {
                Console.WriteLine("Q key pressed");
            }

            // Check if 'Esc' key is pressed to exit the loop
            if ((GetAsyncKeyState((int)ConsoleKey.Escape) & 0x8000) != 0)
            {
                break;
            }

            // Sleep for a short period to reduce CPU usage
            Thread.Sleep(100);
        }
    }
}