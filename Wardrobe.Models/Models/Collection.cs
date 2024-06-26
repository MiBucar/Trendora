﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wardrobe.Models.Models
{
    public class Collection
    {
        [Key]
        public int CollectionId { get; set; }
        [Required]
        public string Name { get; set; }
        public List<Gender> Genders { get; set; }
        public List<Tag> Tags { get; set; }
    }
}
