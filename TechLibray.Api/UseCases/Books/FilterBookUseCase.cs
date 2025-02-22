using TechLibrary.Communication.Request;
using TechLibrary.Communication.Responses;
using TechLibray.Api.Infrastructure.DataAccess;

namespace TechLibray.Api.UseCases.Books;

public class FilterBookUseCase
{
    private const int PAGA_SIZE = 10;
    public ResponseBooksJson Execute(RequestFilterBooksJson request)
    {
        var dbContext = new TechLibraryDbContext();

        var query = dbContext.Books.AsQueryable();

        if (string.IsNullOrWhiteSpace(request.Title) == false)
            query = query.Where(book => book.Title.Contains(request.Title));

       var books =  query
            .OrderBy(book => book.Title)
            .ThenBy(book => book.Author)
            .Skip((request.PageNumber - 1) * PAGA_SIZE)
            .Take(PAGA_SIZE)
            .ToList();

        var totalCount = 0;
        if (string.IsNullOrWhiteSpace(request.Title))
            totalCount = dbContext.Books.Count();
        else
            totalCount = dbContext.Books.Count(book => book.Title.Contains(request.Title));


        return new ResponseBooksJson
        {
            Pagination = new ResponsePaginationJson
            {
                PageNumber = request.PageNumber,
                TotalCount = totalCount
            },
            Books = books.Select(book => new ResponseBookJson
            {
                Id = book.Id,
                Title = book.Title,
                Author = book.Author

            }).ToList()
        };
    }
}
