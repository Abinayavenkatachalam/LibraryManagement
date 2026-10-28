using Microsoft.Data.SqlClient;
using LibraryManagement.Models;

namespace LibraryManagement.Repositories
{
    public class BookRepository
    {
        private readonly DatabaseHelper db;

        public BookRepository(DatabaseHelper db)
        {
            this.db = db;
        }

        public void AddBook(Book book)
        {
            using SqlConnection con = db.GetConnection();

            string query = @"INSERT INTO Books (Title, Author, Price)
                             VALUES (@Title, @Author, @Price)";

            using SqlCommand cmd = new SqlCommand(query, con);

            cmd.Parameters.AddWithValue("@Title", book.Title);
            cmd.Parameters.AddWithValue("@Author", book.Author);
            cmd.Parameters.AddWithValue("@Price", book.Price);

            con.Open();
            cmd.ExecuteNonQuery();
        }
    }
}