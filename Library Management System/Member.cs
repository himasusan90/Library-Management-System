// See https://aka.ms/new-console-template for more information
public class Member : Account
{

    public int TotalNumberOfCheckedBook { get; set; }
    private List<BookLending> currentCheckouts = new List<BookLending>();
    private List<BookReservation> currentReservations = new List<BookReservation>();
    public bool CheckoutBook(BookItem book)
    {
        if (TotalNumberOfCheckedBook > 5)
        {
            Console.WriteLine("Checkout limit reached.");
            return false;
        }
        if (book.BookStatus != BookStatus.Available)
        {
            Console.WriteLine("Book is not available for checkout.");
            return false;
        }
        var lending = new BookLending(book,this);
        lending.LendBook(book, this);
        currentCheckouts.Add(lending);
        return true;

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

}


