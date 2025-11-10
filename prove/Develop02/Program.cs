using System;

class Program
{
    /* list of premade prompts for journal entries */
    private static string[] _prompts = {
        "What was the highlight of your day?",
        "What was the worst part of your day?",
        "What did you do today?",
        "Did you face any challenges today? How did you handle them?",
    };

    static void Main(string[] args)
    {
        Menu menu = new Menu();
        Journal journal = new Journal();
        Random rand = new Random();

        bool running = true;

        while (running)
        {
            int choice = menu.ProcessMenu();

            if (choice == 1)
            {
                Console.WriteLine("\nCreating a new journal entry...");
                string prompt = _prompts[rand.Next(_prompts.Length)];
                Console.WriteLine("Prompt: " + prompt);
                Console.Write("Your response: ");
                string response = Console.ReadLine();

                Entry entry = new Entry();
                entry.CreateEntry(DateTime.Now.ToString("yyyy-MM-dd"), prompt, response);
                journal.AddEntry(entry);

                Console.WriteLine("Entry saved in memory.\n");
            }
            else if (choice == 2)
            {
                Console.WriteLine("\nDisplaying journal entries...\n");
                journal.Display();
            }
            else if (choice == 3)
            {
                Console.WriteLine("\nSaving journal entries to file...");
                journal.SaveToFile();
            }
            else if (choice == 4)
            {
                Console.WriteLine("\nLoading journal entries from file...");
                journal.ReadFromFile();
            }
            else if (choice == 5)
            {
                Console.WriteLine("Goodbye!");
                running = false;
            }
        }
    }
}
