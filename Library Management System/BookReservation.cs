// See https://aka.ms/new-console-template for more information
public class BookReservation
{
    public int BookReservationId { get; set; }
    public BookItem BookItem { get; set; }
    public Member Member { get; set; }
    public ReservationStatus ReservationStatus { get; set; }

    public DateTime  CreatedDate { get; set; }
    public BookReservation(BookItem book, Member user)
    {
        this.Member = user;
        this.BookItem = book;
        this.CreatedDate = DateTime.Now;
        this.ReservationStatus = ReservationStatus.Waiting;
        // Update the book's status
        book.BookStatus = BookStatus.Reserved;
    }
    public BookReservation()
    {

    }


    public static BookReservation FetchBookReservation(BookItem book)
    {
        return new BookReservation();
    }
    public void UnreserveBook(BookReservation bookReservation)
    {

    }

}


