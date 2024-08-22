using Library.Core.Models;

namespace Library.Core
{
    public class LibraryService : ILibraryService
    {
        private readonly ILibraryRepository _libraryRepository;
        public LibraryService(ILibraryRepository libraryRepository)
        {
            _libraryRepository = libraryRepository;
        }
        public async Task AddLibraryItem(LibraryItem item)
        {
            if (item is Book)
                await _libraryRepository.AddBook(item as Book);
            else
                await _libraryRepository.AddMagazine(item as Magazine);
        }

        public Task<Book> GetBookById(int libraryItemId)
        {
            return _libraryRepository.GetBookById(libraryItemId);
        }

        public async Task<LibraryItem> GetLibraryItemById(int libraryItemId)
        {
            List<Book> allBooks = await _libraryRepository.GetAllBooks();
            List<Magazine> allMagazines = await _libraryRepository.GetAllMagazines();

            List<LibraryItem> allItems = new List<LibraryItem>(allBooks);
            allItems.AddRange(allMagazines);

            foreach(LibraryItem item in allItems)
            {
                if (item.LibraryItemId == libraryItemId)
                    return item;
            }
            return null;
        }
    }
    public interface ILibraryService
    {
        Task AddLibraryItem(LibraryItem item);
        Task<LibraryItem> GetLibraryItemById(int libraryItemId);
        Task<Book> GetBookById(int libraryItemId);
    }
}
