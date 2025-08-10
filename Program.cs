using HotelRoomDB;
using HotelRoomDB.Data;
using HotelRoomDB.repositories;
using HotelRoomDB.Services;
//using HotelRoomDB.Data;
//using HotelRoom_Architecture_DataAnnotation_FluentAPI;


namespace HotelRoomDB;

internal class Program
{
    private static HotelRoomManagementDBContext _context = null!;
    private static IGuestServices _guestServices = null!;
    private static IReviewServices _reviewServices = null!;
    private static IRoomServices _roomServices = null!;
    private static IReservationServices _reservationServices = null!;
    private static AuthService _authService = null!;
    private static IDataEntered _dataEntered = null!;


    static void Main(string[] args)
    {
        //to create new object of HotelDbContext ...
        using HotelRoomManagementDBContext context = new HotelRoomManagementDBContext();
        //to make sure that DB created ...
        bool isCreated = context.Database.EnsureCreated();
        if (isCreated)
        {
            Console.WriteLine("Database has been created successfully.");
        }
        else
        {
            Console.WriteLine("Database already exists.");
        }

        // Create an instance of the Guest class to access its methods
        IGuestRepo guestRepo = new GuestRepo(context);
        IGuestServices guestServices = new GuestServices(guestRepo);

        // Create an instance of the Review class to access its methods
        IReviewRepo reviewRepo = new ReviewRepo(context);
        IReviewServices reviewServices = new ReviewServices(reviewRepo);

        // Create an instance of the Room class to access its methods
        IRoomRepo roomRepo = new RoomRepo(context);
        IRoomServices roomServices = new RoomServices(roomRepo);

        // Create an instance of the Reservation class to access its methods
        IReservationRepo reservationRepo = new ReservationRepo(context);
        IReservationServices reservationServices = new ReservationServices(reservationRepo);
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

    // Main Menu *****
    public void MainMenu()
    {
        AuthService authService = new AuthService(new GuestServices(new GuestRepo(new HotelRoomManagementDBContext())));

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
                // You can create an instance of AuthService and call SignUp method
                authService.SignUp();

                break;
            case '2':
                Console.WriteLine("\nLogin selected.");
                // Call Login method here
                // You can create an instance of AuthService and call SignIn method
                bool isLoggedIn = authService.SignIn();
                if(isLoggedIn)
                {
                    Console.WriteLine("Login successful!");
                    // After successful login, show the user menu
                    Console.WriteLine("1. Admin Menu");
                    Console.WriteLine("2. Guest Menu");
                    Console.WriteLine("0. Exit");
                    char userChoice = Console.ReadKey().KeyChar;
                    switch (userChoice)
                    {
                        case '1':
                            AdminMenu(); // Show Admin Menu
                            break;
                        case '2':
                            GuestMenu(); // Show Guest Menu
                            break;
                        case '0':
                            showMenu = false; // Exit the loop
                            break;
                        default:
                            Console.WriteLine("\nInvalid choice, please try again.");
                            HoldConsole();
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Login failed. Please try again.");
                }
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


    // Guest Menu
    public void GuestMenu()
    {
        bool showGuestMenu = true;
        while (showGuestMenu)
        {
            Console.Clear();
            Console.WriteLine("Guest Menu");
            Console.WriteLine("1. View Rooms");
            Console.WriteLine("2. Book a Room");
            Console.WriteLine("3. View Bookings");
            Console.WriteLine("4. Leave a Review");
            Console.WriteLine("0. Back to Main Menu");
            char choice = Console.ReadKey().KeyChar;
            switch (choice)
            {
                case '1':
                    Console.WriteLine("\nView Rooms selected.");
                    // Call View Rooms method here
                    break;
                case '2':
                    Console.WriteLine("\nBook a Room selected.");
                    // Call Book a Room method here
                    break;
                case '3':
                    Console.WriteLine("\nView Bookings selected.");
                    // Call View Bookings method here
                    break;
                case '4':
                    Console.WriteLine("\nLeave a Review selected.");
                    // Call Leave a Review method here
                    break;
                case '0':
                    showGuestMenu = false; // Exit the guest menu
                    break;
                default:
                    Console.WriteLine("\nInvalid choice, please try again.");
                    HoldConsole();
                    GuestMenu(); // Show Guest Menu again
                    break;
            }
        }
    }

    /// ================= Admin Menu=====================
    // 1. Manage Guest
    public void ManageGuest()
    {
        Console.WriteLine("====================== Manage Guest ======================== ");
        Console.WriteLine("1. View All Guest");
        Console.WriteLine("2. View Specidic Guest Data");
        Console.WriteLine("0. Exist");

        char choice = Console.ReadKey().KeyChar;
        switch (choice)
        {
            case '1':
                Console.WriteLine("\nView All Guest selected.");
                _guestServices.GetAllGuest();
                HoldConsole();
                break;
            case '2':
               int GuestID =  _dataEntered.EnterGuestId();
                Console.WriteLine("\nView Specific Guest Data selected.");
                var guest = _guestServices.GetGuestById(GuestID);
                if (guest != null)
                {
                    Console.WriteLine($"Guest ID: {guest.GuestId}, Name: {guest.Fname} {guest.Lname}, National ID: {guest.NationalID}, Phone: {guest.Phone}");
                }
                else
                {
                    Console.WriteLine("Guest not found.");
                }
                HoldConsole();
                break;
        }


    } 
    // 2. Manage Rooms
    public void ManageRoom() 
    {
        bool showRoomMenu = true;
        while (showRoomMenu)
        { 
            Console.WriteLine("========= Room Management ===============");
            Console.WriteLine();
            Console.WriteLine("1. Add Room");
            Console.WriteLine("2. Delete Room");
            Console.WriteLine("3. Update Room Daily Rate");
            Console.WriteLine("4. View All Rooms");
            Console.WriteLine("5. View Room By ID");
            Console.WriteLine("0. Exist");
            char choice = Console.ReadKey().KeyChar;
            switch (choice)
            {
                case '1':
                    decimal dailyRate = _dataEntered.EnterDailyRate();
                    bool isAvailable = _dataEntered.EnterRoomAvailability();
                    _roomServices.AddNewRoom(dailyRate, isAvailable);
                    Console.WriteLine("\nRoom added successfully.");
                    break;
                case '2':
                    int roomIdToDelete = _dataEntered.EnterRoomId();
                    _roomServices.RemoveRoom(roomIdToDelete);
                    Console.WriteLine("\nRoom deleted successfully.");
                    break;
                case '3':
                    int roomIdToUpdate = _dataEntered.EnterRoomId();
                    bool isReserved = _dataEntered.EnterRoomAvailability();
                    _roomServices.UpdateRoom(roomIdToUpdate, isReserved);
                    Console.WriteLine("\nRoom updated successfully.");
                    break;
                case '4':
                    Console.WriteLine("\nAll Rooms:");
                    var allRooms = _roomServices.GetAllRooms();
                    foreach (var r in allRooms)
                    {
                        Console.WriteLine($"Room ID: {r.RoomId}, Daily Rate: {r.DailyRate}, Is Reserved: {r.IsReserved}");
                        Console.WriteLine("====================================================");
                    }
                    HoldConsole();
                    break;
                case '5':
                    int roomIdToView = _dataEntered.EnterRoomId();
                    var room = _roomServices.GetRoomByID(roomIdToView);
                    if (room != null)
                    {
                        Console.WriteLine($"Room ID: {room.RoomId}, Daily Rate: {room.DailyRate}, Is Reserved: {room.IsReserved}");
                    }
                    else
                    {
                        Console.WriteLine("Room not found.");
                    }
                    HoldConsole();
                    break;

                case '0':
                    showRoomMenu = false; // Exit the room management menu
                    Console.WriteLine("\nExiting Room Management.");
                    break;
            }


        }
    
    }

    // 





}
