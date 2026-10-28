
using LibraryManagement.Repositories;
using LibraryManagement.Services;

namespace LibraryManagement
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DatabaseHelper db = new DatabaseHelper();
            BookRepository bookRepository = new BookRepository(db);
            BookService bookService = new BookService(bookRepository);

            int choice;

            do
            {
                Console.WriteLine("\n===== Library Management System =====");
                Console.WriteLine("1. Add Book");
                Console.WriteLine("0. Exit");

                Console.Write("Enter your choice: ");

                if (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("Invalid choice.");
                    choice = -1;
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        try
                        {
                            bookService.AddBook();
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Error: " + ex.Message);
                        }
                        break;

                    case 0:
                        Console.WriteLine("Exiting...");
                        break;

                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }

            } while (choice != 0);
        }
    }
}