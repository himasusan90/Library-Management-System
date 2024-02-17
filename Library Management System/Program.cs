// See https://aka.ms/new-console-template for more information
using System.Runtime.CompilerServices;


    // Setup a simple catalog
    Catalog catalog = new Catalog();
    catalog.Books = new List<Book>
    {
        new BookItem { UID = 1, Title = "Book 1", Author = "Author A", Subject = "Fiction", PubDate = new DateTime(2000, 1, 1), BookStatus = BookStatus.Available, Rack = new Rack { RackId = 1, Location = "A1" } },
        new BookItem { UID = 2, Title = "Book 2", Author = "Author B", Subject = "Science", PubDate = new DateTime(2001, 2, 2), BookStatus = BookStatus.Available, Rack = new Rack { RackId = 2, Location = "B2" } }
    };

    // Simulate a member checking out a book
    Member member = new Member { AccountId = 1, Person = new Person { FirstName = "John", LastName = "Doe" } };
    var bookToCheckout = catalog.Books[0] as BookItem;
    if (member.CheckoutBook(bookToCheckout))
    {
        Console.WriteLine($"Checked out: {bookToCheckout.Title}");
    }

    // Return the book
    if (member.ReturnBook(bookToCheckout))
    {
        Console.WriteLine($"Returned: {bookToCheckout.Title}");
    }


public enum BookStatus
{
    Loaned, Reserved, Available, Unavailable
}


public enum ReservationStatus
{
   Waiting,pending,canceled,none
}


