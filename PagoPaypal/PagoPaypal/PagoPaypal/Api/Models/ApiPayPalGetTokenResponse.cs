﻿using System;

namespace PagoPaypal
{
	
	public class PayPalGetTokenResponse {
		
//		public string Scope { get; set; }
		public string AccessToken { get; set; }
//		public string TokenType { get; set; }
//		public string AppId { get; set; }
//		public int ExpiresIn { get; set; }

		public string DisplayError { get; set; }
	}
}

