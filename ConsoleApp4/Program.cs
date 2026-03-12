using System.Globalization;

namespace ConsoleApp4
{
    internal class Program
    {
        public abstract class Veiculo
        {
            public string Modelo { get; set; }
            public string Marca { get; set; }
            public string Placa { get; set; }
            public abstract string Categoria { get; }
            public abstract decimal CalcularAluguel(int dias);
            public virtual decimal AplicarDesconto(int dias, decimal valorOriginal)
            {
                Console.WriteLine("Executou o desconto da classe BASE");

                if (dias >= 10)
                    return valorOriginal * 0.9m; // 10% de desconto

                return valorOriginal;
            }

            public override string ToString()
                => $"{Categoria} - Marca: {Marca}, Modelo: {Modelo}, Placa: {Placa}";
        }

        public class Carro : Veiculo
        {
            public override string Categoria => "Carros";

            public int QuantidadePortas { get; set; }

            public override decimal CalcularAluguel(int dias)
            {
                var diaria = QuantidadePortas > 2 ? 150 : 100;
                return AplicarDesconto(dias, diaria * dias);
            }

            public override string ToString()
                 => string.Concat(base.ToString(), $", Portas: {QuantidadePortas}");
        }

        public class Moto : Veiculo
        {
            public override string Categoria => "Motos";

            public int Cilindradas { get; set; }

            public override decimal CalcularAluguel(int dias)
            {
                var diaria = Cilindradas > 500 ? 80 : 50;
                return AplicarDesconto(dias, diaria * dias);
            }

            public override string ToString()
           => string.Concat(base.ToString(), $", Cilindradas: {Cilindradas}");
        }

        public class Caminhao : Veiculo
        {
            public override string Categoria => "Caminhões";
            public int CapacidadeToneladas { get; set; }
            public override decimal CalcularAluguel(int dias)
            {
                var diaria = CapacidadeToneladas > 10 ? 300 : 200;
                return AplicarDesconto(dias, diaria * dias);
            }

            public override decimal AplicarDesconto(int dias, decimal valorOriginal)
            {
                Console.WriteLine("Executou o desconto da classe filha");
                if (dias >= 7)
                    return valorOriginal * 0.85m; // 15% de desconto
                return valorOriginal;
            }

            public override string ToString()
                => string.Concat(base.ToString(), $", Capacidade: {CapacidadeToneladas}(ton)");
        }



        static void Main(string[] args)
        {
            var moto = new Moto()
            {
                Marca = "Yamaha",
                Modelo = "MT-07",
                Placa = "ABC-1234",
                Cilindradas = 389
            };

            var carro = new Carro()
            {
                Marca = "Toyota",
                Modelo = "Corolla",
                Placa = "DEF-5678",
                QuantidadePortas = 4
            };

            var caminhao = new Caminhao()
            {
                Marca = "Volvo",
                Modelo = "FH16",
                Placa = "GHI-9012",
                CapacidadeToneladas = 15
            };

            Veiculo caminhao1 = new Caminhao()
            {
                Marca = "Scania",
                Modelo = "R500",
                Placa = "JKL-3456",
                CapacidadeToneladas = 12
            };
            //Console.WriteLine(caminhao1.CalcularAluguel(10));

            Caminhao caminhao2 = new Caminhao()
            {
                Marca = "Mercedes",
                Modelo = "Actros",
                Placa = "MNO-7890",
                CapacidadeToneladas = 8
            };

            var veiculos = new List<Veiculo>();
            veiculos.Add(moto);
            veiculos.Add(carro);
            veiculos.Add(caminhao);
            veiculos.Add(caminhao1);
            veiculos.Add(caminhao2);

            Console.WriteLine(new string('=', 20));
            Console.WriteLine("INVENTÁRIO");
            Console.WriteLine(new string('=', 20));

            int totalCarros = 0;
            int totalMotos = 0;
            int totalCaminhoes = 0;
            int totalVeiculos = 0;

            foreach (var veiculo in veiculos)
            {
                if (veiculo is Carro)
                    totalCarros++;

                if (veiculo is Moto)
                    totalMotos++;

                if (veiculo is Caminhao)
                    totalCaminhoes++;

                if (veiculo is Veiculo)
                    totalVeiculos++;

                Console.WriteLine(veiculo);
            }

            Console.WriteLine(Environment.NewLine);
            Console.WriteLine(new string('=', 20));
            Console.WriteLine("RESUMO");
            Console.WriteLine(new string('=', 20));
            Console.WriteLine($"{totalCarros} Carros");
            Console.WriteLine($"{totalMotos} Motos");
            Console.WriteLine($"{totalCaminhoes} Caminhões");
            Console.WriteLine($"{totalVeiculos} Veículos");

            Veiculo teste = new Moto()
            {
                Marca = "Honda",
                Modelo = "CB500X",
                Placa = "PQR-2345",
                Cilindradas = 471
            };


            if (teste is Moto m)
            {
                m.Cilindradas = 500;
            }

            if (veiculos is { Count: >= 2 and <= 6 } l)
            {
                l.RemoveAt(0);
            }

            /*
            caminhao1.AplicarDesconto(10, 1000);
            caminhao2.AplicarDesconto(10, 1000);
            */

                //Console.WriteLine(caminhao2.CalcularAluguel(10));

                /*
                Console.WriteLine(new string('=', 20));

                Console.Write("Informe a quantidade de dias: ");
                int dias = int.Parse(Console.ReadLine()!);

                foreach (var veiculo in veiculos)
                {
                    Console.WriteLine("Orçamento para " + new string('-', 5));
                    Console.WriteLine(veiculo);
                    Console.WriteLine(veiculo.CalcularAluguel(7).ToString("C", new CultureInfo("pt-BR")));
                }
                */
        }
    }
}
