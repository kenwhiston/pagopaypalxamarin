using System;

namespace PagoPaypal
{
	
	public static class Config {

		static AppEnvironment AppEnvironment = AppEnvironment.Development;

		// Base Api url
		const string DevelopmentApiUrl = "https://api.sandbox.paypal.com/v1";
		const string ProductionApiUrl = "https://api.paypal.com/v1";

		// Client Id
		const string DevelopmentApiClientId = "AfHuxESzuwIgRlkIsrVkiS1NqDrAmdUv7pworEvXqAxI9_WY2QjgX5xTHpzpy1EGdN5ms6r-QWBLSyMy";
		const string ProductionApiClientId = "";

		// Secret
		const string DevelopmentApiSecret = "EFkSSEuxjj4d4ATNkjAG_2J637WJ-aj8VKteA67vzaWfrdzj5m1DSRjdepAVP1iq4_Rb7NEsDwZtnEC9";
		const string ProductionApiSecret = "";

		public const string ReturnUrl = "http://www.google.com/";
		public const string CancelUrl = "http://www.google.com/";

		public static string ReturnHost = new Uri(Config.ReturnUrl).Host;
		public static string CancelHost = new Uri(Config.CancelUrl).Host;

		// PayPal Api Base Url
		public static string ApiUrl {
			get {
				if (AppEnvironment == AppEnvironment.Development) {

					return DevelopmentApiUrl;
				} else if (AppEnvironment == AppEnvironment.Production) {

					return ProductionApiUrl;
				}

				throw new NotImplementedException ();
			}
		}

		// PayPal Api Client Id
		public static string ApiClientId {
			get {
				if (AppEnvironment == AppEnvironment.Development) {

					return DevelopmentApiClientId;
				} else if (AppEnvironment == AppEnvironment.Production) {

					return ProductionApiClientId;
				}

				throw new NotImplementedException ();
			}
		}

		// PayPal Api Secret
		public static string ApiSecret {
			get {
				if (AppEnvironment == AppEnvironment.Development) {

					return DevelopmentApiSecret;
				} else if (AppEnvironment == AppEnvironment.Production) {

					return ProductionApiSecret;
				}

				throw new NotImplementedException ();
			}
		}
	}

	public enum AppEnvironment {
		Development,
		Production
	}
}

