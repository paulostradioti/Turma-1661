namespace ConsoleApp3
{
    public class PaymentDetails
    {
        public decimal Amount { get; set; }
    }

    public interface IPaymentMethod
    {
        void Pay(PaymentDetails paymentDetails);
    }

    public class PixPaymentDetails : PaymentDetails
    {
        public string Pixkey { get; set; }
    }

    public class PixPaymentMethod : IPaymentMethod
    {
        public void Pay(PaymentDetails paymentDetails)
        {
            var pixDetails = (PixPaymentDetails)paymentDetails;
            var chave = pixDetails.Pixkey;
            Console.WriteLine($"Processando Pagamento Pix - Chave: {chave} - Valor: {pixDetails.Amount}");
        }
    }

    public class CreditCardPaymentDetails : PaymentDetails
    {
        public string CardNumber { get; set; }
        public string CardHolder { get; set; }
        public string ExpirationDate { get; set; }
        public string CVV { get; set; }
    }

    public class CreditCardPaymentMethod : IPaymentMethod
    {
        public void Pay(PaymentDetails paymentDetails)
        {
            var creditCardDetails = (CreditCardPaymentDetails)paymentDetails;
            Console.WriteLine(creditCardDetails.CardNumber);
            Console.WriteLine($"Processando Pagamento Cartão de Crédito - Titular: {creditCardDetails.CardHolder} - Valor: {creditCardDetails.Amount}");
        }
    }


    public class BoletoPaymentDetails : PaymentDetails
    {
        public string LinhaDigitavel { get; set; }
    }

    public class BoletoPaymentMethod: IPaymentMethod
    {
        public void Pay(PaymentDetails paymentDetails)
        {
            Console.WriteLine($"Processando Pagamento Boleto - Linha Digitável: {((BoletoPaymentDetails)paymentDetails).LinhaDigitavel} - Valor: {paymentDetails.Amount}");
        }
    }


    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("""
                Qual o método de pagamento?
                   1 - Pix
                   2 - Credit Card
                   3 - Boleto
                """);

            var option = Console.ReadLine();

            PaymentDetails paymentDetails = default;
            string methodChoice = default;

            if (option == "1")
            {
                Console.WriteLine("Informe a chave pix");
                var pixKey = Console.ReadLine();

                paymentDetails = new PixPaymentDetails() { Pixkey = pixKey, Amount = 100 };
                methodChoice = "Pix";
            }
            else if (option == "2")
            {
                paymentDetails = new CreditCardPaymentDetails
                {
                    Amount = 100,
                    CardNumber = "4111111111111111",
                    CardHolder = "John Doe",
                    ExpirationDate = "12/25",
                    CVV = "123"
                };
                methodChoice = "CreditCard";
            }
            else if (option == "3")
            {
                paymentDetails = new BoletoPaymentDetails
                {
                    Amount = 100,
                    LinhaDigitavel = "23793381286006800000000000000000000000000000"
                };
                methodChoice = "Boleto";
            }

            var paymentMethods = new Dictionary<string, IPaymentMethod>
            {
                { "Pix", new PixPaymentMethod() },
                { "CreditCard", new CreditCardPaymentMethod() },
                { "Boleto", new BoletoPaymentMethod() }
             };

            paymentMethods.TryGetValue(methodChoice, out var paymentMethod);
            paymentMethod.Pay(paymentDetails);
        }
    }
}