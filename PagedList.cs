using System.Collections.Generic;

namespace PagedList;

public class PagedList<T>
{
    public List<T> Items { get; set; }
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
    public int Total { get; set; }

    public PagedList(List<T> items, int pageNumber, int pageSize, int total)
    {
        Items = items;
        PageNumber = pageNumber;
        PageSize = pageSize;
        Total = total;
    }

    public int LastPage()
    {
        var result = (float)Total;
        result /= PageSize;
        return (int)Math.Ceiling(result);
    }

    public bool HasNextPage()
    {
        return PageNumber < LastPage();
    }

    public int? NextPage()
    {
        if (HasNextPage()) return PageNumber + 1;
        return 1;
    }

    public bool HasPreviousPage()
    {
        return PageNumber > 1;
    }

    public int? PreviousPage()
    {
        if (HasPreviousPage()) return PageNumber - 1;
        return LastPage();
    }
}
