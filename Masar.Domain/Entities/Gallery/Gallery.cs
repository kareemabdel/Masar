using Masar.Domain.Entities.Comman;

namespace Masar.Domain.Entities
{
    public class Gallery : BaseEntity
    {    
        public Guid Id { get; set; }
        public string  FilePath { get; set; }
        public string? Description { get; set; }
        public string? FileName { get; set; }
        public Guid AddedById { get; set; }
        public virtual ApplicationUser AddedBy { get; set; }


    }
}
