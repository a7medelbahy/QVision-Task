using System.ComponentModel.DataAnnotations;

namespace QVision_Task.Models
{
    public class Account
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
