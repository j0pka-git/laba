using System;
using System.Collections.Generic;
using System.Linq;

public struct Book
{
    public string Author;
    public string Title;
    public int Year;
    public string Publisher;
}

public struct LoanRecord
{
    public string BookTitle;
    public DateTime IssueDate;
    public DateTime? ReturnDate;
}

public class Library
{
    private readonly List<Book> _books = new List<Book>();
    private readonly List<LoanRecord> _loans = new List<LoanRecord>();

    public void AddBook(Book book) => _books.Add(book);

    public void PrintBook(Book book)
    {
        Console.WriteLine($"\nАвтор: {book.Author}");
        Console.WriteLine($"Название: {book.Title}");
        Console.WriteLine($"Год издания: {book.Year}");
        Console.WriteLine($"Издательство: {book.Publisher}");
    }

    public void PrintAllBooks()
    {
        Console.WriteLine(_books.Count == 0 ? "Библиотека пуста." : "Список книг:");
        _books.ForEach(PrintBook);
    }

    public void IssueBook(string title, DateTime issueDate)
    {
        if (!_books.Any(b => b.Title == title))
        {
            Console.WriteLine($"Книга '{title}' не найдена.");
            return;
        }

        _loans.Add(new LoanRecord { BookTitle = title, IssueDate = issueDate });
        Console.WriteLine($"Книга '{title}' выдана.");
    }

    public void ReturnBook(string title, DateTime returnDate)
    {
        var record = _loans.FirstOrDefault(r => r.BookTitle == title && r.ReturnDate == null);
        
        if (record.BookTitle == null)
        {
            Console.WriteLine($"Книга '{title}' не найдена или уже возвращена.");
            return;
        }

        record.ReturnDate = returnDate;
        _loans[_loans.IndexOf(record)] = record;
        Console.WriteLine($"Книга '{title}' возвращена.");
    }

    public void ShowNeverBorrowed()
    {
        var neverBorrowed = _books.Where(b => !_loans.Any(r => r.BookTitle == b.Title)).ToList();
        
        Console.WriteLine(neverBorrowed.Count == 0 
            ? "Все книги были выданы хотя бы раз." 
            : "Книги, которые никогда не выдавались:");
        
        neverBorrowed.ForEach(PrintBook);
    }

    public void ShowCurrentlyBorrowed()
    {
        var borrowedTitles = _loans
            .Where(r => r.ReturnDate == null)
            .Select(r => r.BookTitle)
            .Distinct()
            .ToList();
            
        var borrowedBooks = _books.Where(b => borrowedTitles.Contains(b.Title)).ToList();
        
        Console.WriteLine(borrowedBooks.Count == 0 
            ? "Нет выданных книг." 
            : "Текущие выданные книги:");
        
        borrowedBooks.ForEach(PrintBook);
    }
}

class Program
{
    static Book InputBook()
    {
        Console.Write("\nАвтор: ");
        string author = Console.ReadLine();
        
        Console.Write("Название: ");
        string title = Console.ReadLine();
        
        Console.Write("Год издания: ");
        int year = int.Parse(Console.ReadLine());
        
        Console.Write("Издательство: ");
        string publisher = Console.ReadLine();
        
        return new Book { Author = author, Title = title, Year = year, Publisher = publisher };
    }

    static void Main()
    {
        var library = new Library();
        
        while (true)
        {
            Console.WriteLine("\n1. Добавить книгу");
            Console.WriteLine("2. Выдать книгу");
            Console.WriteLine("3. Вернуть книгу");
            Console.WriteLine("4. Показать все книги");
            Console.WriteLine("5. Никогда не выдававшиеся");
            Console.WriteLine("6. Текущие выданные");
            Console.WriteLine("7. Выход");
            Console.Write("Выберите: ");

            if (!int.TryParse(Console.ReadLine(), out int choice))
            {
                Console.WriteLine("Ошибка ввода. Попробуйте снова.");
                continue;
            }

            try
            {
                switch (choice)
                {
                    case 1:
                        library.AddBook(InputBook());
                        break;
                    case 2:
                        Console.Write("Название книги: ");
                        string issueTitle = Console.ReadLine();
                        library.IssueBook(issueTitle, DateTime.Now);
                        break;
                    case 3:
                        Console.Write("Название книги: ");
                        string returnTitle = Console.ReadLine();
                        library.ReturnBook(returnTitle, DateTime.Now);
                        break;
                    case 4:
                        library.PrintAllBooks();
                        break;
                    case 5:
                        library.ShowNeverBorrowed();
                        break;
                    case 6:
                        library.ShowCurrentlyBorrowed();
                        break;
                    case 7:
                        return;
                    default:
                        Console.WriteLine("Неверный выбор. Попробуйте снова.");
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }
    }
}
