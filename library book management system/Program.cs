using System;
using System.Collections.Generic;

public class Book
{
    public string Title;
    public string Author;
    public string ISBN;
    public bool IsAvailable;

    public Book(string title, string author, string isbn)
    {
        Title = title;
        Author = author;
        ISBN = isbn;
        IsAvailable = true; 
    }
}

public class Library
{
    public List<Book> books;

    public Library()
    {
        books = new List<Book>();
    }

    public void AddBook(Book book)
    {
        books.Add(book);
        Console.WriteLine("کتاب '" + book.Title + "' به کتابخانه اضافه شد.");
    }

    public void BorrowBook(string title)
    {
        foreach (Book book in books)
        {
            if (book.Title == title)
            {
                if (book.IsAvailable)
                {
                    book.IsAvailable = false;
                    Console.WriteLine("you have borrowed " + title );
                    return;
                }
                else
                {
                    Console.WriteLine("the book" + title + "is not available .");
                    return;
                }
            }
        }
        Console.WriteLine("the book" + title + "has not found.");
    }

    public void ReturnBook(string title)
    {
        foreach (Book book in books)
        {
            if (book.Title == title)
            {
                book.IsAvailable = true;
                Console.WriteLine("the book" + title + " has not returened.");
                return;
            }
        }
        Console.WriteLine("the book" + title + "has not found.");
    }
}

class Program
{
    static void Main(string[] args)
    {
         
        Book book1 = new Book("Alchemist", "reza chavoshi", "1234567890");
        Book book2 = new Book("1984", "mehdi ravan", "0987654321");  
        Library myLibrary = new Library();   ‌
        myLibrary.AddBook(book1);
        myLibrary.AddBook(book2);
        myLibrary.BorrowBook("1984");
        myLibrary.BorrowBook("1984"); 
        myLibrary.ReturnBook("1984");
        myLibrary.BorrowBook("1984");    

        Console.ReadLine();
    }
}
