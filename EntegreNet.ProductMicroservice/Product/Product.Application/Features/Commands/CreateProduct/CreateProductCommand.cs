using MediatR;

namespace Product.Application.Features.Commands.CreateProduct
{
    public class CreateProductCommand : IRequest<Guid>
    {
        public string ProductName { get; set; }

        public Guid ProductMainId { get; set; }

        public Guid BrandId { get; set; }

        public Guid CategoryId { get; set; }

        public decimal VatRate { get; set; }

        public string ProductMainCode { get; set; }
    }
}
