using MediatR;
using MiniEticaret.Application.RequestParameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniEticaret.Application.Features.Queries.GetAllProduct
{
    public class GetAllProductQueryRequest: IRequest<GetAllProductQueryResponse>
    {
        public Pagination pagination { get; set; }
    }
}
