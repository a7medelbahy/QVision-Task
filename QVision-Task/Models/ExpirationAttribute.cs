using System.ComponentModel.DataAnnotations;

namespace QVision_Task.Models
{
    public class ExpirationAttribute:ValidationAttribute
    {
        private readonly DateTime _minDate;


        public ExpirationAttribute()
        {
            _minDate = DateTime.Now;
        }

        public override bool IsValid(object value)
        {

            DateTime dateTime = (DateTime)value;
            return dateTime > _minDate;
        }

        public override string FormatErrorMessage(string name)
        {
            return $"{name} Expiration Date must be older than the current time";
        }
    }
}
