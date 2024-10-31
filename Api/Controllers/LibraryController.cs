using DataAccess.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service;
using Service.Models;

namespace Api.Controllers;

[ApiController]
[Route("[controller]")]
public class LibraryController(ILibraryService service) : ControllerBase
{
    [Route("[action]")]
    [HttpPost]
    public ActionResult<LoanResponse> Loan([FromBody] LoanBookDto loan)
    {
        try
        {
            var result = service.Loan(loan);
            return Ok(result);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [Route("[action]")]
    [HttpPost]
    public ActionResult<Book> Post([FromBody] CreateBookDto book)
    {
        var newBook = service.AddBook(book);
        return Ok(newBook);
    }
}