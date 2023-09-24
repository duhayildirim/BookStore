using BookStore.DBOperations;
using System;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace BookStore.BookOperations.GetBooks
{
    public class GetBooksQuery
    {
        private readonly BookStoreDbContext _dbContext;

        public GetBooksQuery(BookStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Book> Handle() 
        {
            var bookList = _dbContext.Books.OrderBy(x => x.Id).ToList<Book>();

            return bookList;
        }
    }

    public class BooksViewModel
    {
        public string Title { get; set; }

        public int PageCount { get; set; }

        public DateTime PublishDate { get; set; }
    }
}
