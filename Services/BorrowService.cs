using LibraryManagement.Models;
using LibraryManagement.Repositories;

namespace LibraryManagement.Services
{
    public class BorrowService
    {
        private readonly BorrowRepository repository;

        public BorrowService(BorrowRepository repository)
        {
            this.repository = repository;
        }

        public void BorrowBook()
        {
            Borrow borrow = new Borrow();

            Console.Write("Enter Book ID: ");

            if (!int.TryParse(Console.ReadLine(), out int bookId) ||
                bookId <= 0)
            {
                Console.WriteLine("Invalid Book ID.");
                return;
            }

            Console.Write("Enter Member ID: ");

            if (!int.TryParse(Console.ReadLine(), out int memberId) ||
                memberId <= 0)
            {
                Console.WriteLine("Invalid Member ID.");
                return;
            }

            Console.Write("Enter borrowing period in days: ");

            if (!int.TryParse(Console.ReadLine(), out int days) ||
                days <= 0)
            {
                Console.WriteLine("Enter a valid number of days.");
                return;
            }

            borrow.BookId = bookId;
            borrow.MemberId = memberId;
            borrow.BorrowDate = DateTime.Today;
            borrow.DueDate = DateTime.Today.AddDays(days);
            borrow.Status = "Borrowed";

            repository.BorrowBook(borrow);

            Console.WriteLine("Book borrowed successfully!");
            Console.WriteLine("Due date: " + borrow.DueDate.ToShortDateString());
        }
    }
}