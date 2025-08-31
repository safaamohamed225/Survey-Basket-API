namespace SurveyBasket.Contracts.Common
{
    public record RequestFilters
    {
        public int PageNumber { get; init; } = 1;
        public int PageSize { get; init; } = 10;

        public string? SearchTerm { get; init; }

        public string? SortBy { get; init; }
        public string? SortDirection { get; init; } = "ASC";
    }

}
