LinqQueries queries = new LinqQueries();

// PrintValues(queries.Collection());

// PrintValues(queries.BooksAfter2000Extension());

// PrintValues(queries.BooksAfter2000Query());

// PrintValues(queries.BooksWith250PageAndActionTitle(250, "Action"));

// Console.WriteLine(queries.BookWithStatus());

// Console.WriteLine(queries.BookPublishedInYear(2055));

// PrintValues(queries.BookBelongToCategory("python"));

// PrintValues(queries.OrderCollectionByTitle("java"));

// PrintValues(queries.OrderCollectionDescendingByPageNumber(450));

// PrintValues(queries.TakeFirstBookByCategory());

// Console.WriteLine(queries.NumberOfBooks(200, 500));

Console.WriteLine(queries.EarliestPublisheddate());
Console.WriteLine(queries.MaxPagesInCollection());

void PrintValues(IEnumerable<Book> listOfBooks) {
    Console.WriteLine("{0, -60} {1, 7} {2, 15}\n", "Title", "N. Page", "Date");
    foreach(var item in listOfBooks) {
    Console.WriteLine("{0, -60} {1, 7} {2, 15}", item.Title, item.PageCount, item.PublishedDate.ToShortDateString());
    }

}