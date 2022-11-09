using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab4.Models
{
    public class Broker
    {

        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string Id
        {
            get;
            set;
        }

        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Title
        {
            get;
            set;
        }

        [DataType(DataType.Currency)]
        [Column(TypeName = "money")]
        public decimal Fee
        {
            get;
            set;
        }

        public IEnumerable<Subscription> Subscriptions {get; set; }
    }
}

