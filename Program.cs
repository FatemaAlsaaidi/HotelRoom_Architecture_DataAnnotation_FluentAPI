namespace HotelRoom_Architecture_DataAnnotation_FluentAPI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }

        // Wellcome Message Massage
        public void WellcomeMessage()
        {
            Console.WriteLine("Welcome to the Hotel Room Management System!");
        }

        // Exit Message
        public void ExitMessage()
        {
            Console.WriteLine("Thank you for using the Hotel Room Management System. Goodbye!");
        }

        // Hold the Console
        public void HoldConsole()
        {
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        // Main Menu
        public void MainMenu()
        {
            bool showMenu = true;   
            while (showMenu)
            Console.Clear();
            WellcomeMessage();
            Console.WriteLine("=========================================");
            Console.WriteLine("Please select an option:");
            Console.WriteLine("1. Sign Up");
            Console.WriteLine("2. Login ");
            Console.WriteLine("0. Exit");
            char choice = Console.ReadKey().KeyChar;

            switch (choice) 
            { 
                case '1':
                    Console.WriteLine("\nSign Up selected.");
                    // Call Sign Up method here
                    break;
                case '2':
                    Console.WriteLine("\nLogin selected.");
                    // Call Login method here
                    break;
                case '0':
                    Console.WriteLine("\nExiting the application.");
                    ExitMessage();
                    HoldConsole();
                    showMenu = false; // Exit the loop
                    break;
            }
        }



    }
}
