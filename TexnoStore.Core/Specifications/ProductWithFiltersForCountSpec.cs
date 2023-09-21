using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TexnoStore.Core.Entities;

namespace TexnoStore.Core.Specifications
{
    public class ProductWithFiltersForCountSpec: BaseSpecification<Product>
    {
        public ProductWithFiltersForCountSpec(ProductSpecParams productParams)
                        : base(x =>
                 (!productParams.BrandId.HasValue || x.ProductBrandId == productParams.BrandId) &&
                 (!productParams.TypeId.HasValue || x.ProductTypeId == productParams.TypeId)
            )
        {
            
        }
    }
}
