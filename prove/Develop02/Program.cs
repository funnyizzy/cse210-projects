using System;

class Program
{
    static void Main(string[] args)
    {
        Menu journalMenu = new Menu();

        int userSelection;

        bool done = false;

        do
        {
            userSelection = journalMenu.ProcessMenu();

            switch (userSelection)
            {
                case 1:
                    Console.WriteLine("Creating new Journal Entry.");
                    break;
                case 2:
                    Console.WriteLine("Displaying Journal Entries.");
                    break;
                case 3:
                    Console.WriteLine("Saving Journal Entries to a File.");
                    break;
                case 4:
                    Console.WriteLine("Reading Journal Entries from a File.");
                    break;
                case 5:
                    Console.WriteLine("Exiting.");
                    done = true;
                    break;
                }
            } while (!done);

    }

}