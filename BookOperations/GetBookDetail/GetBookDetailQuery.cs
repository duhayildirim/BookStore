using BookStore.DBOperations;
using System.Collections.Generic;
using System.Linq;
using BookStore.Common;
using System;

namespace BookStore.BookOperations.GetBookDetail
{
    public class GetBookDetailQuery
    {
        private readonly BookStoreDbContext _dbContext;
        public int bookId { get; set; }

        public GetBookDetailQuery(BookStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public BookDetailViewModel Handle()
        {
            var book = _dbContext.Books.Where(book => book.Id == bookId).SingleOrDefault();
            if (book is null)
            {
                throw new InvalidOperationException("Kitap bulanamadı.");
            }
            else
            {
                BookDetailViewModel vm = new BookDetailViewModel();
                vm.Title = book.Title;
                vm.PageCount = book.PageCount;
                vm.Genre = ((GenreEnum)book.GenreId).ToString();
                vm.PublishDate = book.PublishDate.Date.ToString("dd/MM/yy");

                return vm;
            }
        }
    }

    public class BookDetailViewModel
    {
        public string Title { get; set; }

        public int PageCount { get; set; }

        public string Genre { get; set; }

        public string PublishDate { get; set; }
    }
}
