namespace Model.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Room")]
    public partial class Room
    {
        public int ID { get; set; }

        public int Type { get; set; }

        [Required]
        [StringLength(10)]
        public string Number { get; set; }

        public virtual RoomType RoomType { get; set; }
    }
}
