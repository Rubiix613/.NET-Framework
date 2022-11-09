using System;
using System.ComponentModel.DataAnnotations;

namespace Lab4.Models
{
    public class Client
    {
     
        public int Id {
            get;
            set;
        }

        [Required]
        [StringLength(50)]
        public string FirstName {
            get;
            set;
        }

        [Required]
        [StringLength(50)]
        public string LastName {
            get;
            set;
        }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Birth Date")]
        public DateTime BirthDate {
            get;
            set;
        }

        public string FullName
        {
            get
            {
                return LastName + ", " + FirstName;
            }
        }

        public IEnumerable<Subscription> Subscriptions {get; set; }
    }
}

