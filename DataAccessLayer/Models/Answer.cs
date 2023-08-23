using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DataAccessLayer.Models
{
    public class Answer
    {
        public int Id { get; set; }
        public string AnswwerText { get; set; }
        public int QuestionId { get; set; }
        public virtual Question Question { get; set; }
        public int SurveyId { get; set; }
        public virtual Survey Survey { get; set; }
    }
}