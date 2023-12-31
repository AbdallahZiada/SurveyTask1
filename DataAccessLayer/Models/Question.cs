﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DataAccessLayer.Models
{
    public class Question
    {
        public int Id { get; set; }
        [Required]
        public string Body { get; set; }
        public bool IsDeleted { get; set; }
    }
}