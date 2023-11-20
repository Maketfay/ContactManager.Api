namespace Infrastucture.Core
{
    public interface IPagedList<T>
    {
        public IEnumerable<T> Items { get; set; }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public int TotalItemsCount { get; set; }
    }
}
