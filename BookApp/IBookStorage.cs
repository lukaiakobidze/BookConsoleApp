using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookApp
{
    public interface IBookStorage
    {
        public void SaveAll(List<Book> books);

        public List<Book> LoadAll();
    }
}
