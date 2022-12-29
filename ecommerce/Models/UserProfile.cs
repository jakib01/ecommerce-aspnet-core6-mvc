using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ecommerce.Models
{
    public partial class UserProfile
    {
        public int ProfileId { get; set; }
        [ForeignKey("UserId")]
        public int UserId { get; set; }
        public string? FullName { get; set; }
        public string? NidNo { get; set; }
        public string? TinNo { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? UserType { get; set; }
        public string? Address { get; set; }
        public string? ShippingAddress { get; set; }
        public string? Photo { get; set; }
        public byte? IsActive { get; set; }
        public byte? IsEmailVerified { get; set; }
        public DateTime? EmailVerifiedAt { get; set; }
        public int? VerifiedBy { get; set; }
        public DateTime? VerifiedDate { get; set; }
        public DateTime? RegistrationDate { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public DateTime? DeletedDate { get; set; }
        public virtual User? User { get; set; }
    }
}
