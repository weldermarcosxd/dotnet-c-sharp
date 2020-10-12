using System.Collections.Generic;

namespace GoogleBooksApplication.Models
{
    public class GoogleResponse
    {
        public string Kind { get; set; }

        public int TotalItems { get; set; }

        public List<BookModel> Items { get; set; }
    }
}