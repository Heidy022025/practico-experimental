using System;
using System.Collections.Generic;

namespace AsignacionAsientos
{
    // Clase que representa a una persona que ingresa a la atracción
    class Persona
    {
        // Propiedad que almacena el nombre de la persona
        public string Nombre { get; set; }

        // Constructor de la clase Persona
        public Persona(string nombre)
        {
            Nombre = nombre;
        }
    }

    // Clase que controla la lógica de la atracción y la asignación de asientos
    class Atraccion
    {
        // Cola que almacena a las personas en orden de llegada
        private Queue<Persona> colaPersonas;

        // Número máximo de asientos disponibles
        private int capacidadMaxima;

        // Contador de asientos ya asignados
        private int asientosAsignados;

        // Constructor de la clase Atraccion
        public Atraccion(int capacidad)
        {
            capacidadMaxima = capacidad;
            colaPersonas = new Queue<Persona>();
            asientosAsignados = 0;
        }

        // Método que permite ingresar una persona a la cola
        public void IngresarPersona(string nombre)
        {
            // Se verifica que aún existan asientos disponibles
            if (asientosAsignados + colaPersonas.Count < capacidadMaxima)
            {
                // Se encola a la persona respetando el orden de llegada
                colaPersonas.Enqueue(new Persona(nombre));
                Console.WriteLine($"La persona {nombre} ingresó a la cola.");
            }
            else
            {
                // Mensaje cuando ya no hay asientos disponibles
                Console.WriteLine("No hay asientos disponibles para ingresar a la cola.");
            }
        }

        // Método que asigna un asiento a la siguiente persona en la cola
        public void AsignarAsiento()
        {
            // Se valida que existan personas en la cola y asientos disponibles
            if (colaPersonas.Count > 0 && asientosAsignados < capacidadMaxima)
            {
                // Se atiende a la primera persona en la cola
                Persona personaAtendida = colaPersonas.Dequeue();
                asientosAsignados++;

                // Se muestra el resultado de la asignación
                Console.WriteLine($"Asiento asignado a {personaAtendida.Nombre}. " +
                                  $"Total de asientos ocupados: {asientosAsignados}");
            }
            else
            {
                // Mensaje cuando no hay personas o asientos
                Console.WriteLine("No hay personas en la cola o los asientos están completos.");
            }
        }

        // Método que muestra el estado actual del sistema
        public void MostrarEstado()
        {
            Console.WriteLine("\n--- Estado actual de la atracción ---");
            Console.WriteLine($"Asientos asignados: {asientosAsignados} de {capacidadMaxima}");
            Console.WriteLine("Personas en cola:");

            // Se recorre la cola para mostrar a las personas en espera
            if (colaPersonas.Count == 0)
            {
                Console.WriteLine("No hay personas en espera.");
            }
            else
            {
                foreach (Persona p in colaPersonas)
                {
                    Console.WriteLine($"- {p.Nombre}");
                }
            }
        }
    }

    // Clase principal del programa
    class Program
    {
        static void Main(string[] args)
        {
            // Se crea la atracción con una capacidad de 30 asientos
            Atraccion atraccion = new Atraccion(30);

            // Se simula el ingreso de 30 personas
            for (int i = 1; i <= 30; i++)
            {
                atraccion.IngresarPersona("Persona " + i);
            }

            // Se asignan los asientos respetando el orden de llegada
            for (int i = 1; i <= 30; i++)
            {
                atraccion.AsignarAsiento();
            }

            // Se muestra el estado final del sistema
            atraccion.MostrarEstado();

            // Pausa para visualizar los resultados en la consola
            Console.ReadKey();
        }
    }
}
