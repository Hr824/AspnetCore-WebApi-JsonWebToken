using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApiJwt.Models
{
    public class Person
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column("Id")]
        public Guid Id { get; set; }

        [Column("Lastname")]
        [Required]
        public string Lastname { get; set; }

        [Column("Firstname")]
        [Required]
        public string Firstname { get; set; }


        public Guid JobId { get; set; } //1-n foreign key
        public Job Job { get; set; }

        public List<PersonActivity> PersonActivities { get; set; } //n-n
    }
}