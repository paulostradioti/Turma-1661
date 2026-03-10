namespace ConsoleApp3
{
    // Herança -> É
    // Interface -> Tem/Pode Fazer/Capacidade

    // Stream Open
    // IReadStream -> Leitura
    // IWriteStream -> Escrita
    // class ReadWriteStream :  IReadStream, IWriteStream {}

    public interface IScanner
    {
        void Execute();
    }

    public interface IPrinter
    {
        public string Text { get; set; }
        void Execute();

        void LimparJatosTinta();
    }

    public class HpPrinter : IPrinter
    {
        public string Text { get; set; }
        public void Execute()
        {
            Console.WriteLine($"HP Printer: {Text}");
        }

       void IPrinter.LimparJatosTinta()
        {
            Console.WriteLine("Limpar Jatos de Tinta");
        }
    }

    public class CanonScanner : IScanner
    {
        public void Execute()
        {
            var texto = Console.ReadLine();
            Console.WriteLine($"Scanner: {texto}");
        }
    }

    public class Multifuncional : IScanner, IPrinter
    {
        public string Text { get; set; }

        public void LimparJatosTinta()
        {
            Console.WriteLine("Limpando jatos...");
        }

        //public void Execute()
        //{
        //    Console.WriteLine($"Texto do Print: {Text}");

        //    Console.WriteLine("Digite Algo:");
        //    var texto = Console.ReadLine();

        //    Console.WriteLine($"Texto do Scanner: {texto}");
        //}

        void IScanner.Execute()
        {
            Console.WriteLine("Digite Algo:");
            var texto = Console.ReadLine();

            Console.WriteLine($"Texto do Scanner: {texto}");
        }

        void IPrinter.Execute()
        {
            Console.WriteLine($"Texto do Print: {Text}");
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            //var printer = new HpPrinter() { Text = "Hello World" };
            //printer.Execute();

            //var scanner = new CanonScanner();
            //scanner.Execute();

            //var multi = new Multifuncional();
            //multi.Text = "Texto do Print";

            //ExecuteComoPrinter(multi);

            //ExecuteComoScanner(multi);

            var printer = new HpPrinter() { Text = "Hello World" };
            ((IPrinter)printer).LimparJatosTinta();
        }

        public static void ExecuteComoScanner(IScanner scanner)
        {
            scanner.Execute();
        }

        public static void ExecuteComoPrinter(IPrinter printer)
        {
            printer.Execute();
        }
    }
}