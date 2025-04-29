using FileSystem_logger.Models;
using FileSystem_logger.Service;

internal class Program
{
    private static async Task Main(string[] args)
    {
        try
        {
            IRepository<User> userRepository = new ListRepository<User>();
            IRepository<Book> bookRepository = new ListRepository<Book>();

            userRepository.Add(new User { Id = 1, Email = "ion@gmail.com", Name = "Ion", Role = UserRole.Admin });
            userRepository.Add(new User { Id = 2, Email = "dana@gmail.com", Name = "Dana" });

            bookRepository.Add(new Book { Id = 1, Author = "Mihai Malancea", Title = "Uceniciea in contextul asiatic" });
            bookRepository.Add(new Book { Id = 2, Author = "Cristian Barbosu", Title = "Biserica Verticala" });
            bookRepository.Add(new Book { Id = 1, Author = "Ioan Bunaciu", Title = "Misiunea evanghelica in contextul rural" });

            foreach (var book in bookRepository.GetAll())
            {
                Console.WriteLine(book.Title);
            }

            BookTypography bookTypography = new BookTypography(userRepository, bookRepository);
            await bookTypography.EditBookTitle(1, 1, "Uceniciea in contextul euro-asiatic");

            foreach (var book in bookRepository.GetAll())
            {
                Console.WriteLine(book.Title);
            }
        }
        catch (Exception ex)
        { 
            Console.WriteLine(ex.Message);
        }
    }
}