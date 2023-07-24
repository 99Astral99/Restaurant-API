using System.ComponentModel.DataAnnotations;

namespace Restaraunt.WebApi.Models.Identity
{
	public class RegisterRequest
	{
		[Required]
		[Display(Name = "Email")]
		public string Email { get; set; } = null!;

		[Required]
		[Display(Name = "User Name")]
		public string UserName { get; set; } = null!;

		[Required]
		[DataType(DataType.Password)]
		[Display(Name = "Password")]
		public string Password { get; set; } = null!;

		[Required]
		[Compare("Password", ErrorMessage = "Password mismatch")]
		[DataType(DataType.Password)]
		[Display(Name = "Confirm password")]
		public string PasswordConfirm { get; set; } = null!;
	}
}
