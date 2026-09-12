namespace Juego_Ruleta_Examen;

internal class Menu
{
    private readonly string[] Opciones;
    private readonly string Titulo;
    private readonly string Nombre;
    private  int SaldoInicial;
    private Apuestas apuestas { get; set; }
    private Validaciones _validaciones;
    private Historial historialMenu = new Historial();

    public Menu(String titulo, string[] opciones, string nombre, int saldoIncial)
    {
        Titulo = titulo;
        Opciones = opciones;
        Nombre = nombre;
        SaldoInicial = saldoIncial;
        _validaciones = new Validaciones();
        apuestas = new Apuestas(saldoIncial, historialMenu);

    }
    

    public void MostrarMenu()
    {
        bool continuar = true;
        while (continuar)
        {
            if (apuestas.ObtenerSaldo() <=  0)
            {
                Console.Clear();
                Console.WriteLine("Saldo Insuficiente para Jugar ");
                historialMenu.MostrarGanancias();
                break;
            }
            Console.Clear();
            int CantidadApostada = 0;
            bool esValido; //Variable a usar en la verificación multiplos
            
            Console.WriteLine(Titulo);
            Console.WriteLine($"Nombre: {Nombre} \t Saldo: {apuestas.ObtenerSaldo()}");
            Console.WriteLine();

            for (int i = 0; i < Opciones.Length; i++)
            {
                Console.WriteLine($"{i+1}. {Opciones[i]}");
            }
            Console.WriteLine("0. Salir");
            Console.WriteLine("Opción: ");
            string opcion = Console.ReadLine() ?? "";

            switch (opcion)
            {
                case "0":
                    Console.Clear();

                    historialMenu.MostrarGanancias();
                    continuar = false; break;
                case "1":
                    Console.Clear();

                    Console.WriteLine("---Opcion Apostar del 0 al 36 Selecionada---");
                    
                    do
                    { 
                        CantidadApostada = _validaciones.PedirEntero("Ingrese la Cantidad a Apostar: ");
                        bool esValidoUno = _validaciones.ValidacionSoloMultiplos(CantidadApostada);
                        bool esValidoDos =
                            _validaciones.ValidarcantidadSaldoApostar(CantidadApostada, apuestas.ObtenerSaldo());
                        if (esValidoUno && esValidoDos)
                        {
                            esValido = true;
                        }
                        else
                        {
                            esValido = false;
                        }

                    } while (!esValido);
                    int NumeroApostado = 0;


                    do
                    { 
                        NumeroApostado = _validaciones.PedirEntero("Ingrese el Numero a Apostar 0 - 36: ");

                        esValido = _validaciones.validarNumeroEntre0a36(NumeroApostado);
                    } while (!esValido);
                    apuestas.Apuesta0al36(CantidadApostada, NumeroApostado);
                    Console.WriteLine("\nPresiona Enter para continuar...");
                    Console.ReadLine();
                    break;
                
                case "2":
                    Console.Clear();

                    Console.WriteLine("---Apostar Rojo o Blanco Selecionado---");
                    string color = _validaciones.PedirTexto("Rojo o Negro (Ingrese solo texto) ").ToLower().Trim();
                    
                    do
                    { 
                        CantidadApostada = _validaciones.PedirEntero("Ingrese la Cantidad a Apostar: ");
                        
                        bool esValidoUno = _validaciones.ValidacionSoloMultiplos(CantidadApostada);
                        bool esValidoDos =
                            _validaciones.ValidarcantidadSaldoApostar(CantidadApostada, apuestas.ObtenerSaldo());
                        if (esValidoUno && esValidoDos)
                        {
                            esValido = true;
                        }
                        else
                        {
                            esValido = false;
                        }

                    } while (!esValido);
                    apuestas.ApuestaBlancoORojo(CantidadApostada, color);
                    
                    Console.WriteLine("\nPresiona Enter para continuar...");

                    Console.ReadLine();break;
                case "3": 
                    Console.Clear();

                    Console.WriteLine("---Apostar Par o Impar---");
                    string parImpar = _validaciones.PedirTexto("Ingresa par o impar (Ingrese solo Texto)").ToLower()
                        .Trim();
                    do
                    { 
                        CantidadApostada = _validaciones.PedirEntero("Ingrese la Cantidad a Apostar: ");

                        bool esValidoUno = _validaciones.ValidacionSoloMultiplos(CantidadApostada);
                        bool esValidoDos =
                            _validaciones.ValidarcantidadSaldoApostar(CantidadApostada, apuestas.ObtenerSaldo());
                        if (esValidoUno && esValidoDos)
                        {
                            esValido = true;
                        }
                        else
                        {
                            esValido = false;
                        }
                    } while (!esValido);                
                    apuestas.ApuestaImparPar(CantidadApostada, parImpar);

                    Console.WriteLine("\nPresiona Enter para continuar...");

                    Console.ReadLine(); break;
                case "4": 
                    Console.Clear();
                    Console.WriteLine("Ver historial");
                    historialMenu.MostrarHistorial();
                    Console.ReadLine();break;
                default :
                    Console.WriteLine("Opcion invalida");
                    Console.WriteLine("\nPresiona Enter para continuar...");

                    Console.ReadLine();
                    break; 
            }
        }
    }
}


/*Hacer todo este codigo casi me deja pelon, saludos profesor, espero un 10, no valide alguna que
 otra cosa por falta de tiempo y cabello que jalar jaja*/