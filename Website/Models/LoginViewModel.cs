using System.ComponentModel.DataAnnotations;

namespace Website.Models
{
	public class LoginViewModel
	{
		[Required]
		[Display(Name = "Логин")]
		public string UserName { get; set; }

		[Required]
		[Display(Name = "Password")]
		public string Password { get; set; }

		[Display(Name = "Запомнить меня?")]
		public bool RememberMe { get; set;}
	}
}
 