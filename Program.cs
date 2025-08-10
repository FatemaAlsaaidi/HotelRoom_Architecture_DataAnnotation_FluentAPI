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

        // Admin Menu
        public void AdminMenu()
        {
            bool showAdminMenu = true;
            while (showAdminMenu)
            {

                Console.Clear();
                Console.WriteLine("Admin Menu");
                Console.WriteLine("1. Manage Users");
                Console.WriteLine("2. Manage Rooms");
                Console.WriteLine("3. Manage Bookings");
                Console.WriteLine("4. Manage Reviews");
                Console.WriteLine("0. Back to Main Menu");
                char choice = Console.ReadKey().KeyChar;
                switch (choice)
                {
                    case '1':
                        Console.WriteLine("\nManage Users selected.");
                        // Call Manage Users method here
                        break;
                    case '2':
                        Console.WriteLine("\nManage Rooms selected.");
                        // Call Manage Rooms method here
                        break;
                    case '3':
                        Console.WriteLine("\nManage Bookings selected.");
                        // Call Manage Bookings method here
                        break;
                    case '4':
                        Console.WriteLine("\nManage Reviews selected.");
                        // Call Manage Reviews method here
                        break;
                    case '0':
                        showAdminMenu = false; // Exit the admin menu
                        break;
                    default:
                        Console.WriteLine("\nInvalid choice, please try again.");
                        HoldConsole();
                        AdminMenu(); // Show Admin Menu again
                        break;
                }
            }
        }



    }
}
