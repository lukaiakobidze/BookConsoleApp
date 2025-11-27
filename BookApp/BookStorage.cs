namespace BookApp
{
    public class BookStorage
    {
        private readonly string filePath;

        public BookStorage(string fileName)
        {
            filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, fileName);

            if (!File.Exists(filePath))
                File.Create(filePath).Close();
        }

        public void SaveAll(List<Book> books)
        {
            using var writer = new StreamWriter(filePath, false);

            foreach (var book in books)
                writer.WriteLine($"{book.Title}|{book.Author}|{book.Year}");
        }

        public List<Book> LoadAll()
        {
            var books = new List<Book>();

            foreach (var line in File.ReadAllLines(filePath))
            {
                if (string.IsNullOrWhiteSpace(line)) continue;

                var parts = line.Split('|');

                if (parts.Length == 3 && int.TryParse(parts[2], out int year))
                {
                    books.Add(new Book(parts[0], parts[1], year));
                }
            }

            return books;
        }
    }
}
