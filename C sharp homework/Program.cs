using System;
using System.Collections.Generic;

namespace C_sharp_homework
{
    class Book
    {
        string bookAuthor;
        string bookCipher;
        string bookName;
        int bookProductionYear;
        public string BookAuthor
        {
            get => bookAuthor;
            set => bookAuthor = value;
        }
        public string BookCipher
        {
            get => bookCipher;
            set => bookCipher = value;
        }
        public string BookName
        {
            get => bookName;
            set => bookName = value;
        }
        public int BookProductionYear
        {
            get => bookProductionYear;
            set => bookProductionYear = value;
        }
        public Book(string bookAuthor, string bookCipher, string bookName, int bookProductionYear)
        {
            this.bookAuthor = bookAuthor;
            this.bookCipher = bookCipher;
            this.bookName = bookName;
            this.bookProductionYear = bookProductionYear;
        }
    }
    class Library : IComparer <Book>
    {
        Book[] books = new Book[0];
        public void AddNewBook(string bookAuthor, string bookCipher, string bookName, int bookProductionYear)
        {
            Array.Resize(ref books, books.Length + 1);
            Book book = new Book(bookAuthor, bookCipher, bookName, bookProductionYear);
            books[books.Length - 1] = book;
        }
        public void ShowBooks()
        {
            for (int i = 0; i < books.Length; i++)
            {
                Console.WriteLine($"Book {i + 1}. Name: \"{books[i].BookName}\", Author: {books[i].BookAuthor}, " +
                    $"cipher: {books[i].BookCipher}, year: {books[i].BookProductionYear}");
            }
        }
        public void DeleteBook(string bookCipher)
        {
            Book[] booksCopy = new Book[books.Length];

            for (int i = 0; i < books.Length; i++)
            {
                if (books[i].BookCipher == bookCipher)
                {
                    Console.WriteLine("cipher found!");
                    books.CopyTo(booksCopy, 0);
                    Array.Resize(ref books, books.Length - 1);
                    Array.Copy(booksCopy, i + 1, books, i, (books.Length - i));
                }
            }
        }
        public void SortingBooksByAuthor()
        {
            Array.Sort(books, (x, y) => -x.BookAuthor.CompareTo(y.BookAuthor));
        }
        public void SortingBooksByYearAndAuthor()
        {
            Array.Sort(books, new Library());
        }
        public int Compare (Book a, Book b)
        {
            if (a.BookProductionYear > b.BookProductionYear)
                return 1;
            else if (a.BookProductionYear < b.BookProductionYear)
                return -1;
            else if (a.BookAuthor[0] > b.BookAuthor[0])
                return 1;
            else if (a.BookAuthor[0] < b.BookAuthor[0])
                return -1;
            else
                return 0;
        }
        public int FindBook(string authorOrName)
        {
            return Array.FindIndex(books, (x) => x.BookAuthor== authorOrName || x.BookName== authorOrName);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Library library = new Library();
            library.AddNewBook("Pushkin", "234234234", "PUSHKIN BOOK", 1890);
            library.AddNewBook("Robert Kiyosaki", "875989786", "Rich Dad, Poor Dad", 2004);
            library.AddNewBook("Nikoduma", "234546466", "Too late after 3 years...", 2004);
            library.AddNewBook("Group of authors", "536543456", "Travels", 2020);
            library.AddNewBook("Author Batkovych", "745645345", "Tom Sojer Adventures", 1950);
            library.AddNewBook("Taras Shevchenko", "453778694", "Kobsar", 1840);
            library.ShowBooks();
            library.DeleteBook("745645345");
            Console.WriteLine("After deleting \"Author Batkovych\", \"745645345\", \"Tom Sojer Adventures\", 1950");
            library.ShowBooks();
            library.SortingBooksByAuthor();
            library.ShowBooks();
            library.SortingBooksByYearAndAuthor();
            library.ShowBooks();
            string searchedBook = "Nikoduma";
            int foundIndex = library.FindBook(searchedBook);
            Console.WriteLine($"Search for book of {searchedBook}: {foundIndex}");
        }
    }
}
