// See https://aka.ms/new-console-template for more information
public class Member : Account,IObserver
{

    public int TotalNumberOfCheckedBook { get; set; }
    private List<BookLending> currentCheckouts = new List<BookLending>();
    private List<BookReservation> currentReservations = new List<BookReservation>();
   
    public void Update(string message)
    {
        Console.WriteLine($"Notification for {this.Person.FirstName}: {message}");
    }

    public bool ReturnBook(BookItem bookItem)
    {
        var lending = currentCheckouts.FirstOrDefault(l => l.BookItem.UID == bookItem.UID);
        if (lending != null){
            decimal fine = lending.CalculateFine();
            if (fine > 0)
            {
                Console.WriteLine($"Book returned with a fine of ${fine}.");
            }
            else
            {
                Console.WriteLine("Book returned successfully.");
            }
            currentCheckouts.Remove(lending);
        }
        var reservation = BookReservation.FetchBookReservation(bookItem);
        if(reservation != null && reservation?.Member?.AccountId!=this.AccountId) {
            Console.WriteLine($"Book reserved by someone else.");
            
        }
        else if(reservation != null)
        {
            reservation.ReservationStatus = ReservationStatus.none;
        }
        else
        {
            bookItem.BookStatus=BookStatus.Available;
        }
       
        //check duedate and calculate the fine

        //check if there are reservations for the book
        return true;

    }
    public void ReserveBook(BookItem bookItem)
    {
        if (bookItem.BookStatus == BookStatus.Available)
        {
            Console.WriteLine("Book is available for checkout, no need to reserve.");
            return;
        }

        var reservation = new BookReservation(bookItem,this);
       
        currentReservations.Add(reservation);
        bookItem.BookStatus = BookStatus.Reserved; // Update the book's status to Reserved
        Console.WriteLine($"Book {bookItem.Title} reserved successfully.");
    }

    internal void AddBookLending(BookLending lending)
    {
        if (lending != null && !currentCheckouts.Contains(lending))
        {
            currentCheckouts.Add(lending);
            TotalNumberOfCheckedBook++; // Increment the count of checked-out books
        }
    }

    internal void RemoveBookLending(BookLending lending)
    {
        if (lending != null && currentCheckouts.Contains(lending))
        {
            currentCheckouts.Remove(lending);
            TotalNumberOfCheckedBook--; // Decrement the count of checked-out books
        }
    }
}


