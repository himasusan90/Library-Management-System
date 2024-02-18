// See https://aka.ms/new-console-template for more information
public class BookLending{
    public BookLending(BookItem book, Member member)
    {
        Book = book;
        Member = member;
    }

    public Member Memeber { get; set; }
    public int BookLendingId { get; set; }
    public BookItem BookItem { get; set; }
    public DateTime DueDate { get; set; }
    public DateTime CreatedDate { get; set; }
    public BookStatus Status { get; set; }
    public BookItem Book { get; }
    public Member Member { get; }
    private NotificationManager notificationManager;
    public BookLending(BookItem book, DateTime dueDate)
    {
        BookItem = book;
        DueDate = dueDate;
        book.BookStatus = BookStatus.Loaned; // Update book status
    }

    internal decimal CalculateFine()
    {
        if (DateTime.Now > DueDate)
        {
            var daysLate = (DateTime.Now - DueDate).Days;
            return daysLate * 0.5m; // Assuming a fine of 0.5 per day late
        }
        return 0;
    }
}



