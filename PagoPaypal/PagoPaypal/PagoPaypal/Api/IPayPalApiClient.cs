using System;
using System.Threading.Tasks;

namespace PagoPaypal
{
	public interface IPayPalApiClient
	{
		Task<PayPalGetTokenResponse> GetAccessToken();
		Task<PayPalExecutePaymentResult> MakePayment(PayPalMakePaymentData infoPago);
		Task<string> ExecuteApprovedPayment(string payerId, string accessToken, string paymentId);
	}
}

