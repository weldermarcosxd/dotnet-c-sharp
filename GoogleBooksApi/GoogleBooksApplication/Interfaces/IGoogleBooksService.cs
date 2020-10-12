using GoogleBooksApplication.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GoogleBooksApplication.Interfaces
{
    public interface IGoogleBooksService
    {
        Task<BookModel> GetGoogleBookById(string id);
        Task<IEnumerable<BookModel>> GetGoogleBooks(string query, int maxResults = 20);
    }
}
