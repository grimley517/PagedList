namespace PagedList.Tests;

public class PagedListTests
{
    [Theory]
    [InlineData(0, 10, 0)]
    [InlineData(1, 10, 1)]
    [InlineData(10, 10, 1)]
    [InlineData(11, 10, 2)]
    [InlineData(11, 11, 1)]
    [InlineData(102, 10, 11)]
    public void LastPageNumber_Calculations(int totalItems, int pageSize, int lastPage)
    {
        var contents = new List<int>();
        var list = new PagedList<int>(contents, 1, pageSize, totalItems);

        Assert.Equal(lastPage, list.LastPage());
    }
}