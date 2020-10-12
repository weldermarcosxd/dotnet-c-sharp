using AutoMapper;
using GoogleBooksApplication.Interfaces;
using GoogleBooksApplication.Models;
using GoogleBooksData.Context;
using GoogleBooksDomain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoogleBooksApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FavoritesController : ControllerBase
    {
        private readonly SqliteContext _context;
        private readonly IGoogleBooksService _googleBooksService;
        private readonly IMapper _mapper;

        public FavoritesController(SqliteContext context, IGoogleBooksService googleBooksService, IMapper mapper)
        {
            _context = context;
            _googleBooksService = googleBooksService;
            _mapper = mapper;
        }

        private bool BookExists(string id)
        {
            return _context.Book.Any(e => e.GoogleId == id);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Book>>> GetBook()
        {
            return await _context.Book.ToListAsync();
        }

        [HttpPost("{id}")]
        public async Task<ActionResult<Book>> AddBook(string id)
        {
            if (BookExists(id))
                return BadRequest();

            BookModel bookModel = await _googleBooksService.GetGoogleBookById(id);

            if (bookModel == null)
                return NotFound();

            Book book = _mapper.Map<Book>(bookModel);

            _context.Book.Add(book);
            await _context.SaveChangesAsync();

            return book;
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Book>> DeleteBook(string id)
        {
            if (!BookExists(id))
                return NotFound();

            var book = _context.Book.Where(p => p.GoogleId == id).FirstOrDefault();
            _context.Book.Remove(book);
            await _context.SaveChangesAsync();

            return book;
        }

    }
}
