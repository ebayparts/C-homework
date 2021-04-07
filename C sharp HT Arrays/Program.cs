using System;
using System.Collections;
using System.Collections.Generic;

namespace C_sharp_HT_Arrays
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
        public Book(CoverBook coverBook)
        {
            this.bookAuthor = coverBook.BookAuthor;
            this.bookCipher = "Book cipher";
            this.bookName = coverBook.BookName;
            this.bookProductionYear = coverBook.BookProductionYear;
        }

        public string this[string index]
        {
            get
            {
                if (index.ToLower() == "author" || index.ToLower() == "book author" || Convert.ToInt32(index) == 0)
                    return bookAuthor;
                else if (index.ToLower() == "name" || index.ToLower() == "title" || Convert.ToInt32(index) == 1)
                    return bookName;
                else if (index.ToLower() == "year" || Convert.ToInt32(index) == 2)
                    return bookProductionYear.ToString();
                throw new Exception($"Error index {index ?? "null"}");
            }
        }
        public override string ToString() => $"Title: \"{BookName}\"  Author: {bookAuthor}  Cipher: {bookCipher}  Year: {BookProductionYear}";
    }
    class Library : IComparer<Book>, IEnumerable
    {
        Book[] books = new Book[0];
        public void AddNewBook(string bookAuthor, string bookCipher, string bookName, int bookProductionYear)
        {
            Array.Resize(ref books, books.Length + 1);
            Book book = new Book(bookAuthor, bookCipher, bookName, bookProductionYear);
            books[books.Length - 1] = book;
            CheckUniqueBookCipher();
        }
        public void CheckUniqueBookCipher()
        {
            //Console.WriteLine($"Checking cipher uniqueness: {this.books[^1].BookCipher}") ;
            for (int i = 0; i < books.Length - 1; i++)
            {
                if (books[i].BookCipher == books[books.Length - 1].BookCipher)
                    books[books.Length - 1].BookCipher = books[books.Length - 1].BookCipher.Insert(books[books.Length - 1].BookCipher.Length, "_A");
            }
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
        public int Compare(Book a, Book b)
        {
            if (a.BookProductionYear > b.BookProductionYear)
                return 1;
            else if (a.BookProductionYear < b.BookProductionYear)
                return -1;
            else
            {
                int minLength = a.BookAuthor.Length < b.BookAuthor.Length ? a.BookAuthor.Length : b.BookAuthor.Length;
                for (int i = 0; i < minLength; i++)
                {
                    if (a.BookAuthor[i] > b.BookAuthor[i])
                        return 1;
                    else if (a.BookAuthor[i] < b.BookAuthor[i])
                        return -1;
                }
                return 0;
            }
        }
        public int FindBook(string authorOrName)
        {
            return Array.FindIndex(books, (x) => x.BookAuthor == authorOrName || x.BookName == authorOrName);
        }

        private bool IsValidIndex(int index) => index >= 0 && index <= books.Length - 1;
        public IEnumerator GetEnumerator()
        {
            foreach (Book b in books)
            {
                yield return b;
            }
        }
        public IEnumerable<Book> GetReversedLibrary()
        {
            for (int i = books.Length-1; i > -1; i--)
            {
                yield return books[i];
            }
        }
        public IEnumerable<Book> GetBooksOneAuthor(string author)
        {
            foreach (Book b in books)
            {
                if(b.BookAuthor==author) 
                    yield return b;
            }
        }
        public Book this[int index]
        {
            get
            {
                if (!IsValidIndex(index))
                    throw new Exception($"Error index {index}");
                return books[index];
            }
            set
            {
                if (!IsValidIndex(index))
                    throw new Exception($"Error index{index}");
                CheckUniqueBookCipher();
                books[index] = value;
            }
        }
        public Book this[string index]
        {
            get
            {
                for (int i = 0; i < books.Length; i++)
                {
                    if (books[i].BookCipher == index)
                        return books[i];
                }
                throw new Exception($"Error index {index}");
            }
            set
            {
                for (int i = 0; i < books.Length; i++)
                {
                    if (books[i].BookCipher == index)
                    {
                        CheckUniqueBookCipher();
                        books[i] = value;
                    }
                }
                throw new Exception($"Error index {index}");
            }
        }
    }
    class CoverBook
    {
        string bookAuthor;
        string bookName;
        int bookProductionYear;
        public string BookAuthor
        {
            get => bookAuthor;
            set => bookAuthor = value;
        }
        public int BookProductionYear
        {
            get => bookProductionYear;
            set => bookProductionYear = value;
        }
        public string BookName
        {
            get => bookName;
            set => bookName = value;
        }
        public CoverBook(Book book)
        {
            this.bookAuthor = book.BookAuthor;
            this.bookName = book.BookName;
            this.bookProductionYear = book.BookProductionYear;
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
            library.AddNewBook("Group of authors", "453778694", "Travels", 2020);
            library.AddNewBook("Author Batkovych", "745645345", "Tom Sojer Adventures", 1950);
            library.AddNewBook("Taras Shevchenko", "453778694", "Kobsar", 1840);
            //library.ShowBooks();
            //library.DeleteBook("745645345");
            //Console.WriteLine("After deleting \"Author Batkovych\", \"745645345\", \"Tom Sojer Adventures\", 1950");
            //library.ShowBooks();
            library.SortingBooksByAuthor();
            //library.ShowBooks();
            library.SortingBooksByYearAndAuthor();
            //library.ShowBooks();
            string searchedBook = "Nikoduma";
            int foundIndex = library.FindBook("Nikoduma");
            //Console.WriteLine($"Search for book of {searchedBook}: {foundIndex}");
            ////Second hometask /// indexator theme:

            // Console.WriteLine($"Old data of book 2: {library[1]}");
            library[1].BookAuthor = "A.Pushkin";
            library[1].BookCipher = "12345678";
            library[1].BookProductionYear = 1820;
            library[1].BookName = "Ruslan and Ludmila";
            //Console.WriteLine($"New data of book 2: {library[1]}");
            library.AddNewBook("Pavlo Tychuna", "12345678", "Newest book production", 2020);
            //Console.WriteLine($"Checking book cipher uniqueness :\n {library[5]}");

            Console.WriteLine("Hometask new: IEnumerable realization:");
            foreach (var b in library)
            {
                Console.WriteLine(b);
            }
            Console.WriteLine("Reversed Library:");
            foreach (var b in library.GetReversedLibrary())
            {
                Console.WriteLine(b);
            }
            Console.WriteLine("A.Pushkin books Library:");
            foreach (var b in library.GetBooksOneAuthor("A.Pushkin"))
            {
                Console.WriteLine(b);
            }
        }
    }
}