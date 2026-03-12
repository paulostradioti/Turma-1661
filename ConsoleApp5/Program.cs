namespace ConsoleApp5
{
    public class Notificacao
    {
        public virtual void Enviar()
        {
            Console.WriteLine("Enviando notificação genérica.");
        }
    }

    public class NotificacaoEmail : Notificacao
    {
        public override void Enviar()
        {
            Console.WriteLine("Enviando notificação por e-mail.");
        }
    }
    
    public class NotificacaoSMS : Notificacao
    {
        public new void Enviar()
        {
            Console.WriteLine("Enviando notificação por SMS.");
        }
    }


    internal class Program
    {
        static void Main(string[] args)
        {
            Notificacao notificacao = new NotificacaoSMS();
            notificacao.Enviar();
        }
    }
}
