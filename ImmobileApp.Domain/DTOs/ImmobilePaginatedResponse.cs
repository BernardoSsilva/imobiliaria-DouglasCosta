using ImmobileApp.Comunication.Requests;
using ImmobileApp.Comunication.Responses.ShortResponses;
using ImmobileApp.Domain.Entities;

namespace ImmobileApp.Domain.Responses.RawResponses
{
    public class ImmobilePaginatedResponse
    {
        public PaginationParams paginationParams { get; set; } = null!;
        public List<ImmobileEntity> immobiles { get; set; } = [];

        public int TotalAmount { get; set; }

        public int PageNumber { get; set; }
    }
}
