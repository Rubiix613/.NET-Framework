using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab5.Models
{
    public enum Question
    {
        Earth, Computer
    }

    public class AnswerImage
    {
        [Required]
        [Column("Id")]
        public int AnswerImageId {get; set;}

        [Required]
        [StringLength(50)]
        [Column("FileName")]
        public String FileName {get; set;}

        [Required]
        [StringLength(50)]
        [Column("Url")]
        public String Url {get; set;}

        [Required]
        [Column("Question")]
        public Question Question {get; set;}
        
    }
}

