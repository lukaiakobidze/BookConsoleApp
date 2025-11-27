using System;

namespace BookApp
{
    class Program
    {
        static void Main()
        {
            BookStorage storage = new BookStorage("books.txt");
            BookManager manager = new BookManager(storage);
            bool running = true;

            if (manager.GetAllBooks().Count == 0)
            {
                manager.AddBook(new Book("The Hobbit", "J.R.R. Tolkien", 1937));
                manager.AddBook(new Book("1984", "George Orwell", 1949));
                manager.AddBook(new Book("Pride and Prejudice", "Jane Austen", 1813));
                manager.AddBook(new Book("To Kill a Mockingbird", "Harper Lee", 1960));
            }

            while (running)
            {
                Console.Clear();
                Console.WriteLine("1. Add Book");
                Console.WriteLine("2. View All Books");
                Console.WriteLine("3. Search Book");
                Console.WriteLine("4. Exit");
                Console.Write("Choose an option: ");

                var key = Console.ReadKey(true);
                Console.WriteLine();

                switch (key.Key)
                {
                    case ConsoleKey.D1:
                    case ConsoleKey.NumPad1:
                        AddBookFlow(manager);
                        break;

                    case ConsoleKey.D2:
                    case ConsoleKey.NumPad2:
                        DisplayBooks(manager);
                        break;

                    case ConsoleKey.D3:
                    case ConsoleKey.NumPad3:
                        SearchBook(manager);
                        break;

                    case ConsoleKey.D4:
                    case ConsoleKey.NumPad4:
                        running = false;
                        return;

                    default:
                        Console.WriteLine("Invalid option");
                        break;
                }

                Console.WriteLine();
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey(true);
            }
        }

        static void AddBookFlow(BookManager manager)
        {
            Console.Clear();

            Console.Write("Enter book title: ");
            string title = Console.ReadLine()!;

            while (string.IsNullOrWhiteSpace(title))
            {
                Console.Write("Invalid input. Enter a valid title: ");
                title = Console.ReadLine()!;
            }

            Console.Write("Enter author: ");
            string author = Console.ReadLine()!;

            while (string.IsNullOrWhiteSpace(author))
            {
                Console.Write("Invalid input. Enter a valid author: ");
                author = Console.ReadLine()!;
            }

            Console.Write("Enter publication year: ");
            string inputYear = Console.ReadLine()!;
            int year;

            while (!int.TryParse(inputYear, out year))
            {
                Console.Write("Invalid year. Enter a valid year: ");
                inputYear = Console.ReadLine()!;
            }

            manager.AddBook(new Book(title, author, year));
            Console.WriteLine("Book added");
        }

        static void DisplayBooks(BookManager manager)
        {
            Console.Clear();

            var books = manager.GetAllBooks();

            if (books.Count == 0)
            {
                Console.WriteLine("No books found");
                return;
            }

            foreach (var book in books)
                Console.WriteLine(book);
        }

        static void SearchBook(BookManager manager)
        {
            Console.Clear();
            Console.Write("Enter book title to search: ");
            string title = Console.ReadLine()!;

            var book = manager.FindByTitle(title);

            if (book == null)
            {
                Console.WriteLine("Book not found");
                return;
            }

            Console.WriteLine(book);
        }
    }
}
