using System.Runtime.CompilerServices;

namespace ConsoleApp2
{
    public interface IAnimal
    {
        void Comer();
    }

    public class Gato : IAnimal
    {
        // Implícita
        public void Comer()
        {
            Console.WriteLine("O gato está comendo.");
        }
    }
    public class Cachorro : IAnimal
    {
        // Explícita
        void IAnimal.Comer()
        {
            Console.WriteLine("O cachorro está comendo.");
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Gato miuau = new Gato();
            DarComidaAnimal(miuau);

            IAnimal doguinho = new Cachorro();
            DarComidaAnimal(doguinho);
        }

        private static void DarComidaAnimal(IAnimal animal)
        {
            animal.Comer();
        }
    }
}
