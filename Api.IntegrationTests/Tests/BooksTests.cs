using System.Net.Http.Json;
using System.Text.Json;
using Generated;

namespace Api.IntegrationTests.Tests;

public class BooksTests : ApiTestBase
{
    [Fact]
    public async Task CreateBook_CanSuccessFullyCreateBook()
    {
        var dto = new CreateBookDto()
        {
            Author = "A",
            Genre = "A",
            Title = "A"
        };
        var result = (await new LibraryClient(Client).PostAsync(dto)).Result;
        Assert.Equivalent(result.Author, dto.Author);
        Assert.Equivalent(result.Genre, dto.Genre);
        Assert.Equivalent(result.Title, dto.Title);
        Assert.NotEqual(0, result.Id);
        Assert.False(string.IsNullOrEmpty(result.Author));
        Assert.False(string.IsNullOrEmpty(result.Genre));
    }

    [Fact]
    public async Task Loanbook_CanSuccessFullyLoanAvailableBook()
    {
        //Arrange
        var bookId = 1;
        var userId = 1;

        var dto = new LoanBookDto()
        {
            BookId = bookId,
            UserId = userId,
        };
        
        //Act
        var result = await new LibraryClient(Client).LoanAsync(dto);
        
        //Assert
        Assert.Equal(200, result.StatusCode);
        Assert.NotNull(result.Result);
    }

    [Fact]
    public async Task Loanbook_FailsToLoanUnavailableBook()
    {
        //Arrange
        var bookId = 1;
        var userId1 = 1;
        
        var dto = new LoanBookDto()
        {
            BookId = bookId,
            UserId = userId1,
        };
        
        //Act
        var firstResult = await new LibraryClient(Client).LoanAsync(dto);
        //Assert
        Assert.Equal(200, firstResult.StatusCode);
        
        //Act
        var secondResult = await new LibraryClient(Client).LoanAsync(dto);
        //Assert
        Assert.Equal(400, secondResult.StatusCode);
    }
    
    
}