// See https://aka.ms/new-console-template for more information
using System.Runtime.CompilerServices;


// Assuming NotificationManager and LendingService are set up to handle notifications and lending logic
NotificationManager notificationManager = new NotificationManager();
LendingService lendingService = new LendingService(notificationManager);

// Create a catalog of books
Catalog catalog = new Catalog();
catalog.Books = new List<Book>
        {
            new BookItem { UID = 1, Title = "Book 1", Author = "Author A", Subject = "Fiction", PubDate = new DateTime(2000, 1, 1), BookStatus = BookStatus.Available, Rack = new Rack { RackId = 1, Location = "A1" } },
            new BookItem { UID = 2, Title = "Book 2", Author = "Author B", Subject = "Science", PubDate = new DateTime(2001, 2, 2), BookStatus = BookStatus.Available, Rack = new Rack { RackId = 2, Location = "B2" } }
        };

// Create a member and register it with the NotificationManager
Member member = new Member { AccountId = 1, Person = new Person { FirstName = "John", LastName = "Doe" } };
notificationManager.RegisterObserver(member);

// Borrow a book
var bookToCheckout = catalog.Books[0] as BookItem;
Console.WriteLine($"Attempting to check out: {bookToCheckout.Title}");
if (lendingService.CheckoutBook(member, bookToCheckout))
{
    Console.WriteLine($"Checked out: {bookToCheckout.Title}");
}

// Simulate some time passing
Console.WriteLine("Some time passes...");

// Return the book
Console.WriteLine($"Attempting to return: {bookToCheckout.Title}");
lendingService.ReturnBook(member, bookToCheckout);


