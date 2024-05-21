using System;


namespace Professional
{
    public class Application
    {
        public void Run()
        {
            Console.WriteLine("Welcome to the Professional Application!");
            
            bool exitRequested = false;
            while (!exitRequested)
            {
                DisplayMenu();
                exitRequested = HandleInput();
            }
        }

        private void DisplayMenu()
        {
            Console.WriteLine("\nMenu:");
            Console.WriteLine("1. Manage Training List");
            Console.WriteLine("2. Exit");
        }

        private bool HandleInput()
        {
            Console.Write("\nEnter your choice: ");
            string choice = Console.ReadLine();
            DatabaseManager dm = new DatabaseManager();
            switch (choice)
            {
                case "1":
                    dm.ConnectToDatabase();
                    ManageTrainingList();
                    return false;
                case "2":
                    Console.WriteLine("Exiting application...");
                    return true;
                default:
                    Console.WriteLine("Invalid choice. Please try again");
                    return false;
            }
        }

        private void ManageTrainingList()
        {
            Console.WriteLine("Training list management functionality will be implemented here");
        }
    }
}
