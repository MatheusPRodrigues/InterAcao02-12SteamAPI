using Steam.Models.ResponseAPIReviews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Steam.Models
{
    public class ReviewPersistence
    {
        public string Id { get; set; }
        public int GameId { get; set; }
        public QuerySummary QuerySummary { get; set; }

        public ReviewPersistence(int gameId, QuerySummary querySummary)
        {
            GameId = gameId;
            QuerySummary = querySummary;
        }
    }
}
