using AutoMapper;
using BookStore.BookOperations.GetBookDetail;
using BookStore.Common;
using BookStore.DBOperations;
using System;
using System.Linq;

namespace BookStore.BookOperations.UpdateBook
{
    public class UpdateBookCommand
    {
        private readonly BookStoreDbContext _dbContext;
        public int bookId { get; set; }
        public UpdateBookModel Model { get; set; }

        public UpdateBookCommand(BookStoreDbContext context) 
        {
            _dbContext = context;
        }

        public void Handle()
        {
            var book = _dbContext.Books.SingleOrDefault(book => bookId == book.Id);

            if (book is null)
            {
                throw new InvalidOperationException("Güncelleme başarısız. Kitap bulunamadı.");
            }
            else
            {
                book.GenreId = Model.GenreId != default ? Model.GenreId : book.GenreId;
                book.PageCount = Model.PageCount != default ? Model.PageCount : book.PageCount;
                book.PublishDate = Model.PublishDate != default ? Model.PublishDate : book.PublishDate;
                book.Title = Model.Title != default ? Model.Title : book.Title;

                _dbContext.SaveChanges();
            }
        }
    }

    public class UpdateBookModel
    {
        public string Title { get; set; }

        public int GenreId { get; set; }

        public int PageCount { get; set; }

        public DateTime PublishDate { get; set; }
    }
}
