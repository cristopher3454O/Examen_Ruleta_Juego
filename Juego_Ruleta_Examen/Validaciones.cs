namespace Juego_Ruleta_Examen;

internal class Validaciones
{
    public Validaciones()
    {
    }
    public int PedirEntero(String mensaje) //Metodo para pedir un entero mas rapido
    {
        int numero;
        String entrada;
        do
        {
            Console.WriteLine(mensaje);
            entrada = Console.ReadLine() ?? "";

        } while (!int.TryParse(entrada, out numero));

        return numero;
    }

    public string PedirTexto(String mensaje) //Pedir String mas rapido
    {
        Console.WriteLine(mensaje);
        return Console.ReadLine() ?? "";
    }

    public bool ValidacionSoloMultiplos(int cantidadApostada)
    {
        if (cantidadApostada < 0)
        {
            Console.WriteLine("No puedes apostar cantidades negativas");
            return false;
        }
        if (cantidadApostada % 10 != 0)
        {
            Console.WriteLine("Solo puedes apostar multiplos de 10");
            return false;
        }
        
        return true;

    }

    public bool ValidarcantidadSaldoApostar(int cantidadApostar, int saldoActual)
    {
        if (cantidadApostar > saldoActual)
        {
            Console.WriteLine("Saldo insuficiente para apostar ");
            return false;
        }

        return true;
    }

    public bool validarNumeroEntre0a36(int numeroAValidar)
    {
        if (numeroAValidar < 0 || numeroAValidar> 36)
        {
            Console.WriteLine("Solo numeros entre 0 y 36");
            return false;
        }
        return true;
    }
    
    
}