using MLG_Interview.Context;
using MLG_Interview.Models;

namespace MLG_Interview.Repository
{
    public interface BookRepositoryInterface
    {
        public List<Book> GetAllBooks();
        public Book GetBookByID(int id);
        public Book UpdateBook(int id, Book book);
        public void DeleteBook(int id);
        public Book InsertBook(Book book);
    }
}
