using BookStore.DBOperations;
using System.Collections.Generic;
using System.Linq;
using BookStore.Common;
using System;
using AutoMapper;

namespace BookStore.BookOperations.GetBookDetail
{
    public class GetBookDetailQuery
    {
        private readonly BookStoreDbContext _dbContext;
        private readonly IMapper _mapper;
        public int bookId { get; set; }

        public GetBookDetailQuery(BookStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
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
                BookDetailViewModel vm = _mapper.Map<BookDetailViewModel>(book);

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
