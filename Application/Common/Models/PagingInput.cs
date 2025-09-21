namespace Application.Common.Models;

public class PaginationInput
{
    public int CurrentPage { get; set; }
    public int TakenRows { get; set; }
    public int Count { get; set; }
    public bool? GetAll { get; set; } = false;
}
