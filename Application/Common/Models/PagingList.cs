namespace Application.Common.Models;

public class PaginatedList<T> : GeneralResponse
{
    public IReadOnlyCollection<T>? Items { get; set; }
    public int PageNumber { get; set; }
    public int TotalPages { get; set; }
    public int TotalCount { get; set; }
    public PaginatedList()
    {
    }
    public PaginatedList(IReadOnlyCollection<T> items, int count, int pageNumber, int pageSize)
    {
        PageNumber = pageNumber;
        TotalPages = pageSize == 0 ? 1 : (int)Math.Ceiling(count / (double)pageSize);
        TotalCount = count;
        Items = items;
    }


    public static PaginatedList<T> CreateAsync(IQueryable<T> source, int pageNumber, int pageSize, bool? GetAll = false)
    {

        if (GetAll != null && GetAll == true)
        {
            var items = source.ToList();

            var count = source.Count();

            return new PaginatedList<T>(items, count, pageNumber, pageSize);
        }
        else
        {
            var items = source.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();

            var count = source.Count();

            return new PaginatedList<T>(items, count, pageNumber, pageSize);
        }
    }
}