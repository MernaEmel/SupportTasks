﻿using System.ComponentModel.DataAnnotations;

namespace SupportTask2.Models
{
    public class BlogType
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public String Name { get; set; }

    }
}
