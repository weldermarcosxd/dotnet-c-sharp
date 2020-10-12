using GoogleBooksApplication.Interfaces;
using GoogleBooksApplication.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GoogleBooksApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IGoogleBooksService _googleBooksService;

        public BooksController(IGoogleBooksService googleBooksService)
        {
            _googleBooksService = googleBooksService;
        }

        [HttpGet]
        public async Task<IEnumerable<BookModel>> Get(string query = "c#")
        {
            return await _googleBooksService.GetGoogleBooks(query);
        }
    }
}
