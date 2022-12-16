using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using ecommerce.Models;
using ecommerce.DAL;

namespace ecommerce.Models
{
    public class UserUniqueAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            EcommerceDotnetCoreDibboContext _context = new EcommerceDotnetCoreDibboContext();
            var entity = _context.Users.FirstOrDefault(e => e.PhoneNo == value.ToString());

            if (entity != null)
            {
                return new ValidationResult(GetErrorMessage(value.ToString()));
            }
            return ValidationResult.Success;
        }

        public string GetErrorMessage(string phoneNo)
        {
            return $"Phone {phoneNo} is already in use.";
        }
    }

    public class EmailUserUniqueAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            EcommerceDotnetCoreDibboContext _context = new EcommerceDotnetCoreDibboContext();
            var entity = _context.Users.FirstOrDefault(e => e.Email == value.ToString());

            if (entity != null)
            {
                return new ValidationResult(GetErrorMessage(value.ToString()));
            }
            return ValidationResult.Success;
        }

        public string GetErrorMessage(string email)
        {
            return $"Email {email} is already in use.";
        }
    }



}
