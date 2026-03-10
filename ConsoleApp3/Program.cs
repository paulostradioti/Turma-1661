namespace ConsoleApp3
{
    public enum NotificationType
    {
        SMS,
        WhatsApp,
        Email
    }

    public class Notification
    {
        public NotificationType Type { get; set; }
        public string Recipient { get; set; }
        public string Message { get; set; }
    }

    public interface INotificationSender
    {
        void Send(Notification notification);
    }

    public class EmailNotificationSender : INotificationSender
    {
        public void Send(Notification notification)
        {
            Console.WriteLine("Enviando Notificação por E-mail");
            Console.WriteLine($"{notification.Recipient} - {notification.Message}");
        }
    }

    public class SmsNotificationSender : INotificationSender
    {
        public void Send(Notification notification)
        {
            Console.WriteLine("Enviando Notificação por SMS");
            Console.WriteLine($"{notification.Recipient} - {notification.Message}");
        }
    }

    public class WhatsAppNotificationSender : INotificationSender
    {
        public void Send(Notification notification)
        {
            Console.WriteLine("Enviando Notificação por WhatsApp");
            Console.WriteLine($"{notification.Recipient} - {notification.Message}");
        }
    }


    internal class Program
    {
        static void Main(string[] args)
        {
            // 1 - Tipo da Notificação (SMS, WhatsApp, Email)
            // 2 - Destinatário 
            // 3 - Mensagem
            var notifications = new List<Notification>
            {
                new Notification { Type = NotificationType.SMS, Recipient = "123456789", Message = "Olá, esta é uma notificação por SMS!" },
                new Notification { Type = NotificationType.WhatsApp, Recipient = "987654321", Message = "Olá, esta é uma notificação por WhatsApp!" },
                new Notification { Type = NotificationType.Email, Recipient = "paulo@paulo.eti.br", Message = "Olá, esta é uma notificação por Email!" }
            };

            var senders = new Dictionary<NotificationType, INotificationSender>
            {
                { NotificationType.Email, new EmailNotificationSender() },
                { NotificationType.SMS, new SmsNotificationSender() },
                { NotificationType.WhatsApp, new WhatsAppNotificationSender() },
            };

            foreach (var notification in notifications)
            {
                senders.TryGetValue(notification.Type, out var sender);
                sender.Send(notification);
            }
        }
    }
}