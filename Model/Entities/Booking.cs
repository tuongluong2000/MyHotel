namespace Model.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Booking")]
    public partial class Booking
    {
        public int ID { get; set; }

        public int RoomTypeID { get; set; }

        public DateTime CheckIn { get; set; }

        public DateTime CheckOut { get; set; }

        public DateTime? CompletedDate { get; set; }

        [Required]
        [StringLength(255)]
        public string GuessName { get; set; }

        [Required]
        [StringLength(50)]
        public string Email { get; set; }

        [Required]
        [StringLength(50)]
        public string PhoneNo { get; set; }

        public decimal TotalPrice { get; set; }

        public int Status { get; set; }

        public virtual RoomType RoomType { get; set; }
    }
}
