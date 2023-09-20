using AutoMapper;
using TenoStore.API.Dtos;
using TexnoStore.Core.Entities;

namespace TenoStore.API.Helpers
{
    public class ProductUrlReslover : IValueResolver<Product, ProductToReturnDto, string>
    {
        private readonly IConfiguration _configuration;
        public ProductUrlReslover(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public string Resolve(Product source, ProductToReturnDto destination, string destMember, ResolutionContext context)
        {
           if(!string.IsNullOrEmpty(source.PictureUrl)) 
           {
                return _configuration["ApiUrl"] + source.PictureUrl;    
           }
            return null;
        }
    }
}
