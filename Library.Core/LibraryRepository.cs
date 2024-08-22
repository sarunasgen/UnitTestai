using Library.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Core
{
    public class LibraryRepository : ILibraryRepository
    {
        private readonly string _connectionString;
        public LibraryRepository(string connectionString)
        {
            _connectionString = connectionString;
        }
        public async Task AddBook(Book book)
        {

        }
        public async Task AddMagazine(Magazine magazine)
        {

        }

        public Task<List<Book>> GetAllBooks()
        {
            throw new NotImplementedException();
        }

        public Task<List<Magazine>> GetAllMagazines()
        {
            throw new NotImplementedException();
        }

        public Task<Book> GetBookById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Magazine> GetMagazineById()
        {
            throw new NotImplementedException();
        }
    }
    public interface ILibraryRepository
    {
        Task AddBook(Book book);
        Task AddMagazine(Magazine magazine);
        Task<List<Book>> GetAllBooks();
        Task<List<Magazine>> GetAllMagazines();
        Task<Book> GetBookById(int id);
        Task<Magazine> GetMagazineById();

    }
}
