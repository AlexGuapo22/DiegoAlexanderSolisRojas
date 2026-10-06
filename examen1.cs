using System;

// declaracion de variables
const int N = 12;
// cada indice relaciona una cedula con el nombre del mismo paciente
string[] cedulas = new string[N];
string[] nombres = new string[N];
int contador = 0;
bool continuar = true;
int opcion = 0;
string nombre = "";
string cedula = "";
string cedulaBuscada = "";
string nuevoNombre = "";
string nombreEliminado = "";
string mensaje = "";
bool encontrado = false;
int posicion = -1;
int i;
int j;

// inicializacion de vectores
// las doce posiciones empiezan vacias y contador distingue los registros reales
for (i = 0; i < N; i++)
{
    cedulas[i] = "";
    nombres[i] = "";
}

do
{
    // entrada de datos
    Console.WriteLine();
    Console.WriteLine("=== sistema de admisiones - hospital san rafael ===");
    Console.WriteLine("1. agregar un paciente");
    Console.WriteLine("2. buscar paciente por cedula");
    Console.WriteLine("3. modificar nombre de un paciente");
    Console.WriteLine("4. dar de baja a un paciente");
    Console.WriteLine("5. salir");
    Console.Write("seleccione una opcion: ");
    int.TryParse(Console.ReadLine(), out opcion);

    if (opcion == 1)
    {
        Console.Write("digite el nombre del paciente: ");
        nombre = Console.ReadLine();
        Console.Write("digite la cedula del paciente: ");
        cedula = Console.ReadLine();
    }
    else if (opcion == 2)
    {
        Console.Write("digite la cedula que desea buscar: ");
        cedulaBuscada = Console.ReadLine();
    }
    else if (opcion == 3)
    {
        Console.Write("digite la cedula del paciente que quieres modificar: ");
        cedulaBuscada = Console.ReadLine();
        Console.Write("digite el nombre corregido: ");
        nuevoNombre = Console.ReadLine();
    }
    else if (opcion == 4)
    {
        Console.Write("digite la cedula del paciente que quieres dar de baja: ");
        cedulaBuscada = Console.ReadLine();
    }

    // procesamiento
    mensaje = "";
    encontrado = false;
    posicion = -1;
    nombreEliminado = "";

    switch (opcion)
    {
        case 1:
            if (contador < N)
            {
                // se agregan juntos ambos datos al final de los registros ocupados
                cedulas[contador] = cedula;
                nombres[contador] = nombre;
                contador++;
                mensaje = "paciente agregado correctamente";
            }
            else
            {
                mensaje = "cupo lleno, no es posible registrar mas pacientes";
            }
            break;

        case 2:
            for (i = 0; i < contador; i++)
            {
                // la busqueda usa la cedula y guarda el indice para consultar el nombre asociado
                if (cedulas[i] == cedulaBuscada)
                {
                    encontrado = true;
                    posicion = i;
                    break;
                }
            }

            if (encontrado)
            {
                mensaje = "paciente encontrado: " + nombres[posicion] + " | cedula: " + cedulas[posicion];
            }
            else
            {
                mensaje = "no se encontro un paciente con esa cedula";
            }
            break;

        case 3:
            for (i = 0; i < contador; i++)
            {
                if (cedulas[i] == cedulaBuscada)
                {
                    // solo se cambia el nombre y la cedula queda en la misma posicion
                    nombres[i] = nuevoNombre;
                    encontrado = true;
                    break;
                }
            }

            if (encontrado)
            {
                mensaje = "nombre del paciente actualizado correctamente";
            }
            else
            {
                mensaje = "no se encontro un paciente con esa cedula";
            }
            break;

        case 4:
            for (i = 0; i < contador; i++)
            {
                if (cedulas[i] == cedulaBuscada)
                {
                    nombreEliminado = nombres[i];

                    for (j = i; j < contador - 1; j++)
                    {
                        cedulas[j] = cedulas[j + 1];
                        nombres[j] = nombres[j + 1];
                    }

                    contador--;
                    cedulas[contador] = "";
                    nombres[contador] = "";
                    encontrado = true;
                    break;
                }
            }

            if (encontrado)
            {
                mensaje = "el paciente " + nombreEliminado + " con la cedula " + cedulaBuscada + " se dio de baja correctamente";
            }
            else
            {
                mensaje = "no se encontro un paciente con esa cedula";
            }
            break;

        case 5:
            continuar = false;
            mensaje = "saliendo del sistema, hasta luego";
            break;

        default:
            mensaje = "opcion no valida, intente nuevamente";
            break;
    }

    // salida de datos
    Console.WriteLine(mensaje);
}
while (continuar);
