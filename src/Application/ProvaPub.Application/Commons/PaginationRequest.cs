namespace ProvaPub.Application.Commons
{
    public abstract class PaginationRequest(
        int page,
        int perPage)
    {
        public int Page { get; } = page <= 0 ? 1 : page;
        public int PerPage { get; set; } = perPage <= 0 ? 10 : perPage;
    }
}
