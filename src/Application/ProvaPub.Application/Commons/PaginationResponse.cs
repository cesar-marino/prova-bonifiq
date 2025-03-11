namespace ProvaPub.Application.Commons
{
    public abstract class PaginationResponse<TItems>(
        int page,
        int perPage,
        List<TItems> items)
    {
        public int Page { get; } = page;
        public int PerPage { get; } = perPage;
        public List<TItems> Items { get; } = items;
    }
}
