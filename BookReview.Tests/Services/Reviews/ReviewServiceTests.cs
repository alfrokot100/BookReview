using BookReview.DTOs.ReviewDTOs;
using BookReview.Models;
using BookReview.Repositories.IRepositories;
using BookReview.Services;
using Moq;

namespace Resturants.Tests.Services.Reviews;

public class ReviewServiceTests
{
    private readonly Mock<IReviewRepository> _repoMock;
    private readonly ReviewService _service;

    public ReviewServiceTests()
    {
        _repoMock = new Mock<IReviewRepository>();
        _service = new ReviewService(_repoMock.Object);
    }

    [Fact]
    public async Task GetAllReviewsAsync_ReturnsDTO()
    {
        //Arrange
        var reviews = new List<Review>
        {
            new Review{
            Id = 1,
            ReviewerName = "Anders",
            Rating = 4,
            BookId_FK = 1
            }
        };

        //Act
        _repoMock
            .Setup(r => r.GetAllReviewsAsync(1))
            .ReturnsAsync(reviews);

        var result = await _service.GetAllReviewsAsync(1);

        //Assert
        Assert.Single(result);
        Assert.Equal("Anders", result.First().ReviewerName);
    }

    [Fact]
    public async Task When_ReviewIdDoesNotExist_Then_ReturnNull()
    {          
        //Act
        _repoMock
            .Setup(r => r.GetReviewByIdAsync(2))
            .ReturnsAsync((Review?)null);

        var result = await _service.GetReviewByIdAsync(2);

        //Assert
        Assert.Null(result);
    }

    [Fact]
    public async Task When_ReviewIdDoesExist_Then_RetrunReview()
    {
        var reviews = new Review
        {
            Id = 1,
            ReviewerName = "Anders",
            Rating = 4,
            BookId_FK = 1
        };

        //Act
        _repoMock
            .Setup(r => r.GetReviewByIdAsync(1))
            .ReturnsAsync(reviews);

        var result = await _service.GetReviewByIdAsync(1);

        //Assert
        Assert.NotNull(result);
        Assert.Equal(1, reviews.Id);
        Assert.Equal("Anders", reviews.ReviewerName);
    }

    [Fact]
    public async Task CreateReviewToBookAsync_ValidInput_ReturnsReviewDTO()
    {
        //Arrange
        var bookId = 4;

        var createReview = new CreateReviewDTO { Rating = 4, ReviewerName = "Anders", Text = "Bra Bok!" };

        _repoMock
            .Setup(x => x.CreateReviewAsync(It.IsAny<Review>()))
            .Returns(Task.CompletedTask);

        _repoMock
            .Setup(x => x.SaveChangesAsync())
            .ReturnsAsync(true);

        // Act
        var result = await _service.CreateReviewToBookAsync(bookId, createReview);

        //Assert
        Assert.NotNull(result);
        Assert.Equal("Anders", result.ReviewerName);
        Assert.Equal(4, result.Rating);
        Assert.Equal("Bra bok", result.Text);
        Assert.Equal(bookId, result.BookId);

        _repoMock.Verify(r => r.SaveChangesAsync(), Times.Once);
    }

    public async Task UpdateReviewAsync_IfReviewIdIdDoesNotExist_ThenReturnFalse() 
    {
        //Árrange
        _repoMock
            .Setup(r => r.GetReviewByIdAsync(It.IsAny<int>()))
            .ReturnsAsync((Review?)null);

        var updateDto = new UpdateReviewDTO
        {
            Rating = 3,
            Text = "Uppdaterad text"
        };

        // Act
        var result = await _service.UpdateReviewAsync(1, updateDto);

        // Assert
        Assert.False(result);

        _repoMock.Verify(r => r.UpdateReviewAsync(It.IsAny<Review>()), Times.Never);
        _repoMock.Verify(r => r.SaveChangesAsync(), Times.Never);
    }

    public async Task UpdateReviewAsync_IfReviewIdExists_ThenUpdateAndRetrunTrue()
    {
        //Arrange
        var existing = new Review
        {
            Id = 1,
            Rating = 4,
            ReviewerName = "Blanco",
            Text = "Gammal Text",
            BookId_FK = 1
        };

        var newReview = new UpdateReviewDTO
        {
            Rating = 5,
            Text = "Ny text"
        };
        _repoMock
           .Setup(r => r.GetReviewByIdAsync(It.IsAny<int>()))
           .ReturnsAsync(existing);
        _repoMock
            .Setup(r => r.SaveChangesAsync())
            .ReturnsAsync(true);
        //Act
        var result = await _service.UpdateReviewAsync(2, newReview);

        //Assert
        Assert.True(result);
        Assert.Equal(5, existing.Rating);
        Assert.Equal("Ny text", existing.Text);

        _repoMock
            .Verify(r => r.UpdateReviewAsync(existing), Times.Once);
        _repoMock
            .Verify(r => r.SaveChangesAsync(), Times.Once);
    }

    public async Task DeleteReviewAsync_When_ReviewIdExists_Then_DeleteReview()
    {
        _repoMock
            .Setup(r => r.SaveChangesAsync())
            .ReturnsAsync(true);

        //Act
        var result = await _service.DeleteReviewAsync(1);

        //Assert
        Assert.True(result);

        _repoMock
            .Verify(r => r.DeleteReviewAsync(1), Times.Once);
        _repoMock
            .Verify(r => r.SaveChangesAsync(), Times.Once);
    }

}
