using HotelRoom_Architecture_DataAnnotation_FluentAPI.Models;
using HotelRoomDB;
using HotelRoomDB.Data;
using HotelRoomDB.repositories;
using HotelRoomDB.Services;
//using HotelRoom_Architecture_DataAnnotation_FluentAPI;


namespace HotelRoomDB;

internal class Program
{
    private static HotelRoomManagementDBContext _context = null!;
    private static IGuestServices _guestServices = null!;
    private static IReviewServices _reviewServices = null!;
    private static IRoomServices _roomServices = null!;
    private static IReservationServices _reservationServices = null!;
    //private static IAuthService _authService = null!;
    static IAuthService _authService;

    public static string AdminCode = "123"; // Example admin code, replace with your actual admin code logic


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


        
        MainMenu();


    }


    // Wellcome Message Massage
    public static void WellcomeMessage()
    {
        Console.WriteLine("Welcome to the Hotel Room Management System!");
    }

    // Exit Message
    public static void ExitMessage()
    {
        Console.WriteLine("Thank you for using the Hotel Room Management System. Goodbye!");
    }

    // Hold the Console
    public static void HoldConsole()
    {
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
    }

    // Main Menu *****
    public static void MainMenu()
    {
        //static void Setup()
        //{
        //    var db = new HotelRoomManagementDBContext();
        //    _authService = new Services.AuthService(new GuestServices(new GuestRepo(db)), new DataEntered());
        //}



        bool showMenu = true;
        while (showMenu)
        {
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
                    _authService.SignUp();

                    break;
                case '2':
                    Console.WriteLine("\nLogin selected.");
                    // Call Login method here
                    // You can create an instance of AuthService and call SignIn method
                    bool isLoggedIn = _authService.SignIn();
                    if (isLoggedIn)
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
                                Console.WriteLine("Enter Admin Code:");
                                string adminCode = Console.ReadLine();
                                if (adminCode != "123") // Replace with your actual admin code validation
                                {
                                    Console.WriteLine("Invalid Admin Code. Access Denied.");
                                    HoldConsole();
                                }
                                else
                                {
                                    AdminMenu(); // Show Admin Menu
                                }
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
    }

    // Admin Menu
    public static void AdminMenu()
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
                    ManageGuest();
                    HoldConsole();
                    break;
                case '2':
                    ManageRoom();
                    HoldConsole();
                    break;
                case '3':
                    ManageBookings();
                    HoldConsole();
                    break;
                case '4':
                    ManageReview();
                    HoldConsole();
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
    public static void GuestMenu()
    {
        bool showGuestMenu = true;
        while (showGuestMenu)
        {
            Console.Clear();
            Console.WriteLine("Guest Menu");
            Console.WriteLine("1. View Rooms");
            Console.WriteLine("2. Book a Room");
            Console.WriteLine("3. View Guest Bookings");
            Console.WriteLine("4. Leave a Review");
            Console.WriteLine("0. Back to Main Menu");
            char choice = Console.ReadKey().KeyChar;
            switch (choice)
            {
                case '1':
                    if (_roomServices is null)
                    {
                        Console.WriteLine("Rooms service is not available. Please contact support.");
                        HoldConsole();
                    }
                    else
                    {
                        Console.WriteLine(" Rooms: ");
                        _roomServices.GetAllRooms();
                        HoldConsole();
                    }
                    break;
                case '2':
                    if (_roomServices is null)
                    {
                        Console.WriteLine("Rooms service is not available. Please contact support.");
                        HoldConsole();
                    }
                    else
                    {
                        Console.WriteLine(" Rooms: ");
                        _roomServices.GetAllRooms();

                        Console.WriteLine("======================================================");
                        int RoomID = Data.DataEntered.EnterRoomId();
                        int nights = Data.DataEntered.EnterNights();
                        DateTime checkInDate = Data.DataEntered.EnterCheckInDate();
                        string NationalID = Data.DataEntered.EnterGuestNationalID();
                        var result = _reservationServices.AddNewBooking(0, nights, checkInDate, NationalID, RoomID);
                        if (result.Ok)
                        {
                            Console.WriteLine($"\nBooking successful! Reservation ID: {result.ReservationId}");
                        }
                        else
                        {
                            Console.WriteLine($"\nBooking failed: {result.Message}");
                        }

                    }
                break;
                case '3':
                    int guestId = Data.DataEntered.EnterGuestId();

                    var bookings = _reservationServices.GetAllBookingsByGuestId(guestId);

                    if (bookings == null || !bookings.Any())
                    {
                        Console.WriteLine("No bookings found for this guest.");
                    }
                    else
                    {
                        Console.WriteLine($"\nBookings for Guest ID: {guestId}");
                        Console.WriteLine("---------------------------------------------------------");

                        foreach (var book in bookings)
                        {
                            Console.WriteLine(
                                $"Booking ID: {book.ResId}, " +
                                $"Guest: {book.Guest.Fname} {book.Guest.Lname}, " +
                                $"Room ID: {book.RoomId}, " +
                                $"Check-In: {book.CheckInDate:yyyy-MM-dd}, " +
                                $"Check-Out: {book.CheckOutDate:yyyy-MM-dd}"
                            );
                        }
                    }

                    Console.WriteLine("---------------------------------------------------------");

                    Console.WriteLine("Do you want to cancel a booking? (y/n)");
                    char cancelChoice = Console.ReadKey().KeyChar;
                    if (cancelChoice == 'y' || cancelChoice == 'Y')
                    {
                        int bookingId = Data.DataEntered.EnterReservationId();
                        int roomId = Data.DataEntered.EnterRoomId();
                        var cancelResult = _reservationServices.CancelBooking(bookingId, roomId);
                        if (cancelResult.Ok)
                        {
                            Console.WriteLine($"\nBooking with ID {cancelResult.ResID} has been cancelled successfully.");
                        }
                        else
                        {
                            Console.WriteLine($"\nCancellation failed: {cancelResult.Massage}");
                        }
                    }

                    HoldConsole();
                    break;
                case '4':
                    //int reviewId = _dataEntered.EnterReviewId();
                    int resID = Data.DataEntered.EnterReservationId();
                    string reviewText = Data.DataEntered.EnterReviewText();
                    int rating = Data.DataEntered.EnterRating();
                    _reviewServices.AddNewReview(resID, reviewText, rating);
                    HoldConsole();
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
    public static void ManageGuest()
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
               string NationalID=  Data.DataEntered.EnterGuestNationalID();
                Console.WriteLine("\nView Specific Guest Data selected.");
                var guest = _guestServices.GetGuestByNationalID(NationalID);
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
    public static void ManageRoom() 
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
                    decimal dailyRate = Data.DataEntered.EnterDailyRate();
                    bool isAvailable = Data.DataEntered.EnterRoomAvailability();
                    _roomServices.AddNewRoom(dailyRate, isAvailable);
                    Console.WriteLine("\nRoom added successfully.");
                    break;
                case '2':
                    int roomIdToDelete = Data.DataEntered.EnterRoomId();
                    _roomServices.RemoveRoom(roomIdToDelete);
                    Console.WriteLine("\nRoom deleted successfully.");
                    break;
                case '3':
                    int roomIdToUpdate = Data.DataEntered.EnterRoomId();
                    bool isReserved = Data.DataEntered.EnterRoomAvailability();
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
                    int roomIdToView = Data.DataEntered.EnterRoomId();
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

    // 3. Manage Bookings
    public static void ManageBookings()
    {
        bool showBookingMenu = true;
        while (showBookingMenu)
        {
        Console.Clear();
        Console.WriteLine("====================== Manage Bookings ======================== ");
        Console.WriteLine("1. View All Bookings");
        Console.WriteLine("2. View Specific Booking Data");
        Console.WriteLine("3. Cancel Booking");
        Console.WriteLine("0. Exist");
        char choice = Console.ReadKey().KeyChar;
            switch (choice)
            {
                case '1':
                    Console.WriteLine("\nView All Bookings selected.");
                    _reservationServices.GetAllBookings();
                    break;
                case '2':
                    int bookingId = Data.DataEntered.EnterReservationId();
                    _reservationServices.GetBookingById(bookingId);
                    break;
                case '3':
                    int bookingId1 = Data.DataEntered.EnterReservationId();
                    int roomId = Data.DataEntered.EnterRoomId();
                    _reservationServices.CancelBooking(bookingId1, roomId);
                    break;
                case '0':
                    Console.WriteLine("\nExiting Booking Management.");
                    showBookingMenu = false; // Exit the booking management menu
                    break;
                default:
                    Console.WriteLine("\nInvalid choice, please try again.");
                    HoldConsole();
                    ManageBookings(); // Show Manage Bookings menu again
                    break;
            }
        }
    }

    // 4. Manage Reviews
    public static void ManageReview()
    {
        bool showReviewMenu = true;
        while (showReviewMenu)
        {
            Console.Clear();
            Console.WriteLine("====================== Manage Reviews ======================== ");
            Console.WriteLine("1. View All Reviews");
            Console.WriteLine("2. View Specific Review Data");
            Console.WriteLine("0. Exist");
            char choice = Console.ReadKey().KeyChar;
            switch (choice)
            {
                
                case '1':
                    int bookingID;
                    Reservation reservation;
                    Console.WriteLine("\nAll Reviews:");
                    var allReviews = _reviewServices.GetAllReviews();
                    foreach (var r in allReviews)
                    {
                        bookingID = r.ResId;
                        reservation = _reservationServices.GetBookingById(bookingID);

                        Console.WriteLine(
                            $"Review ID: {r.ReviewId}, " +
                            $"Guest: {reservation.Guest.Fname} (National ID: {reservation.Guest.NationalID}), " +
                            $"Room: {reservation.RoomId}, " +
                            $"Rating: {r.Rating}, " +
                            $"Comment: {r.Comment}");
                        Console.WriteLine("====================================================");
                    }
                    HoldConsole();
                    break;
                case '2':
                    int reviewId = Data.DataEntered.EnterReviewId();
                    var review = _reviewServices.GetReviewById(reviewId);
                    Reservation reservation1;

                    var bookingID1 = review.ResId;
                    reservation1 = _reservationServices.GetBookingById(bookingID1);

                    if (review != null)
                    {
                        Console.WriteLine($"Review ID: {review.ReviewId}, Guest Name: {reservation1.Guest.Fname}, Room ID: {reservation1.Room.RoomId}, Review: {review.Comment}");
                    }
                    else
                    {
                        Console.WriteLine("Review not found.");
                    }
                    HoldConsole();
                    break;
                case '0':
                    showReviewMenu = false; // Exit the review management menu
                    break;
                default:
                    Console.WriteLine("\nInvalid choice, please try again.");
                    HoldConsole();
                    ManageReview(); // Show Manage Reviews menu again
                    break;
            }
        }
    }

    /// ================= Guest Menu =====================





}
