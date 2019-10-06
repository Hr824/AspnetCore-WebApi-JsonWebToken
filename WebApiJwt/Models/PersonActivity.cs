using System;

namespace WebApiJwt.Models
{
    public class PersonActivity
    {
        public Guid PersonId { get; set; }
        public Person Person { get; set; }

        public Guid ActivityId { get; set; }
        public Activity Activity { get; set; }
    }
}