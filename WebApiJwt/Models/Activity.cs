using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApiJwt.Models
{
    public class Activity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column("Id")]
        public Guid Id { get; set; }

        [Column("Code")]
        [Required]
        public string Code { get; set; }

        [Column("Title")]
        [Required]
        public string Title { get; set; }


        public List<PersonActivity> PersonActivities { get; set; } //n-n
    }
}