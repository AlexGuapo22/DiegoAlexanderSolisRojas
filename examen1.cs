using System;

// DECLARACIÓN DE VARIABLES
const int N = 12;
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

do
{
    // ENTRADA DE DATOS
    Console.WriteLine();
    Console.WriteLine(" /////// Sistema de Admisiones // Hospital San Rafael ////");
    Console.WriteLine("1. Agregar un paciente");
    Console.WriteLine("2. Buscar paciente por cédula");
    Console.WriteLine("3. Modificar nombre de un paciente");
    Console.WriteLine("4. Dar de baja a un paciente");
    Console.WriteLine("5. Salir");
    Console.Write("Seleccione una opción: ");
    int.TryParse(Console.ReadLine(), out opcion);

    if (opcion == 1)
    {
        Console.Write("Digite el nombre del paciente: ");
        nombre = Console.ReadLine();
        Console.Write("Digite la cédula del paciente: ");
        cedula = Console.ReadLine();
    }
    else if (opcion == 2)
    {
        Console.Write("Digite la cédula que desea buscar: ");
        cedulaBuscada = Console.ReadLine();
    }
    else if (opcion == 3)
    {
        Console.Write("Digite la cédula del paciente que quieres modificar: ");
        cedulaBuscada = Console.ReadLine();
        Console.Write("Digite el nombre corregido: ");
        nuevoNombre = Console.ReadLine();
    }
    else if (opcion == 4)
    {
        Console.Write("Digite la cédula del paciente que quieres dar de baja: ");
        cedulaBuscada = Console.ReadLine();
    }

    // PROCESO
    mensaje = "";
    encontrado = false;
    posicion = -1;
    nombreEliminado = "";

    switch (opcion)
    {
        case 1:
            if (contador < N)
            {
                cedulas[contador] = cedula;
                nombres[contador] = nombre;
                contador++;
                mensaje = "Paciente agregado correctamente.";
            }
            else
            {
                mensaje = "Espacio lleno, lo sentimos, su solicitud fue enviada a el hospital san juan de dios, ya viene una ambulancia por usted.";
            }
            break;

        case 2:
            for (i = 0; i < contador; i++)
            {
                if (cedulas[i] == cedulaBuscada)
                {
                    encontrado = true;
                    posicion = i;
                    break;
                }
            }

            if (encontrado)
            {
                mensaje = "Paciente encontrado: " + nombres[posicion];
            }
            else
            {
                mensaje = "No se encontró un paciente con esa cédula.";
            }
            break;

        case 3:
            for (i = 0; i < contador; i++)
            {
                if (cedulas[i] == cedulaBuscada)
                {
                    nombres[i] = nuevoNombre;
                    encontrado = true;
                    break;
                }
            }

            if (encontrado)
            {
                mensaje = "Nombre del paciente actualizado correctamente.";
            }
            else
            {
                mensaje = "No se encontró un paciente con esa cédula.";
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
                mensaje = "El paciente " + nombreEliminado + " con la cédula " + cedulaBuscada + " se dio de baja correctamente.";
            }
            else
            {
                mensaje = "No se encontró un paciente con esa cédula.";
            }
            break;

        case 5:
            continuar = false;
            mensaje = "Saliendo del sistema. Hasta luego.";
            break;

        default:
            mensaje = "Opción no válida. Intente nuevamente.";
            break;
    }

    // SALIDA DE DATOS
    Console.WriteLine(mensaje);
}
while (continuar);
