// See https://aka.ms/new-console-template for more information
public interface ISearch
{
    public List<Book> SearchByTitles (string title);
    public List<Book> SearchByAuthors (string authors);
    public List<Book> SearchByPubDates(int year);
    public List<Book> SearchBySubjects (string subject);
}


