using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Swashbuckle.AspNetCore.Annotations;

namespace Lab6.Models
{
	public class Student
	{
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [SwaggerSchema(ReadOnly = true)]
        [Required]
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

        [Required]
        public string Program {
            get;
            set;
        }


	}
}

