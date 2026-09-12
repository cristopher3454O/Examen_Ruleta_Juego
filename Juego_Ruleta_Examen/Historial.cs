namespace Juego_Ruleta_Examen;

public class Historial
{
    public class Registro
    {
        public string Apuesta { get; set; }
        public string TipoApuesta { get; set; }
        public string Resultado { get; set; }
        public int Ganancia { get; set; }

        public Registro(string tipoApuesta,string apuesta, string resultado, int ganancia)
        {
            TipoApuesta = tipoApuesta;
            Apuesta = apuesta;
            Resultado = resultado;
            Ganancia = ganancia;
        }

    }

    private List<Registro> listaHistorial = new List<Registro>();

    public Historial()
    {
        
    }

    public void AgregarRegistro(string tipoApuesta,string apuesta, string resultado, int ganancia)
    {
        Registro nuevoRegistro = new Registro(tipoApuesta, apuesta, resultado, ganancia);
        listaHistorial.Add(nuevoRegistro);
    }
    public void MostrarHistorial()
    {
        Console.WriteLine("\n--- HISTORIAL DE APUESTAS ---");
        if (listaHistorial.Count == 0)
        {
            Console.WriteLine("No hay apuestas registradas todavía.");
            return;
        }

        foreach (var reg in listaHistorial)
        {
            Console.WriteLine($"Apuesta: {reg.Apuesta} | Resultado: {reg.Resultado} | Ganancia/Pérdida: {reg.Ganancia}");
        }
    }

    public void MostrarGanancias(int SaldoFinal)
    {
        int totalGanado = 0;
        int totalPerdido = 0;
        int saldoNeto = 0;

        foreach (var reg in listaHistorial)
        {
            saldoNeto += reg.Ganancia;

            // Si es mayor a 0, fue ganancia
            if (reg.Ganancia > 0)
            {
                totalGanado += reg.Ganancia;
            }
            // Si es menor a 0, fue pérdida (le quitamos el signo menos para sumarlo limpio)
            else if (reg.Ganancia < 0)
            {
                totalPerdido += Math.Abs(reg.Ganancia);
            }
        }

        Console.WriteLine("\n--- RESUMEN FINAL ---");
        Console.WriteLine($"Total Ganado: +${totalGanado}");
        Console.WriteLine($"Total Perdido: -${totalPerdido}");
        Console.WriteLine($"Balance Neto: ${SaldoFinal}");
    }
}