namespace TechTest.Repository
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Colour
    {
        public Colour()
        {
            People = new HashSet<Person>();
        }

        public int ColourId { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public bool IsEnabled { get; set; }

        public virtual ICollection<Person> People { get; set; }
    }
}
