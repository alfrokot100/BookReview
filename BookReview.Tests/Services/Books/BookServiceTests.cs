using BookReview.DTOs.BookDTOs;
using BookReview.Models;
using BookReview.Repositories.IRepositories;
using BookReview.Services;
using Moq;

namespace Resturants.Tests.Services.Books;

public class BookServiceTests
{
    private readonly Mock<IBookRepository> _bookMock;
    private readonly BookService _bookService;

    public BookServiceTests()
    {
        _bookMock = new Mock<IBookRepository>();
        _bookService = new BookService(_bookMock.Object);
    }

    [Fact]
    public async Task CreateBook_IfValidInput_Then_ReturnDTO()
    {
        //Arrange
        var creatBook = new BookCreateDTO
        {
            Author = "Nisse",
            Title = "Harry Potter Den Evige",
            Description = "En utmanande resa",
        };

        _bookMock
            .Setup(b => b.CreateBookAsync(It.IsAny<Book>()))
            .ReturnsAsync(1);

        var result = await _bookService.CreateBookAsync(creatBook);

        //Assert
        Assert.NotNull(result);
        Assert.Equal("Nisse", creatBook.Author);
        Assert.Equal("Harry Potter Den Evige", creatBook.Title);
        Assert.Equal("En utmanande resa", creatBook.Description);
    }

    [Fact]
    public async Task UpdateBookDTO_If_IdDoesNotExist_Then_RetrunFalse()
    {
        //Arrange
        _bookMock
            .Setup(r => r.GetBookByIdAsync(4))
            .ReturnsAsync((Book?)null);
        //Act & Assert
        var result = await _bookService.GetBookByIdAsync(4);

        Assert.Null(result);
    }

    [Fact]
    public async Task UpdateBookDTO_If_IdDoesExist_Then_RetrunDTO()
    {
        var existingBook = new Book
        {
            Id = 8,
            Title = "Gammal titel",
            Description = "Gammal text",
            Author = "Någon",
            Genre = "Fantasy",
            PublishedYear = 1990
        };

        var updatedBook = new BookUpdateDTO
        {
            Id = 8,
            Author = "Lurre",
            Title = "Sagan Om Ringen",
            Description = "Äventyrelig",
            PublishedYear = 2004,
        };

        _bookMock
            .Setup(r => r.GetBookByIdAsync(It.IsAny<int>()))
            .ReturnsAsync(existingBook);
        _bookMock
            .Setup(r => r.UpdateBookAsync(It.IsAny<Book>()))
            .ReturnsAsync(true);

        // Act
        var result = await _bookService.UpdateBookAsync(8,updatedBook);

        // Assert
        Assert.True(result);

        Assert.Equal("Sagan Om Ringen", existingBook.Title);
        Assert.Equal("Äventyrlig", existingBook.Description);
        Assert.Equal("Lurre", existingBook.Author);
        Assert.Equal(2004, existingBook.PublishedYear);
    }

    [Fact]
    public async Task SerachBook_Then_RetrunDTO()
    {
        var books = new List<Book>
        {
            new Book
            {
            Id = 8,
            Author = "Lurre",
            Title = "Sagan Om Ringen",
            Description = "Äventyrelig",
            Genre = "Fantasy",
            PublishedYear = 2004,
            }
        };

        _bookMock
            .Setup(r => r.SearchBooksAsync(It.IsAny<string>()))
            .ReturnsAsync(books);
            
    }

}


