using LibraryManagement.Models;
using LibraryManagement.Repositories;

namespace LibraryManagement.Services
{
    public class BookService
    {
        private readonly BookRepository repository;

        public BookService(BookRepository repository)
        {
            this.repository = repository;
        }

        public void AddBook()
        {
            Book book = new Book();

            Console.Write("Enter book title: ");
            book.Title = Console.ReadLine() ?? "";

            Console.Write("Enter author name: ");
            book.Author = Console.ReadLine() ?? "";

            if (string.IsNullOrWhiteSpace(book.Title) ||
                string.IsNullOrWhiteSpace(book.Author))
            {
                Console.WriteLine("Title and author cannot be empty.");
                return;
            }

            Console.Write("Enter book price: ");

            if (!decimal.TryParse(Console.ReadLine(), out decimal price) ||
                price <= 0)
            {
                Console.WriteLine("Enter a valid price greater than zero.");
                return;
            }

            book.Price = price;

            repository.AddBook(book);

            Console.WriteLine("Book added successfully!");
        }
    }
}