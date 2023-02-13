using System;
using System.Collections.Generic;
using System.Linq;

namespace TestCoderbyte
{
    class Program
    {
        static void Main(string[] args)
        {


            //    #region [ MAYOR Y MENOR QUE ]
            //    //int NUM1, NUM2;
            //    //string linea;


            //    //Console.Write("NÚMERO 1 :"); linea = Console.ReadLine();
            //    //NUM1 = int.Parse(linea);
            //    //Console.Write("NÚMERO 2 :"); linea = Console.ReadLine();
            //    //NUM2 = int.Parse(linea);
            //    //if ((NUM1 > NUM2))
            //    //{
            //    //    Console.WriteLine("{0} ES MAYOR QUE {1}", NUM1, NUM2);
            //    //}
            //    //else
            //    //{
            //    //    if ((NUM1 == NUM2))
            //    //    {
            //    //        Console.WriteLine("{0} ES IGUAL A {1}", NUM1, NUM2);
            //    //    }
            //    //    else
            //    //    {
            //    //        Console.WriteLine("{0} ES MENOR QUE {1}", NUM1, NUM2);
            //    //    }
            //    //}

            //    //Console.WriteLine();
            //    //Console.WriteLine("OTRA MANERA");

            //    //string RESUL;

            //    //if (NUM1 > NUM2)
            //    //{
            //    //    RESUL = "MAYOR";
            //    //}
            //    //else

            //    //if (NUM1 == NUM2)
            //    //{
            //    //    RESUL = "IGUAL";
            //    //}
            //    //else
            //    //{
            //    //    RESUL = "MENOR";
            //    //}

            //    //Console.WriteLine("{0} ES {1} QUE {2}", NUM1, RESUL, NUM2);
            //    //Console.Write("Pulse una Tecla:"); Console.ReadLine();
            //    #endregion


            //    #region [ INSERTAR UN ELEMENTO EN UN arrayEGLO ]
            //    //byte Index = 0;
            //    //byte Cantidad = 0;
            //    //byte Posicion = 0;
            //    //int Elemento = 0;

            //    //string cadena;

            //    //Console.Write("CUANTOS ELEMENTOS :");
            //    //cadena = Console.ReadLine();
            //    //Cantidad = byte.Parse(cadena);
            //    //int[] VEC = new int[Cantidad + 1];
            //    //int[] NUEVO = new int[Cantidad + 2];
            //    //// INGRESO
            //    //for (Index = 1; Index <= Cantidad; Index++)
            //    //{
            //    //    Console.Write("POSICIÓN {0} ==> ", Index);
            //    //    cadena = Console.ReadLine();
            //    //    VEC[Index] = int.Parse(cadena);
            //    //}

            //    //Console.Write("ELEMENTO A INSERTAR:");
            //    //cadena = Console.ReadLine();
            //    //Elemento = int.Parse(cadena);

            //    //do
            //    //{
            //    //    Console.Write("POSICIÓN A INSERTAR:");

            //    //    cadena = Console.ReadLine();
            //    //    Posicion = byte.Parse(cadena);

            //    //} while (((Posicion < 1) | (Posicion > Cantidad)));

            //    //// PROCESO
            //    //// TRANSLADAMOS DATOS ANTES DE LA POSICION
            //    //for (Index = 1; Index <= Posicion - 1; Index++)
            //    //{
            //    //    NUEVO[Index] = VEC[Index];
            //    //}

            //    //// INSERTAMOS ELEMENTO
            //    //NUEVO[Posicion] = Elemento;
            //    //// TRANSLADAMOS DATOS DESPUES DE LA POSICION
            //    //for (Index = Posicion; Index <= Cantidad; Index++)
            //    //{
            //    //    NUEVO[Index + 1] = VEC[Index];
            //    //}

            //    //// SALIDA
            //    //Console.WriteLine();
            //    //Console.WriteLine("NUEVO arrayEGLO");
            //    //for (Index = 1; Index <= Cantidad + 1; Index++)
            //    //{
            //    //    Console.WriteLine(NUEVO[Index]);
            //    //}

            //    //Console.Write("Pulse una Tecla:");
            //    //Console.ReadKey();
            //    #endregion


            //    #region [ ELIMINAR UN ELEMENTO EN UN arrayEGLO ]
            //    //int Index = 0;
            //    //int Cantidad = 0;
            //    //int Posicion = 0;
            //    //String cad;
            //    //Console.Write("CUANTOS ELEMENTOS :");
            //    //cad = Console.ReadLine();
            //    //Cantidad = int.Parse(cad);
            //    //int[] VEC = new int[Cantidad + 1];
            //    //int[] NUEVO = new int[Cantidad];

            //    //// INGRESO
            //    //for (Index = 1; Index <= Cantidad; Index++)
            //    //{
            //    //    Console.Write("POSICIÓN {0} ==>", Index);
            //    //    cad = Console.ReadLine();
            //    //    VEC[Index] = int.Parse(cad);
            //    //}


            //    //do
            //    //{
            //    //    Console.Write("POSICIÓN A ELIMINAR:");
            //    //    cad = Console.ReadLine();
            //    //    Posicion = int.Parse(cad);

            //    //} while (((Posicion < 1) | (Posicion > Cantidad)));

            //    //// PROCESO
            //    //// TRANSLADAMOS DATOS ANTES DE LA POSICIÓN

            //    //for (Index = 1; Index <= Posicion - 1; Index++)
            //    //{
            //    //    NUEVO[Index] = VEC[Index];
            //    //}

            //    //// TRANSLADAMOS DATOS DESPUES DE LA POSICIÓN

            //    //for (Index = Posicion + 1; Index <= Cantidad; Index++)
            //    //{
            //    //    NUEVO[Index - 1] = VEC[Index];
            //    //}
            //    //// SALIDA
            //    //Console.WriteLine();
            //    //Console.WriteLine("NUEVO arrayEGLO");
            //    //for (Index = 1; Index <= Cantidad - 1; Index++)
            //    //{
            //    //    Console.WriteLine(NUEVO[Index]);
            //    //}
            //    //Console.Write("Pulse una Tecla:");
            //    //Console.ReadLine();
            //    #endregion


            //    #region [ ORDENAMIENTO DE UN arrayEGLO EN DESCENDENTE ] 
            //    //int Index = 0;
            //    //int K = 0;
            //    //int Cantidad = 0;
            //    //int Aux = 0;
            //    //string linea;
            //    //Console.Write("CUANTOS ELEMENTOS MÁX=12:");
            //    //linea = Console.ReadLine();
            //    //Cantidad = int.Parse(linea);

            //    //int[] VEC = new int[Cantidad + 1];

            //    //// INGRESO
            //    //for (Index = 1; Index <= Cantidad; Index++)
            //    //{
            //    //    Console.Write("POSICIÓN {0} ==>", Index);
            //    //    linea = Console.ReadLine();
            //    //    VEC[Index] = int.Parse(linea);
            //    //}

            //    //// PROCESO ORDENAMIENTO
            //    //for (Index = 1; Index <= Cantidad; Index++)
            //    //{
            //    //    for (K = Index; K <= Cantidad; K++)
            //    //    {
            //    //        if ((VEC[K] > VEC[Index]))
            //    //        {
            //    //            Aux = VEC[K];
            //    //            VEC[K] = VEC[Index];
            //    //            VEC[Index] = Aux;
            //    //        }
            //    //    }
            //    //}

            //    //// PROCESO BURBUJA
            //    ////for (Index = 1; Index <= Cantidad; Index++)
            //    ////{
            //    ////    for (K = Index; K <= Cantidad; K++)
            //    ////    {
            //    ////        if ((VEC[Index] < VEC[K]))
            //    ////        {
            //    ////            Aux = VEC[K];
            //    ////            VEC[K] = VEC[Index];
            //    ////            VEC[Index] = Aux;
            //    ////        }
            //    ////    }
            //    ////}


            //    //Console.WriteLine();
            //    //// arrayEGLO
            //    //Console.WriteLine("arrayEGLO ORDENADO DESCENDENTE");
            //    //for (Index = 1; Index <= Cantidad; Index++)
            //    //{
            //    //    Console.WriteLine(VEC[Index]);
            //    //}
            //    //Console.Write("Pulse una Tecla:");
            //    //Console.ReadLine();
            //    #endregion


            //    #region [ BÚSQUEDA DE UN ELEMENTO EN UN arrayEGLO Y CUANTAS VECES EXISTE ] 
            //    //int Index = 0;
            //    //int Cantidad = 0;
            //    //int Total = 0;
            //    //int BuscarElemento = 0;
            //    //string linea;
            //    //Console.Write("CUANTOS ELEMENTOS:");
            //    //linea = Console.ReadLine();
            //    //Cantidad = int.Parse(linea);
            //    //int[] VEC = new int[Cantidad + 1];

            //    //// INGRESO
            //    //for (Index = 1; Index <= Cantidad; Index++)
            //    //{
            //    //    Console.Write("POSICIÓN {0} ==> ", Index);
            //    //    linea = Console.ReadLine();
            //    //    VEC[Index] = int.Parse(linea);
            //    //}

            //    //Console.Write("ELEMENTO A BUSCAR:");
            //    //linea = Console.ReadLine();
            //    //BuscarElemento = int.Parse(linea);

            //    //// PROCESO
            //    //Total = 0;

            //    //for (Index = 1; Index <= Cantidad; Index++)
            //    //{
            //    //    if ((VEC[Index]) == BuscarElemento)
            //    //    {
            //    //        Total = Total + 1;
            //    //    }
            //    //}

            //    //// SALIDA
            //    //Console.WriteLine();
            //    //Console.WriteLine("EXISTE {0} NÚMEROS {1}", Total, BuscarElemento);
            //    //Console.Write("Pulse una Tecla:");
            //    //Console.ReadLine();
            //    #endregion


            //    #region [ BÚSQUEDA BINARIA DE UN ELEMENTO EN UN arrayEGLO ]
            //    //int Index = 0;
            //    //int Cantidad = 0;
            //    //int J = 0;
            //    //int Alto = 0;
            //    //int Bajo = 0;
            //    //int Central = 0;
            //    //int Buscar = 0;
            //    //int Aux = 0;
            //    //string linea;
            //    //Random random = new Random();

            //    //Console.Write("CUANTOS ELEMENTOS:");

            //    //linea = Console.ReadLine();
            //    //Cantidad = int.Parse(linea);
            //    //int[] VEC = new int[Cantidad + 1];
            //    //bool Encontrado = false;

            //    //INGRESO
            //    //for (Index = 1; Index <= Cantidad; Index++)
            //    //{
            //    //    VEC[Index] = random.Next(0, 99);
            //    //}

            //    //SALIDA DEL arrayEGLO ALEATORIO
            //    //for (Index = 1; Index <= Cantidad; Index++)
            //    //{
            //    //    Console.SetCursorPosition(3, Index + 2);
            //    //    Console.WriteLine(VEC[Index]);
            //    //}

            //    //PRIMERO ORDENAMOS EL arrayEGLO
            //    //for (J = 1; J <= Cantidad; J++)
            //    //{
            //    //    for (Index = 1; Index <= Cantidad - 1; Index++)
            //    //    {
            //    //        if ((VEC[Index] > VEC[Index + 1]))
            //    //        {
            //    //            Aux = VEC[Index];
            //    //            VEC[Index] = VEC[Index + 1];
            //    //            VEC[Index + 1] = Aux;
            //    //        }
            //    //    }
            //    //}

            //    //SALIDA DEL arrayEGLO ORDENADO
            //    //for (Index = 1; Index <= Cantidad; Index++)
            //    //{
            //    //    Console.SetCursorPosition(10, Index + 2);
            //    //    Console.WriteLine(VEC[Index]);
            //    //}

            //    //AHORA SI LA BÚSQUEDA
            //    //Console.Write("ELEMENTO A BUSCAR:");

            //    //linea = Console.ReadLine();
            //    //Buscar = int.Parse(linea);
            //    //Bajo = 1;
            //    //Alto = Cantidad;


            //    //while (((Bajo <= Alto) && (Encontrado == false)))
            //    //{
            //    //    Central = (Bajo + Alto) / 2;

            //    //    if ((VEC[Central]) == Buscar)
            //    //    {
            //    //        Encontrado = true;
            //    //    }
            //    //    else
            //    //    {
            //    //        if ((VEC[Central]) > Buscar)
            //    //        {
            //    //            Alto = Central - 1;
            //    //        }

            //    //        else
            //    //        {
            //    //            Bajo = Central + 1;
            //    //        }
            //    //    }
            //    //}

            //    //List<int> nVeces = new List<int>() { Buscar };

            //    //List<int> numeroRepetido = nVeces.GroupBy(x => x)
            //    //    .Where(g => g.Count() > 1)
            //    //    .Select(x => x.Key)
            //    //    .ToList();

            //    //if ((Encontrado))
            //    //{
            //    //    Console.WriteLine("{0} Numero encontrado en la posición {1}", Buscar, Central);
            //    //    Console.WriteLine("{0} Numero encontrado! en la posición {1} - Repetido {0} " + String.Join(", ", nVeces), Buscar, Central);
            //    //}
            //    //else
            //    //{
            //    //    Console.WriteLine("No existe {0}, ", Buscar);
            //    //}

            //    //Console.Write("Pulse una Tecla:");
            //    //Console.ReadLine();
            //    #endregion




            #region [ EJERCICIO PRUEBA FINAL ]
            //static int SeatingStudent(int[] array)
            //{

            //    // Verifica si la matriz está vacía o si los escritorios están en distribución de números pares
            //    if (((array.Length == 0) || ((array[0] % 2) != 0)))
            //    {
            //        return 0;
            //    }

            //    // encontrar el número total de filas
            //    int totalRows = (array[0] / 2);

            //    // combinación total
            //    int totalCombination = (((totalRows - 1) * 2) + totalRows);

            //    // devuelve la combinación total si no se coloca ningún estudiante
            //    if ((array.Length == 1))
            //    {
            //        return totalCombination;
            //    }


            //    for (int i = 1; (i < (array.Length + 1)); i++)
            //    {
            //        // comprobar que la matriz cumple la condición anterior
            //        if (((array[0] < 1) || ((i > 1) && (array[i] <= array[(i - 1)]))))
            //        {
            //            return 0;
            //        }

            //        // comprobar si los números son vecinos
            //        bool isNeighbour = (((array[i] % 2) == 0) && ((i > 1) && ((array[i] - array[(i - 1)]) == 1)));

            //        // comprobar si el número aparece en la primera o en la última fila
            //        bool isFirstOrLast = (((array[i] == 1) || (array[i] == 2)) || ((array[i] == array[0]) || (array[i] == (array[0] - 1))));

            //        // comprueba que los números sean en forma lineal o paralelos
            //        bool isParallel = (((i > 1) && ((array[i] - array[(i - 1)]) == 2)) || ((i > 2) && ((array[i] - array[(i - 2)]) == 2)));

            //        // si el número es el primero o el último (-2 combinaciones) y paralelo o vecino a otro número, hacemos 1 operación menos solo en el número mayor porque esa operación
            //        // ya está hecho por el número anterior más pequeño. por lo que se eliminarán un total de 4 combinaciones
            //        if ((isFirstOrLast && (isNeighbour || isParallel)))
            //        {
            //            totalCombination--;
            //        }

            //        // si el número es solo parte de cualquiera de los tres, eliminamos 2 combinaciones
            //        if ((isFirstOrLast || (isNeighbour || isParallel)))
            //        {
            //            totalCombination -= 2;
            //        }

            //        // si no, el número aparece totalmente aislado y entre la primera y la última fila
            //        totalCombination -= 3;
            //    }

            //    return totalCombination;
            }
            #endregion


        }
    }



