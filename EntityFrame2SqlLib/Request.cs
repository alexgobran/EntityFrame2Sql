﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityFrame2SqlLib
{
    public partial class Request
    {
        public Request()
        {
            RequestLine = new HashSet<RequestLine>();
        }

        public int Id { get; set; }
        [Required]
        [StringLength(80)]
        public string Description { get; set; }
        [Required]
        [StringLength(80)]
        public string Justification { get; set; }
        [StringLength(80)]
        public string RejectionReason { get; set; }
        [Required]
        [StringLength(20)]
        public string DeliveryMode { get; set; }
        [Required]
        [StringLength(10)]
        public string Status { get; set; }
        [Column(TypeName = "decimal(11, 2)")]
        public decimal Total { get; set; }
        public int? UserId { get; set; }

        [ForeignKey("UserId")]
        [InverseProperty("Request")]
        public virtual User User { get; set; }
        [InverseProperty("Request")]
        public virtual ICollection<RequestLine> RequestLine { get; set; }
    }
}
