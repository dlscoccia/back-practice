using System.Security.Cryptography.X509Certificates;

public class LinqQueries {
    
    private List<Book> booksCollection = new List<Book>();
    public LinqQueries() {
        using(StreamReader reader = new StreamReader("books.json")) {
            string json = reader.ReadToEnd();

            this.booksCollection = System.Text.Json.JsonSerializer.Deserialize<List<Book>>(json, new System.Text.Json.JsonSerializerOptions() {PropertyNameCaseInsensitive = true})!;
        
        }
    }

    public IEnumerable<Book> Collection() {
        return booksCollection;
    }

    public IEnumerable<Book> BooksAfter2000Extension() {
        return booksCollection.Where(book => book.PublishedDate.Year > 2000);
    }
    
    public IEnumerable<Book> BooksAfter2000Query() {
        return from book in booksCollection where book.PublishedDate.Year > 2000 select book;
    }

    public IEnumerable<Book> BooksWith250PageAndActionTitle(int pages, string word) {
        return booksCollection.Where(book => book.PageCount > pages && book.Title.Contains(word));
    }

    public IEnumerable<Book> BooksWith250PageAndActionTitleQuery(int pages, string word) {
        return from book in booksCollection where book.PageCount > pages && book.Title.Contains(word) select book;
    }

    public bool BookWithStatus() {
        return booksCollection.All(book => book.Status != "");
    }

    public bool BookPublishedInYear(int year) {
        return booksCollection.Any(book => book.PublishedDate.Year == year);
    }

    public IEnumerable<Book> BookBelongToCategory(string category) {
        return booksCollection.Where(book => book.Categories.Contains(category, StringComparer.CurrentCultureIgnoreCase));
    }

    public IEnumerable<Book> OrderCollectionByTitle(string category) {
        return BookBelongToCategory(category).OrderBy(book => book.Title);

    }
    public IEnumerable<Book> OrderCollectionDescendingByPageNumber(int pageNumber) {
        return booksCollection.Where(book => book.PageCount > pageNumber).OrderByDescending(book => book.PageCount);
    }

    public IEnumerable<Book> TakeFirstBookByCategory() {
        return booksCollection.Where(book => book.Categories.Contains("Java")).OrderByDescending(book => book.PublishedDate).Take(3);
    }

    public IEnumerable<Book> SkipSomeBooks() {
        return booksCollection.Where(book => book.PageCount > 400).Take(4).Skip(2);
    }

    public IEnumerable<ShortBook> FirstBooksOfCollection() {
        return booksCollection.Take(3).Select(book => new ShortBook() { Title = book.Title, PageCount = book.PageCount });
    }

    public int NumberOfBooks(int min, int max) {
        return booksCollection.Count(book => book.PageCount >= min && book.PageCount <= max);
    }

    public DateTime EarliestPublisheddate() {
        return booksCollection.Min(book => book.PublishedDate);
    }

    public int MaxPagesInCollection() {
        return booksCollection.Max(book => book.PageCount);
    }

    public Book BookWithLessPages() {
        return booksCollection.Where(book => book.PageCount > 0).MinBy(book => book.PageCount);
    }
}

public class ShortBook {
    public string? Title {get; set;}
    public int? PageCount {get; set;}
}