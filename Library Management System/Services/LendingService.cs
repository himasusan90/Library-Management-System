// See https://aka.ms/new-console-template for more information
public class LendingService
{
    private NotificationManager notificationManager;
    private List<BookLending> allLendings; // Assuming this list tracks all active lendings

    public LendingService(NotificationManager notificationManager)
    {
        this.notificationManager = notificationManager;
        this.allLendings = new List<BookLending>();
    }

    public bool CheckoutBook(Member member, BookItem book)
    {
        if (book.BookStatus != BookStatus.Available || member.TotalNumberOfCheckedBook >= 5)
        {
            Console.WriteLine("Cannot checkout the book.");
            return false;
        }

        BookLending lending = new BookLending(book, DateTime.Now.AddDays(14)); // Assuming a 14-day lending period
        allLendings.Add(lending);
        member.AddBookLending(lending); // Add to member's current checkouts
        book.BookStatus = BookStatus.Loaned;

        notificationManager.NotifyObserver($"Book {book.Title} has been checked out by {member.Person.FirstName}.");
        return true;
    }

    public void ReturnBook(Member member, BookItem book)
    {
        var lending = allLendings.FirstOrDefault(l => l.BookItem.UID == book.UID && l.Member == member);
        if (lending == null)
        {
            Console.WriteLine("This book was not checked out by this member.");
            return;
        }

        decimal fine = lending.CalculateFine();
        if (fine > 0)
        {
            notificationManager.NotifyObserver($"Book {book.Title} returned with a fine of ${fine} by {member.Person.FirstName}.");
        }
        else
        {
            notificationManager.NotifyObserver($"Book {book.Title} has been returned by {member.Person.FirstName}.");
        }

        book.BookStatus = BookStatus.Available; // Update book status
        member.RemoveBookLending(lending); // Remove from member's current checkouts
        allLendings.Remove(lending); // Remove from active lendings
    }
}



