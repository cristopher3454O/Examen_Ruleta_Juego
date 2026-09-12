namespace Juego_Ruleta_Examen
{
    class Program
    {
        static void Main(String[] args)
        {
            String titulo = "Ruleta Mortal ";

            int saldoInicial = 300;
            Console.WriteLine("Bienvenido A la Ruleta ");
            String[] opciones =
                ["Apostar 0-36", "Apostar Negro o Rojo", "Apostar Impar o Par", "Ver historial"];

            Console.WriteLine("Como te llamas? ");
            String nombreJugador = Console.ReadLine();
            

            Menu menu = new Menu(titulo, opciones, nombreJugador, saldoInicial);
            menu.MostrarMenu();



        }
    }
}