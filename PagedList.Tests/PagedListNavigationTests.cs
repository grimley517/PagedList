namespace PagedList.Tests;

public class PagedListNavigationTests
{
    private static PagedList<int> Build(int pageNumber, int pageSize, int total)
    {
        return new PagedList<int>(new List<int>(), pageNumber, pageSize, total);
    }

    [Fact]
    public void Constructor_SetsAllProperties()
    {
        var items = new List<int> { 1, 2, 3 };
        var list = new PagedList<int>(items, 2, 10, 25);

        Assert.Same(items, list.Items);
        Assert.Equal(2, list.PageNumber);
        Assert.Equal(10, list.PageSize);
        Assert.Equal(25, list.Total);
    }

    [Theory]
    [InlineData(1, 10, 25, true)]
    [InlineData(3, 10, 25, false)]
    [InlineData(2, 10, 25, true)]
    public void HasNextPage_ReturnsExpected(int pageNumber, int pageSize, int total, bool expected)
    {
        Assert.Equal(expected, Build(pageNumber, pageSize, total).HasNextPage());
    }

    [Theory]
    [InlineData(1, 10, 25, 2)]
    [InlineData(3, 10, 25, 1)]
    public void NextPage_ReturnsExpected(int pageNumber, int pageSize, int total, int expected)
    {
        Assert.Equal(expected, Build(pageNumber, pageSize, total).NextPage());
    }

    [Theory]
    [InlineData(1, 10, 25, false)]
    [InlineData(2, 10, 25, true)]
    public void HasPreviousPage_ReturnsExpected(int pageNumber, int pageSize, int total, bool expected)
    {
        Assert.Equal(expected, Build(pageNumber, pageSize, total).HasPreviousPage());
    }

    [Theory]
    [InlineData(2, 10, 25, 1)]
    [InlineData(1, 10, 25, 3)]
    public void PreviousPage_ReturnsExpected(int pageNumber, int pageSize, int total, int expected)
    {
        Assert.Equal(expected, Build(pageNumber, pageSize, total).PreviousPage());
    }
}
