using LibreriaEvaluacion.DAL;
using LibreriaEvaluacion.DTO;

const string nombreAlumno = "Matías Medrano";

while (Menu(nombreAlumno))
{
    Console.ReadKey(); // pausa, solicitar la entrada de una tecla
}


static bool Menu(string nombreAlumno)
{ 
    bool continuar = true;

    Console.Clear(); // Limpia la pantalla
    Console.Title = $"Evaluación II: {nombreAlumno}";

    Console.WriteLine("Menú de opciones");
    Console.WriteLine("================");
    Console.WriteLine("1) Listar préstamos");
    Console.WriteLine("2) Agregar préstamo");
    Console.WriteLine("3) Actualizar préstamo");
    Console.WriteLine("4) Eliminar préstamo");
    Console.WriteLine("");
    Console.WriteLine("0) Salir");
    Console.WriteLine("");

    Console.Write("Ingrese una opción: ");
    string opcion = Console.ReadLine().Trim(); // " 1 " => "1"

    switch (opcion)
    {
        case "1":
            Console.WriteLine("Listado de préstamos registrados");
            // ToDo: Lógica GUI de listado
            OpcionListar();
            break;
        case "2":
            Console.WriteLine("Insertar un nuevo préstamo");
            // ToDo: Lógica GUI de inserción
            OpcionInsertar();
            break;
        case "3":
            Console.WriteLine("Actualizar un préstamo existente");
            // ToDo: Lógica GUI de actualización
            OpcionActualizar();
            break;
        case "4":
            Console.WriteLine("Eliminar un préstamo existente");
            // ToDo: Lógica GUI de eliminación
            OpcionEliminar();
            break;
        case "0":
            Console.WriteLine("Saliendo del programa ...");
            continuar = false;
            break;
        default:
            Console.WriteLine("Opción no válida");
            break;
    }

    return continuar;
}

// ToDo: lógica de GUI
static void OpcionListar()
{
    PrestamoDAL prestamoDAL = new PrestamoDAL();
    List<PrestamoDTO> prestamos = prestamoDAL.Listar();

    foreach (PrestamoDTO prestamo in prestamos)
    {
        Console.WriteLine(prestamo.ToString());
    }
}

static void OpcionInsertar()
{
    PrestamoDAL prestamoDAL = new PrestamoDAL(); 
   
    try
    {
        Console.Write("Ingrese el ID: ");
        int id = Convert.ToInt32(Console.ReadLine());

        Console.Write("Ingrse el monto: ");
        int monto = Convert.ToInt32(Console.ReadLine());

        if (monto >= 50000)
        {
            PrestamoDTO nuevoPrestamo = new PrestamoDTO()
            {
                Id = id,
                Monto = monto,
                MontoAtraso = monto,
                MontoMasIntereses = monto
            };

            if (prestamoDAL.Insertar(nuevoPrestamo))
            {
                Console.WriteLine($"Se ha insertado un nuevo prestamo");
            }
            else
            {
                Console.WriteLine($"No se ha podido insertar el nuevo prestamo");
            }
        }
        else
        {
            Console.Write("No se puede realizar el prestamo");
        }
    }
    catch (Exception)
    {
        Console.WriteLine("Ingrese correctamente los datos e intente otra vez");
    }
}

static void OpcionActualizar()
{
    PrestamoDAL prestamoDAL = new PrestamoDAL();

    try
    {
        Console.Write("Ingrese el ID a buscar: ");
        string opcion = Console.ReadLine().Trim();

        PrestamoDTO resultado = prestamoDAL.BuscarPorId(int.Parse(opcion));
        
        if (resultado != null)
        {
            Console.WriteLine("¿Desea actualizar el monto? (Y/N)");
            string opcionMonto = Console.ReadLine().Trim();

            if (opcionMonto.ToUpper() == "Y")
            {
                if (resultado.Monto >= 50000)
                {
                    Console.WriteLine($"Ingrese monto nuevo: (actual: {resultado.Monto})");
                    int nuevoMonto = Convert.ToInt32(Console.ReadLine().Trim());

                    if (nuevoMonto >= 50000)
                    { 
                        resultado.Monto = (nuevoMonto);
                        resultado.MontoMasIntereses = (nuevoMonto);
                        resultado.MontoAtraso = (nuevoMonto); 
                        Console.WriteLine("Monto actualizado");
                    }
                    else
                    {
                        Console.WriteLine("No se puede actualizar el monto");
                    }
                }
                else
                {
                    Console.WriteLine("No se puede actualizar el monto");
                }
            }
        }
    }
    catch (Exception)
    {
        Console.WriteLine("Debe escribir un número válido");
    }
}


static void OpcionEliminar()
{
    PrestamoDAL prestamoDAL = new PrestamoDAL();

    try
    {
        Console.Write("Ingrese el ID a buscar: ");
        string opcion = Console.ReadLine().Trim();

        int resultadoEncontrado = prestamoDAL.BuscarPorIdSimple(int.Parse(opcion));

        if (resultadoEncontrado >= 0)
        {
            prestamoDAL.EliminarPorIndice(resultadoEncontrado);
            Console.WriteLine($"El elemento ha sido eliminado");
        }
        else
        {
            Console.WriteLine($"No se ha podido eliminar el elemento");
        }
    }
    catch (Exception)
    {
        Console.WriteLine("Debe escribir un número válido");
    }
}
