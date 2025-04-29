using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileSystem_logger.Models;

namespace FileSystem_logger.Service
{
    internal class BookTypography
    {
        private IRepository<User> _userRepository;
        private IRepository<Book> _bookRepository;

        public BookTypography(IRepository<User> userRepository, IRepository<Book> bookRepository)
        {
            _userRepository = userRepository;
            _bookRepository = bookRepository;
        }

        public async Task<Book> EditBookTitle(int userId, int bookId, string editedTitle)
        {
            string action = $"{nameof(BookTypography)}.{nameof(EditBookTitle)}";

            User user = _userRepository.GetById(userId);
            if (user == null)
                await Fail(action, "User not found!");

            Book book = _bookRepository.GetById(bookId);
            if (book == null)
                await Fail(action, "Book not found!");

            if (user.Role != UserRole.Admin)
                await Fail(action, "User doesn't have permission to edit the title of a book!");

            if (string.IsNullOrWhiteSpace(editedTitle))
                await Fail(action, "Title cannot be empty.");

            book.Title = editedTitle;
            _bookRepository.Update(book);
            await FileLogger.Log(action, "success");

            return book;
        }

        private async Task Fail(string method, string message)
        {
            await FileLogger.Log(method, "failure");
            throw new CustomException(message);
        }
    }

}
