namespace Website.Service
{
	//Создаем спец класс-обертку, св-ва которого соответсвуют св-вам из файла appsettings.json
	public class Config
	{
		public static string ConnectionString { get; set; }

		public static string CompanyName { get; set; }

		public static string CompanyPhone { get; set; }

		public static string CompanyPhoneShort { get; set; }

		public static string CompanyEmail { get; set; }
	}
}
