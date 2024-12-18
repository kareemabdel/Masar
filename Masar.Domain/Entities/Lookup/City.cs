using System;
using System.Collections.Generic;
using Masar.Domain.Entities.Comman;

namespace Masar.Domain.Entities
{
    public class City:BaseEntity
    { 
        public Guid Id { get; set; }
        public string Code { get; set; }
        public string EnglishDescription { get; set; }
        public string ArabicDescription { get; set; }
       
    }

   
}
