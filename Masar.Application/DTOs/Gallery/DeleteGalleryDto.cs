﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Masar.Application.DTOs
{
    public class DeleteGalleryDto
    {
        public Guid Id { get; set; }
        public string FilePath { get; set; }
    }
}
