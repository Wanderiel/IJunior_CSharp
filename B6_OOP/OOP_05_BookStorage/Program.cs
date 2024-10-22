namespace OOP_05_BookStorage
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StaffMember staffMember = new StaffMember();

            staffMember.Work();

            Console.Clear();
            Console.WriteLine("Всего доброго!");
            Console.ReadKey();
        }
    }

    public class StaffMember
    {
        private readonly Storage _storage = new Storage();

        public void Work()
        {
            const ConsoleKey CommandAddBook = ConsoleKey.Insert;
            const ConsoleKey CommandRemoveBook = ConsoleKey.Delete;
            const ConsoleKey CommandShowAllBooks = ConsoleKey.S;
            const ConsoleKey CommandFindBookByTitle = ConsoleKey.T;
            const ConsoleKey CommandFindBookByAuthor = ConsoleKey.A;
            const ConsoleKey CommandFindBookByGenre = ConsoleKey.G;
            const ConsoleKey CommandFindBookByPublicationYear = ConsoleKey.Y;
            const ConsoleKey CommandExit = ConsoleKey.Q;

            bool isWorking = true;

            while (isWorking)
            {
                Console.Clear();
                Console.WriteLine($"Меню:");
                Console.WriteLine($"[{CommandAddBook}] Добавить книгу");
                Console.WriteLine($"[{CommandRemoveBook}] Удалить книгу");
                Console.WriteLine($"[{CommandShowAllBooks}] Показать список книг");
                Console.WriteLine($"[{CommandFindBookByTitle}] Найти книги по названию");
                Console.WriteLine($"[{CommandFindBookByAuthor}] Найти книги по автору");
                Console.WriteLine($"[{CommandFindBookByGenre}] Найти книги по жанру");
                Console.WriteLine($"[{CommandFindBookByPublicationYear}] Найти книги по году издания");
                Console.WriteLine($"[{CommandExit}] Выйти из программы");

                ConsoleKey key = Console.ReadKey(true).Key;

                switch (key)
                {
                    case CommandAddBook:
                        AddBook();
                        break;

                    case CommandRemoveBook:
                        RemoveBook();
                        break;

                    case CommandShowAllBooks:
                        ShowAllBooks();
                        break;

                    case CommandFindBookByTitle:
                        FindBooksByTitle();
                        break;

                    case CommandFindBookByAuthor:
                        FindBooksByAuthor();
                        break;

                    case CommandFindBookByGenre:
                        FindBooksByGenre();
                        break;

                    case CommandFindBookByPublicationYear:
                        FindBooksByPublicationYear();
                        break;

                    case CommandExit:
                        isWorking = false;
                        break;
                }
            }
        }

        private void AddBook()
        {
            Console.Clear();
            Console.Write("Введите название книги: ");
            string name = Console.ReadLine();

            if (string.IsNullOrEmpty(name))
                return;

            Console.Write("Введите ФИО/псевдоним автора: ");
            string author = Console.ReadLine();

            if (string.IsNullOrEmpty(author))
                return;

            Console.Write("Укажите жанр книги: ");
            string genre = Console.ReadLine();

            if (string.IsNullOrEmpty(genre))
                return;

            Console.Write("Укажите год публикации: ");

            if (int.TryParse(Console.ReadLine(), out int year) == false)
                return;

            Book book = new Book(name, author, genre, year);
            _storage.AddBook(book);

            Console.WriteLine("Книга успешно добавлена");
            Console.ReadKey();
        }

        private void RemoveBook()
        {
            Console.Clear();
            Console.Write("Введите индекс книги: ");

            if (int.TryParse(Console.ReadLine(), out int id))
                _storage.RemoveBook(id);
        }

        private void PrintBooksInfo(List<Book> books)
        {
            const int WidthId = 5;

            if (books.Count == 0)
                Console.WriteLine("Пусто...");
            else
                for (int i = 0; i < books.Count; i++)
                {
                    Console.Write($"{i,WidthId} - ");
                    books[i].ShowInfo();
                }

            Console.ReadKey();
        }

        private void ShowAllBooks()
        {
            Console.Clear();
            Console.WriteLine("Список всех книг:");

            List<Book> books = _storage.GetAllBooks();

            PrintBooksInfo(books);
        }

        private void FindBooksByTitle()
        {
            Console.Clear();
            Console.Write("Введите название (или часть) книги: ");

            List<Book> books = _storage.GetBooksByTitle(Console.ReadLine());

            PrintBooksInfo(books);
        }

        private void FindBooksByAuthor()
        {
            Console.Clear();
            Console.Write("Введите автора (или часть) книги: ");

            List<Book> books = _storage.GetBooksByAuthor(Console.ReadLine());

            PrintBooksInfo(books);
        }

        private void FindBooksByGenre()
        {
            Console.Clear();
            Console.Write("Введите жанр (или часть) книги: ");

            List<Book> books = _storage.GetBooksByGenre(Console.ReadLine());

            PrintBooksInfo(books);
        }

        private void FindBooksByPublicationYear()
        {
            Console.Clear();
            Console.Write("Введите год издания: ");

            List<Book> books = _storage.GetBooksByPublicationYear(Console.ReadLine());

            PrintBooksInfo(books);
        }
    }

    public class Storage
    {
        private readonly List<Book> _books = new List<Book>();

        public void AddBook(Book book) =>
            _books.Add(book);

        public void RemoveBook(int index)
        {
            if (TryGetBook(index, out Book book))
            {
                _books.Remove(book);
                Console.WriteLine("Книга успешно удалена");
                Console.ReadKey();
            }
        }

        public List<Book> GetAllBooks() => new List<Book>(_books);

        public List<Book> GetBooksByTitle(string title)
        {
            List<Book> books = new List<Book>();
            title = title.Trim().ToLower();

            if (string.IsNullOrEmpty(title) == false)
                foreach (Book book in _books)
                    if (book.Title.ToLower().Contains(title))
                        books.Add(book);

            return books;
        }

        public List<Book> GetBooksByAuthor(string author)
        {
            List<Book> books = new List<Book>();
            author = author.Trim().ToLower();

            if (string.IsNullOrEmpty(author) == false)
                foreach (Book book in _books)
                    if (book.Autor.ToLower().Contains(author))
                        books.Add(book);

            return books;
        }

        public List<Book> GetBooksByGenre(string genre)
        {
            List<Book> books = new List<Book>();
            genre = genre.Trim().ToLower();

            if (string.IsNullOrEmpty(genre) == false)
                foreach (Book book in _books)
                    if (book.Genre.ToLower().Contains(genre))
                        books.Add(book);

            return books;
        }

        public List<Book> GetBooksByPublicationYear(string input)
        {
            List<Book> books = new List<Book>();

            if (int.TryParse(input, out int year))
                foreach (Book book in _books)
                    if (book.PublicationYear == year)
                        books.Add(book);

            return books;
        }

        private bool TryGetBook(int index, out Book book)
        {
            if (index < 0 || index >= _books.Count)
            {
                book = null;

                return false;
            }

            book = _books[index];

            return true;
        }
    }

    public class Book
    {
        public Book(string title, string author, string genre, int publicationYear)
        {
            Title = title;
            Autor = author;
            Genre = genre;
            PublicationYear = publicationYear;
        }

        public string Title { get; }
        public string Genre { get; }
        public string Autor { get; }
        public int PublicationYear { get; }

        public void ShowInfo()
        {
            Console.WriteLine($"\"{Title}\", {Autor}, {Genre}, {PublicationYear}");
        }
    }
}
