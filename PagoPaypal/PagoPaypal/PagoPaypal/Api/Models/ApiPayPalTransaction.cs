﻿using System;

namespace PagoPaypal
{
	public class PayPalTransaction {
		public PayPalAmount amount { get; set; }
		public PayPalItemList item_list { get; set; }
		public string description { get; set; }
	}
}

