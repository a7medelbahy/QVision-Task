using System.ComponentModel.DataAnnotations;

namespace QVision_Task.ViewModels
{
    public class RegistVM
    {
        public int Id { get; set; }

        public string Name { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Compare("Password")]
        public string ConfirmPassword { get; set; }
    }
}
