using Library.Core;
using Library.Core.Models;
using Moq;

namespace Library.Tests
{
    public class LibraryTests
    {
        [Fact]
        public void AddLibraryItemTest_Book()
        {
            //Arrange
            Mock<ILibraryRepository> _libraryRepository = new Mock<ILibraryRepository>();

            ILibraryService libraryService = new LibraryService(_libraryRepository.Object);

            Book book1 = new Book
            {
                Title = "Book 1",
                Author = "John Doe",
                LibraryItemId = 11,
            };
            //Act
            libraryService.AddLibraryItem(book1);
            //Assert
            _libraryRepository.Verify(x => x.AddBook(It.IsAny<Book>()), Times.Once);
            _libraryRepository.Verify(x => x.AddMagazine(It.IsAny<Magazine>()), Times.Never);
        }
        [Fact]
        public void AddLibraryItemTest_Magazine()
        {
            //Arrange
            Mock<ILibraryRepository> _libraryRepository = new Mock<ILibraryRepository>();

            ILibraryService libraryService = new LibraryService(_libraryRepository.Object);

            Magazine magazine = new Magazine
            {
                Title = "Magainze 1",
                ReleaseDate = DateTime.Now,
                LibraryItemId = 33,
            };
            //Act
            libraryService.AddLibraryItem(magazine);
            //Assert
            _libraryRepository.Verify(x => x.AddBook(It.IsAny<Book>()), Times.Never);
            _libraryRepository.Verify(x => x.AddMagazine(It.IsAny<Magazine>()), Times.Once);
        }
        [Fact]
        public async Task GetLibraryItemByIdTest_BookAsync()
        {
            //Arrange
            Magazine magazine1 = new Magazine
            {
                Title = "Magainze 1",
                ReleaseDate = DateTime.Now,
                LibraryItemId = 33,
            };
            Book book1 = new Book
            {
                Title = "Book 1",
                Author = "John Doe",
                LibraryItemId = 11,
            };
            Magazine magazine2 = new Magazine
            {
                Title = "Magainze 2",
                ReleaseDate = DateTime.Now,
                LibraryItemId = 48,
            };
            Book book2 = new Book
            {
                Title = "Book 1",
                Author = "John Doe",
                LibraryItemId = 19,
            };

            Mock<ILibraryRepository> _libraryRepository = new Mock<ILibraryRepository>();
            List<Book> books = new List<Book>();
            books.Add(book1);
            books.Add(book2);

            List<Magazine> magazines = new List<Magazine>();
            magazines.Add(magazine1);
            magazines.Add(magazine2);
            _libraryRepository.Setup(x => x.GetAllBooks().Result).Returns(books);
            _libraryRepository.Setup(x => x.GetAllMagazines().Result).Returns(magazines);

            ILibraryService libraryService = new LibraryService(_libraryRepository.Object);

            //Act
            LibraryItem item = await libraryService.GetLibraryItemById(48);

            //Assert
            Assert.IsType<Magazine>(item);
            Assert.Equal(magazine2.Title, ((Magazine)item).Title);

        }

        [Fact]
        public async Task GetBookByIdTest_BookAsync()
        {
            //Arrange
            Book book1 = new Book
            {
                Title = "Book 1",
                Author = "John Doe",
                LibraryItemId = 11,
            };
            

            Mock<ILibraryRepository> _libraryRepository = new Mock<ILibraryRepository>();
            

            _libraryRepository.Setup(x => x.GetBookById(11).Result).Returns(book1);

            ILibraryService libraryService = new LibraryService(_libraryRepository.Object);

            //Act
            Book item1 = await libraryService.GetBookById(11);
            Book item2 = await libraryService.GetBookById(75843);

            //Assert
            Assert.NotNull(item1);
            Assert.Equal(item1, book1);
            Assert.Null(item2);

        }
    }
}