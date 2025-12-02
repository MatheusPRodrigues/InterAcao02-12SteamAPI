using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Steam.Models.ResponseAPIReviews
{
    public class ResponseReview
    {
        [JsonPropertyName("query_summary")]
        public QuerySummary QuerySummary { get; set; }
    }
}
