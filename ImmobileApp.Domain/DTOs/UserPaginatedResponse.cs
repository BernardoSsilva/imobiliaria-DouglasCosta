using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ImmobileApp.Comunication.Requests;
using ImmobileApp.Comunication.Responses.ShortResponses;
using ImmobileApp.Domain.Entities;

namespace ImmobileApp.Domain.Responses.RawResponses
{
    public class UserPaginatedResponse

    {
        public List<UserEntity> Users { get; set; } 
        public PaginationParams PaginationParams { get; set; } 

        public int TotalAmount { get; set; }

        public int PageNumber { get; set; }
    }
}

