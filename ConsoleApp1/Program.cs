namespace ConsoleApp1
{
    public interface IVoador
    {
        void Voar();
    }

    public interface IAndador
    {
        void Andar();
    }
    public interface INadador
    {
        void Nadar();
    }

    public class Pato : IVoador, IAndador, INadador
    {
        public void Voar()
        {
            Console.WriteLine("Pato voando");
        }
        public void Andar()
        {
            Console.WriteLine("Pato andando");
        }
        public void Nadar()
        {
            Console.WriteLine("Pato nadando");
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
    }
}
