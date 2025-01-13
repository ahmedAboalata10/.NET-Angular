using MLG_Interview.Context;
using MLG_Interview.Models;

namespace MLG_Interview.Repository
{
    public class BookRepository: BookRepositoryInterface
    {
        public readonly MLG_Context mLG_Context;
        public BookRepository(MLG_Context context)
        {
            this.mLG_Context = context;
        }

        public List<Book> GetAllBooks() 
        {
            var books = mLG_Context.Books.ToList();
            return books;
        }
        public Book GetBookByID(int id)
        {
            return mLG_Context.Books.Where(b => b.Id==id).FirstOrDefault();
        }
        public Book InsertBook(Book book) 
        {
            if (book != null) 
            {
                mLG_Context.Books.Add(book);
                mLG_Context.SaveChanges();
            }
            return book;
        }
        public Book UpdateBook(int id, Book book) 
        {
            var oldbook = mLG_Context.Books.Where(x => x.Id==id).FirstOrDefault();
            if (oldbook != null) 
            {
                oldbook.Name = book.Name;
                oldbook.Category = book.Category;
            }
            mLG_Context.SaveChanges();
            return book;
        }
        public void DeleteBook(int id) 
        {
            var book =mLG_Context.Books.Where(x => x.Id==id).FirstOrDefault();
            if(book != null)
            {
                mLG_Context.Books.Remove(book);
                mLG_Context.SaveChanges();
            }
        }
    }
}
