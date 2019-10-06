using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApiJwt.Models
{
    public class Job
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


        public List<Person> Persons { get; set; } //1-n
    }
}