using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookApp
{
    public interface IBookManager
    {
        public void AddBook(Book book);

        public List<Book> GetAllBooks();

        public Book FindByTitle(string title);

    }
}
