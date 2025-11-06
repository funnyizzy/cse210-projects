
class Menu
{
    public string[] _menuString = {
        "Welcome to the journal",
        "You can create, display, save, and read journal entries",
        "1 = Create Journal Entry",
        "2 = Display Journal Entries",
        "3 = Save Journal Entries to a File",
        "4 = Read Journal Entries from a File",
        "5 = Exit"
    };
    
    public void ProcessMenu()
    {
        foreach (string menuItem in _menuString)
        {
            Console.WriteLine(menuItem);
        }
    }
}