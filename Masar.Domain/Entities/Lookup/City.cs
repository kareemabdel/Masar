﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Masar.Domain.Entities.Comman;

namespace Masar.Domain.Entities
{
    public class City:BaseEntity<Guid>
    { 
        public string Code { get; set; }
        public string EnglishDescription { get; set; }
        public string ArabicDescription { get; set; }
       
    }

   
}
