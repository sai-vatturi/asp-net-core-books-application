using System;
using System.ComponentModel.DataAnnotations;

namespace BloodBankAPI.Models
{
    public enum BloodStatus
    {
        Available,
        Requested,
        Expired
    }

    public class BloodBankEntry
    {
        public Guid Id { get; set; } // Auto-generated unique identifier

        [Required(ErrorMessage = "Donor name is required.")]
        [StringLength(100, ErrorMessage = "Donor name can't exceed 100 characters.")]
        public required string DonorName { get; set; } // Name of the donor

        [Range(18, 65, ErrorMessage = "Age must be between 18 and 65.")]
        public int Age { get; set; } // Donor's age

        [Required(ErrorMessage = "Blood type is required.")]
        [RegularExpression(@"^(A|B|AB|O)[+-]$", ErrorMessage = "Invalid blood type.")]
        public required string BloodType { get; set; } // Blood group (e.g., A+, O-)

        [Required(ErrorMessage = "Contact information is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public required string ContactInfo { get; set; } // Contact details (phone/email)

        [Range(100, 1000, ErrorMessage = "Quantity must be between 100ml and 1000ml.")]
        public int Quantity { get; set; } // Quantity of blood donated (in ml)

        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Collection date is required.")]
        public DateTime CollectionDate { get; set; } // Collection date

        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Expiration date is required.")]
        [DateGreaterThan("CollectionDate", ErrorMessage = "Expiration date must be after collection date.")]
        public DateTime ExpirationDate { get; set; } // Expiration date

        [Required(ErrorMessage = "Status is required.")]
        public required string Status { get; set; } // Status (Available, Requested, Expired)
    }

    // Custom validation attribute to ensure ExpirationDate is after CollectionDate
    public class DateGreaterThanAttribute : ValidationAttribute
    {
        private readonly string _comparisonProperty;

        public DateGreaterThanAttribute(string comparisonProperty)
        {
            _comparisonProperty = comparisonProperty;
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value is null)
                return new ValidationResult(ErrorMessage);

            var currentValue = (DateTime)value;

            var property = validationContext.ObjectType.GetProperty(_comparisonProperty);

            if (property == null)
                throw new ArgumentException("Property with this name not found");

            var comparisonValue = property.GetValue(validationContext.ObjectInstance);

            if (comparisonValue == null)
                throw new ArgumentException("Comparison property value is null");

            var comparisonDate = (DateTime)comparisonValue;

            if (currentValue <= comparisonDate)
                return new ValidationResult(ErrorMessage);

            return ValidationResult.Success;
        }
    }
}
