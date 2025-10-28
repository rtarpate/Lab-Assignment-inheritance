using System;
using System.Collections.Generic;

internal class Program
{

    internal class Book
    {
        public string BookName { get; set; }
        public string BookAuthor { get; set; }
        public int BookPrice { get; set; }
        public int BookStock { get; set; }
        public int BookYearPublished { get; set; }

        public Book(string bookname, string bookauthor, int bookprice, int bookstock, int bookyearpublished)
        {
            BookName = bookname;
            BookAuthor = bookauthor;
            BookPrice = bookprice;
            BookStock = bookstock;
            BookYearPublished = bookyearpublished;
        }

        public void DisplayBookInfo()
        {
            Console.WriteLine($" Name: {BookName} | Author: {BookAuthor} | Price: ${BookPrice} | Stock: {BookStock} | Year: {BookYearPublished}");
        }
    }


    internal class DVD
    {
        public string DVDName { get; set; }
        public string DVDDirector { get; set; }
        public int DVDPrice { get; set; }
        public int DVDStock { get; set; }
        public int DVDYearPublished { get; set; }

        public DVD(string dvdname, string dvddirector, int dvdprice, int dvdstock, int dvdyearpublished)
        {
            DVDName = dvdname;
            DVDDirector = dvddirector;
            DVDPrice = dvdprice;
            DVDStock = dvdstock;
            DVDYearPublished = dvdyearpublished;
        }

        public void DisplayDVDInfo()
        {
            Console.WriteLine($" Name: {DVDName} | Director: {DVDDirector} | Price: ${DVDPrice} | Stock: {DVDStock} | Year: {DVDYearPublished}");
        }
    }


    internal class Novel : Book
    {
        public string Genre { get; set; }

        public Novel(string bookname, string bookauthor, int bookprice, int bookstock, int bookyearpublished, string genre)
            : base(bookname, bookauthor, bookprice, bookstock, bookyearpublished)
        {
            Genre = genre;
        }
    }

    internal class ComicBook : Book
    {
        public string Illustrator { get; set; }

        public ComicBook(string bookname, string bookauthor, int bookprice, int bookstock, int bookyearpublished, string illustrator)
            : base(bookname, bookauthor, bookprice, bookstock, bookyearpublished)
        {
            Illustrator = illustrator;
        }
    }

    internal class Manga : Book
    {
        public string Language { get; set; }

        public Manga(string bookname, string bookauthor, int bookprice, int bookstock, int bookyearpublished, string language)
            : base(bookname, bookauthor, bookprice, bookstock, bookyearpublished)
        {
            Language = language;
        }
    }


    internal class HDDVD : DVD
    {
        public string ResolutionType { get; set; }

        public HDDVD(string dvdname, string dvddirector, int dvdprice, int dvdstock, int dvdyearpublished, string resolutionType)
            : base(dvdname, dvddirector, dvdprice, dvdstock, dvdyearpublished)
        {
            ResolutionType = resolutionType;
        }
    }

    internal class BluRay : DVD
    {
        public bool HasBonusContent { get; set; }

        public BluRay(string dvdname, string dvddirector, int dvdprice, int dvdstock, int dvdyearpublished, bool hasBonusContent)
            : base(dvdname, dvddirector, dvdprice, dvdstock, dvdyearpublished)
        {
            HasBonusContent = hasBonusContent;
        }
    }

    internal class VHS : DVD
    {
        public string TapeCondition { get; set; }

        public VHS(string dvdname, string dvddirector, int dvdprice, int dvdstock, int dvdyearpublished, string tapeCondition)
            : base(dvdname, dvddirector, dvdprice, dvdstock, dvdyearpublished)
        {
            TapeCondition = tapeCondition;
        }
    }

    private static List<Book> books = new List<Book>();
    private static List<DVD> dvds = new List<DVD>();


    private static void DisplayBooks()
    {
        Console.WriteLine("\n=== BOOK INVENTORY ===");
        for (int i = 0; i < books.Count; i++)
        {
            Console.Write($"{i + 1}. ");
            books[i].DisplayBookInfo();
        }
    }

    private static void DisplayDVDs()
    {
        Console.WriteLine("\n=== DVD INVENTORY ===");
        for (int i = 0; i < dvds.Count; i++)
        {
            Console.Write($"{i + 1}. ");
            dvds[i].DisplayDVDInfo();
        }
    }

    private static void RentBook()
    {
        DisplayBooks();
        Console.Write("\nEnter the number of the book you want to rent: ");
        if (int.TryParse(Console.ReadLine(), out int choice) && choice >= 1 && choice <= books.Count)
        {
            if (books[choice - 1].BookStock > 0)
            {
                books[choice - 1].BookStock--;
                Console.WriteLine($"You rented \"{books[choice - 1].BookName}\" successfully!");
            }
            else
            {
                Console.WriteLine("Sorry, this book is out of stock.");
            }
        }
        else
        {
            Console.WriteLine("Invalid choice.");
        }
    }

    private static void ReturnBook()
    {
        DisplayBooks();
        Console.Write("\nEnter the number of the book you want to return: ");
        if (int.TryParse(Console.ReadLine(), out int choice) && choice >= 1 && choice <= books.Count)
        {
            books[choice - 1].BookStock++;
            Console.WriteLine($"You returned \"{books[choice - 1].BookName}\" successfully!");
        }
        else
        {
            Console.WriteLine("Invalid choice.");
        }
    }

    private static void RentDVD()
    {
        DisplayDVDs();
        Console.Write("\nEnter the number of the DVD you want to rent: ");
        if (int.TryParse(Console.ReadLine(), out int choice) && choice >= 1 && choice <= dvds.Count)
        {
            if (dvds[choice - 1].DVDStock > 0)
            {
                dvds[choice - 1].DVDStock--;
                Console.WriteLine($"You rented \"{dvds[choice - 1].DVDName}\" successfully!");
            }
            else
            {
                Console.WriteLine("Sorry, this DVD is out of stock.");
            }
        }
        else
        {
            Console.WriteLine("Invalid choice.");
        }
    }

    private static void ReturnDVD()
    {
        DisplayDVDs();
        Console.Write("\nEnter the number of the DVD you want to return: ");
        if (int.TryParse(Console.ReadLine(), out int choice) && choice >= 1 && choice <= dvds.Count)
        {
            dvds[choice - 1].DVDStock++;
            Console.WriteLine($"You returned \"{dvds[choice - 1].DVDName}\" successfully!");
        }
        else
        {
            Console.WriteLine("Invalid choice.");
        }
    }


    private static void Main(string[] args)
    {

        books.AddRange(new List<Book>
        {
            new Novel("The Lost World", "Arthur Conan Doyle", 15, 100, 1912, "Adventure"),
            new Novel("Pride and Prejudice", "Jane Austen", 10, 100, 1813, "Romance"),
            new Novel("1984", "George Orwell", 18, 100, 1949, "Dystopian"),
            new ComicBook("Spider-Man", "Stan Lee", 8, 100, 1962, "Steve Ditko"),
            new Manga("Naruto", "Masashi Kishimoto", 11, 100, 1999, "Japanese")
        });

        dvds.AddRange(new List<DVD>
        {
            new HDDVD("Matrix Reloaded", "Lana Wachowski", 20, 100, 2003, "1080p"),
            new HDDVD("Troy", "Wolfgang Petersen", 17, 100, 2004, "1080i"),
            new BluRay("Inception", "Christopher Nolan", 25, 100, 2010, true),
            new BluRay("Avatar", "James Cameron", 28, 100, 2009, true),
            new VHS("Star Wars", "George Lucas", 5, 100, 1977, "Good")
        });

        bool running = true;
        while (running)
        {
            Console.WriteLine("\n====== LIBRARY MENU ======");
            Console.WriteLine("1. Check book inventory");
            Console.WriteLine("2. Return a book to library");
            Console.WriteLine("3. Rent a book from library");
            Console.WriteLine("4. Check DVD inventory");
            Console.WriteLine("5. Return a DVD to library");
            Console.WriteLine("6. Rent a DVD from library");
            Console.WriteLine("7. Exit program");
            Console.Write("Select an option (1-7): ");

            string choice = Console.ReadLine();
            Console.WriteLine();

            switch (choice)
            {
                case "1": DisplayBooks(); break;
                case "2": ReturnBook(); break;
                case "3": RentBook(); break;
                case "4": DisplayDVDs(); break;
                case "5": ReturnDVD(); break;
                case "6": RentDVD(); break;
                case "7": running = false; break;
                default: Console.WriteLine("Invalid selection. Please try again."); break;
            }
        }

        Console.WriteLine("\nThank you for using the Library Program!");
    }
}
