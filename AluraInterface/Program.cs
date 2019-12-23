using System;

namespace AluraInterface
{
    class Program
    {
        static void Main(string[] args)
        {
            IAulaItem aulaItem = new Interfaces();

            aulaItem.Executar();

            Calculadora calculadora = new Calculadora();
            calculadora.Executar();

            Console.WriteLine("Hello World!");
        }
    }

    internal delegate double metodoMultiplicacao(double input);

    class Calculadora
    {
        double Duplicar(double input)
        {
            return input * 2;
        }

        double Triplicar(double input)
        {
            return input * 3;
        }

        public void Executar()
        {
            Console.WriteLine($"Duplicar(7.5): {Duplicar(7.5)}");
            Console.WriteLine($"Triplicar(7.5): {Triplicar(7.5)}");

            metodoMultiplicacao metodoMultiplicacao = Duplicar;
            Console.WriteLine($"Delegate: {metodoMultiplicacao(7.5)}");

            metodoMultiplicacao metodoquadrado = delegate (double i)
            {
                return i * 10;
            };

            var r = metodoquadrado(7.5);
            Console.WriteLine($"Outro metodo delegate: {r}");

            metodoMultiplicacao metodoLambda = x => x * x * x;

            Console.WriteLine($"metodoLamda: {metodoLambda(7.5)}");

        }

    }


    class Interfaces : IAulaItem
    {
        public void Executar()
        {
            IEletrodomestico eletro1 = new Televisao();
            eletro1.Ligar();

            eletro1 = new Abajur();
            eletro1.Ligar();

        }
    }

    interface IAulaItem
    {
        void Executar();
    }

    interface IEletrodomestico
    {
        void Ligar();
        void Desligar();
    }

    interface IIluminacao
    {
        double PotenciaDaLampada { get; set; }
    }

    class Televisao : IEletrodomestico
    {
        public void Desligar()
        {
        }

        public void Ligar()
        {
            Console.WriteLine("Ligou !");
        }
    }
    class Abajur : IEletrodomestico, IIluminacao
    {

        public double PotenciaDaLampada { get; set; }

        public void Desligar()
        {
        }

        public void Ligar()
        {
            PotenciaDaLampada = 220;

            Console.WriteLine($"Potencia ligada: { PotenciaDaLampada} volts");
        }
    }
    class Lanterna : IEletrodomestico, IIluminacao
    {

        public double PotenciaDaLampada { get; set; }

        public void Desligar()
        {
        }

        public void Ligar()
        {
        }
    }

}
