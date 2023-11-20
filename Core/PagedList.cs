using Infrastucture.Core;

namespace Core
{
    public class PagedList<T>: IPagedList<T> 
    {
        public IEnumerable<T> Items { get; set; }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public int TotalItemsCount { get; set; }
    }
}
