namespace ProvaPub.Application.Commons
{
    public abstract class PaginationRequest(
        int page,
        int perPage = 10)
    {
        public int Page { get; } = page;
        public int PerPage { get; } = perPage;
    }
}
