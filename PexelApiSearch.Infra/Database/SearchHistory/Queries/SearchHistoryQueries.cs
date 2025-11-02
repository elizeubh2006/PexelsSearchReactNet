namespace PexelApiSearch.Infra.Database.SearchHistory.Queries
{
    public static class SearchHistoryQueries
    {
        public const string Insert = @"
            INSERT INTO SearchHistory (Id, Query, SearchDate)
            VALUES (@Id, @Query, @SearchDate);
        ";

        public const string SelectPaged = @"
            SELECT * 
            FROM SearchHistory
            ORDER BY SearchDate DESC
            LIMIT @PageSize OFFSET @Offset;
        ";

        public const string CountAll = @"
            SELECT COUNT(*) FROM SearchHistory;
        ";
    }
}
