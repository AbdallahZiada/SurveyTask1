using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DataAccessLayer.Models
{
    public class Survey
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public virtual IList<Answer> Answers { get; set; }
    }
}