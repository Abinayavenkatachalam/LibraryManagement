using Microsoft.Data.SqlClient;
using LibraryManagement.Models;

namespace LibraryManagement.Repositories
{
    public class BorrowRepository
    {
        private readonly DatabaseHelper db;

        public BorrowRepository(DatabaseHelper db)
        {
            this.db = db;
        }

        public void BorrowBook(Borrow borrow)
        {
            using SqlConnection con = db.GetConnection();
            con.Open();

            string bookQuery = "SELECT COUNT(*) FROM Books WHERE BookId = @BookId";

            using SqlCommand bookCmd = new SqlCommand(bookQuery, con);
            bookCmd.Parameters.AddWithValue("@BookId", borrow.BookId);

            if ((int)bookCmd.ExecuteScalar() == 0)
            {
                throw new Exception("Book ID does not exist.");
            }

            string memberQuery = "SELECT COUNT(*) FROM Members WHERE MemberId = @MemberId";

            using SqlCommand memberCmd = new SqlCommand(memberQuery, con);
            memberCmd.Parameters.AddWithValue("@MemberId", borrow.MemberId);

            if ((int)memberCmd.ExecuteScalar() == 0)
            {
                throw new Exception("Member ID does not exist.");
            }

            string query = @"INSERT INTO BorrowRecords
                             (BookId, MemberId, BorrowDate, DueDate, Status)
                             VALUES
                             (@BookId, @MemberId, @BorrowDate, @DueDate, @Status)";

            using SqlCommand cmd = new SqlCommand(query, con);

            cmd.Parameters.AddWithValue("@BookId", borrow.BookId);
            cmd.Parameters.AddWithValue("@MemberId", borrow.MemberId);
            cmd.Parameters.AddWithValue("@BorrowDate", borrow.BorrowDate);
            cmd.Parameters.AddWithValue("@DueDate", borrow.DueDate);
            cmd.Parameters.AddWithValue("@Status", borrow.Status);

            cmd.ExecuteNonQuery();
        }
    }
}