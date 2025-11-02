namespace PexelApiSearch.Infra.Database.SearchHistory.Queries
{
    public static class SearchHistoryQueries
    {
        public const string Insert = @"
            INSERT INTO SearchHistory (Id, Query, SearchDate)
            VALUES (@Id, @Query, @SearchDate);
        ";

        public const string SelectPaged = @"
            SELECT 
                sh.Id,
                sh.Query,
                sh.SearchDate
            FROM SearchHistory sh
            INNER JOIN (
                SELECT 
                    Query,
                    MAX(SearchDate) AS MaxDate
                FROM SearchHistory
                WHERE Query LIKE CONCAT('%', @QueryText, '%')
                GROUP BY Query
            ) grouped ON sh.Query = grouped.Query AND sh.SearchDate = grouped.MaxDate
            ORDER BY sh.SearchDate DESC
            LIMIT @PageSize OFFSET @Offset;
        ";


        public const string CountAll = @"
            SELECT COUNT(*) FROM SearchHistory;
        ";
    }
}
