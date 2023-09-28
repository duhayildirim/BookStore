using BookStore.DBOperations;
using System;
using System.Linq;

namespace BookStore.BookOperations.DeleteBook
{
    public class DeleteBookCommand
    {
        private readonly BookStoreDbContext _dbContext;
        public int bookId { get; set; }

        public DeleteBookCommand(BookStoreDbContext context) 
        {
            _dbContext = context;
        }

        public void Handle() 
        {
            var book = _dbContext.Books.SingleOrDefault(book => bookId == book.Id);

            if (book is null)
            {
                throw new InvalidOperationException("Silme başarısız. Kitap mevcut değil.");
            }
            else
            {
                _dbContext.Books.Remove(book);
                _dbContext.SaveChanges();
            }
        }
    }
}
