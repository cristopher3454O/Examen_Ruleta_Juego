namespace Juego_Ruleta_Examen;

internal class Apuestas
{
    
    private  int Saldo;
    private NumeroRandom numeroRandom = new NumeroRandom();
    private int[] Negro = [2, 4, 6, 8, 10, 11, 13, 15, 17, 20, 22, 24, 26, 28, 29, 31, 33, 35];
    private int[] Rojos = [1, 3, 5, 7, 9, 12, 14, 16, 18, 19, 21, 23, 25, 27, 30, 32, 34, 36];

    private Historial historial;
    public Apuestas(int saldo, Historial historialUsar)
    {
        Saldo = saldo;
        historial = historialUsar;
    }

    public void Apuesta0al36(int SaldoApostado, int numeroApostado){
    
        int numeroGanador = numeroRandom.GenerarNumero();
        Console.WriteLine($"Numero Ganador {numeroGanador}");

        if (numeroGanador == numeroApostado)
        {
            SaldoApostado *= 10;
            Saldo += SaldoApostado;
            Console.WriteLine($"Felicidades Has ganado: {SaldoApostado}");
            historial.AgregarRegistro(
                "Apuesta 0 - 36", 
                $"Numero ganador: {numeroGanador}", 
                "Ganada", 
                SaldoApostado
            );        }
        else
        {
            Console.WriteLine($"Has Perdido: {SaldoApostado}");
            historial.AgregarRegistro(
                "Apuesta 0 - 36", 
                $"Numero ganador: {numeroGanador}", 
                "Perdida", 
                -SaldoApostado
            );    
            Saldo -= SaldoApostado;

        }
        Console.WriteLine($"Nuevo Saldo de:  {Saldo}");

    }

    public void ApuestaBlancoORojo(int SaldoApostado, String color)
    {
        int numeroAleatorio = numeroRandom.GenerarNumero();
        int colorConvertir = VerificarRojoONegro(numeroAleatorio);
        String colorGanador = ColorATexto(colorConvertir);
        Console.WriteLine($"Color Ganador: {colorGanador}");

        switch (color == colorGanador)
        {
            case true:
                SaldoApostado *= 5;
                Saldo += SaldoApostado;
                Console.WriteLine($"Felicidades Has ganado: {SaldoApostado}");
                historial.AgregarRegistro(
                    "Apuesta Negro o Rojo", 
                    $"Color Apostado : {color} | Salió: {colorGanador}", 
                    "Ganada", 
                    SaldoApostado
                );
                break;

            case false:
                Saldo -= SaldoApostado;
                Console.WriteLine($"Has perdido: {SaldoApostado}");
                historial.AgregarRegistro(
                    "Apuesta Negro o Rojo", 
                    $"Color Apostado : {color} | Salió: {colorGanador}", 
                    "Perdida", 
                    -SaldoApostado
                );
                break;
        }

        Console.WriteLine($"Nuevo Saldo de:  {Saldo}");
    }

    public void ApuestaImparPar(int SaldoApostado, String ParImpar)
    {
        int numeroAleatorio = numeroRandom.GenerarNumero();
        int colorConvertir = VerificarRojoONegro(numeroAleatorio);
        
        
        //Verificar si es Par o Impar
        String resultado = VerificarParoImpar(numeroAleatorio);
        Console.WriteLine($"Numero ganador: {numeroAleatorio}");
        Console.WriteLine($"El numero es: {resultado}");

        if (ParImpar.Equals(resultado))
        {
            SaldoApostado *= 2;
            Saldo += SaldoApostado;
            Console.WriteLine($"Felicidades Has ganado: {SaldoApostado}");
            historial.AgregarRegistro(
                "Apuesta Negro o Rojo", 
                $"Par o Impar : {ParImpar}", 
                "Ganada", 
                SaldoApostado
            );
        }
        else
        {
            Console.WriteLine($"Has Perdido: {SaldoApostado}");
            historial.AgregarRegistro(
                "Apuesta Negro o Rojo", 
                $"Par o Impar : {ParImpar}", 
                "Perdida", 
                -SaldoApostado
            );
        }
        Console.WriteLine($"Nuevo Saldo de:  {Saldo}");


    }

    public int ObtenerSaldo()
    {
        return Saldo;
    }

    private int VerificarRojoONegro(int numeroAleatorio)
    {
        for (int i = 0; i < Negro.Length; i++)
        {
            if (Negro[i] == numeroAleatorio)
            {
                return 1;
            }
        }
        return 2;
    }

    private String ColorATexto(int verificacionColor) //Almacenar Color
    {
        if (verificacionColor == 1)
        {
            return "negro";
        }

        return "rojo";
    }

    private String VerificarParoImpar(int ParImpar) //Metodo Verificar Par o Impar
    {
        if (ParImpar %2 == 0)
        {
            return "par";
        }
        return "impar";
    }
    

}
