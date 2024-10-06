using MediatR;
using Product.Application.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Application.Features.Queries.GetAllProducts
{
    public class GetAllProductsQuery : IRequest<List<ProductVM>>
    {
        public GetAllProductsQuery() { }
    }
}
