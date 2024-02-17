// See https://aka.ms/new-console-template for more information
public class Catalog : ISearch
{

    public List<Book> Books{ get; set; }
   
    public List<Book> SearchByAuthors(string authors)
    {
        var blist= Books.Where(x=>x.Author == authors).ToList();
        return blist;
    }

    public List<Book> SearchByPubDates(int year)
    {
        var blist = Books.Where(x=>x.PubDate.Year==year).ToList();
        return blist;
    }

    public List<Book> SearchBySubjects(string subject)
    {
        var blist = Books.Where(x => x.Subject == subject).ToList();
        return blist;
    }

    public List<Book> SearchByTitles(string title)
    {
        var blist = Books.Where(x => x.Title == title).ToList();
        return blist;
    }
}


