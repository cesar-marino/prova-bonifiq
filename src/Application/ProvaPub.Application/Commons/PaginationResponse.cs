namespace ProvaPub.Application.Commons
{
    public abstract class PaginationResponse<TItems>(
        int page,
        int perPage,
        bool hasNext,
        List<TItems> items)
    {
        public int Page { get; } = page;
        public int PerPage { get; } = perPage;
        public bool HasNext { get; } = hasNext;
        public List<TItems> Items { get; } = items;
    }
}
