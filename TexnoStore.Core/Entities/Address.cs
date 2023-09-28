using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TexnoStore.Core.Entities
{
    public class Address : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        [Required]
        [ForeignKey(nameof(AppUser))]
        public string AppUserId { get; set; }
        public AppUser AppUser { get; set; }
    }
}