﻿using System.ComponentModel.DataAnnotations;

namespace Website.Domain.Entities
{
	public class ServiceItem: EntityBase 
	{
		[Required(ErrorMessage = "Заполните название услуги")]

		[Display(Name = "Название услуги (заголовок)")]
		public override string? Title { get; set; } 


		[Display(Name = "Краткое описание услуги")]
		public override string? Subtitle { get; set; }


		[Display(Name = "Полное описание услуги")]
		public override string? Text{ get; set; }
	}
}
