namespace Juego_Ruleta_Examen;

internal class NumeroRandom
{
    private Random aleatorio = new Random();

    public int GenerarNumero()
    {
        int numero = aleatorio.Next(0, 37);
        return numero;
    }
}