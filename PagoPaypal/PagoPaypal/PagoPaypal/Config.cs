using System;

namespace PagoPaypal
{
	
	public static class Config {

		static AppEnvironment AppEnvironment = AppEnvironment.Development;

		// Base Api url
		const string DevelopmentApiUrl = "https://api.sandbox.paypal.com/v1";
		const string ProductionApiUrl = "https://api.paypal.com/v1";

		// Client Id
		const string DevelopmentApiClientId = "AX0wlnujV6SAr87nBe63_Ma4YrkAmNp4nnp82WmzyuT2Ch4Tmg82aFj5VAN4rxpd8bYJoIGWF8s4ZHwI";
		const string ProductionApiClientId = "";

		// Secret
		const string DevelopmentApiSecret = "EFrRPLCHPaGTbyhz9WXzgwKR79ygNzOSwW-xiVbIOuEYhEF8awgkJzKimClu-W61tY6UU-AGsS1bkFyO";
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

