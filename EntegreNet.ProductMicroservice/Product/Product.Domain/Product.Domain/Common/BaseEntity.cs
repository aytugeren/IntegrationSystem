using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Domain.Common
{
    public class BaseEntity
    {
        public Guid? Id { get; set; }

        public DateTime? CreatedDateTime { get; set; }

        public DateTime? UpdatedDateTime { get; set; }

        public bool? IsActive { get; set; }

        public bool IsDeleted { get; set; }

        public Guid StatusId { get; set; }
    }
}
