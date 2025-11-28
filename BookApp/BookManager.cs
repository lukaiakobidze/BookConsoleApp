namespace BookApp
{
    public class BookManager : IBookManager
    {
        private readonly List<Book> books;
        private readonly BookStorage storage;

        public BookManager(BookStorage storage)
        {
            this.storage = storage;
            books = storage.LoadAll();
        }

        public void AddBook(Book book)
        {
            books.Add(book);
            storage.SaveAll(books);
        }

        public List<Book> GetAllBooks()
        {
            return books;
        }

        public Book FindByTitle(string title)
        {
            return books.Find(b => b.Title.ToLower() == title.ToLower())!;
        }
    }
}
