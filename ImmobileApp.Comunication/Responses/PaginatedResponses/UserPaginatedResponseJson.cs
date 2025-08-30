using ImmobileApp.Comunication.Requests;
using ImmobileApp.Comunication.Responses.LongResponses;
using ImmobileApp.Comunication.Responses.ShortResponses;
using Microsoft.VisualBasic;

namespace ImmobileApp.Comunication.Responses.PaginatedResponses
{
    public class UserPaginatedResponse
    {
        public List<UserLongResponseJson> Users { get; set; } = [];
        public PaginationParams PaginationParams { get; set; } = null!;

        public int TotalAmount { get; set; } 

        public int PageNumber { get; set; }
    }
}
