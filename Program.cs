using System;
using System.Collections.Generic;
using CineORM.Models;
using CineORM.Negocio;

class Program
{
    static void Main()
    {
        ActoresController actoresController = new ActoresController();
        BoletosController boletosController = new BoletosController();

        // ✅ Agregar un nuevo actor
        var nuevoActor = new Actore
        {
            Nombre = "Pepeli",
            Apellido = "Lopo",
            FechaNacimiento = new DateOnly(1985, 11, 11),
            Nacionalidad = "Estadounidense"
        };
        actoresController.AgregarActor(nuevoActor);
        Console.WriteLine("✅ Actor agregado correctamente.\n");

        // ✅ Listar todos los actores
        Console.WriteLine("🎭 Listado de Actores:");
        List<Actore> actores = actoresController.ListadoActores();
        foreach (var actor in actores)
        {
            Console.WriteLine($"🆔 {actor.Id} | {actor.Nombre} {actor.Apellido} | 🎂 {actor.FechaNacimiento} | 🌍 {actor.Nacionalidad}");
        }

        // ✅ Buscar actores por nacionalidad
        Console.WriteLine("\n🔍 Buscando actores de nacionalidad 'Estadounidense':");
        List<Actore> actoresFiltrados = actoresController.ObtenerActoresPorNacionalidad("Estadounidense");
        foreach (var actor in actoresFiltrados)
        {
            Console.WriteLine($"🎬 {actor.Nombre} {actor.Apellido}");
        }

        // ✅ Actualizar un actor (suponiendo que existe con ID 1)
        Console.WriteLine("\n✏️ Actualizando actor con ID 1...");
        actoresController.ActualizarActor(1, "Leonardo Updated");
        Console.WriteLine("✅ Actor actualizado.\n");

        // ✅ Eliminar un actor (suponiendo que existe con ID 2)
        Console.WriteLine("\n🗑 Eliminando actor con ID 2...");
        actoresController.EliminarActor(2);
        Console.WriteLine("✅ Actor eliminado.");

        foreach (var actor in actores)
        {
            Console.WriteLine($"🆔 {actor.Id} | {actor.Nombre} {actor.Apellido} | 🎂 {actor.FechaNacimiento} | 🌍 {actor.Nacionalidad}");
        }

        // ============================================
        // 🔥 CRUD PARA BOLETOS
        // ============================================

        // ✅ Agregar un nuevo boleto
        var nuevoBoleto = new Boleto
        {
            FuncionId = 1,  // Debe existir una función con este ID
            UsuarioId = 3,  // Debe existir un usuario con este ID (opcional)
            Asiento = "C17",
            Precio = 12.50m,
            FechaCompra = DateTime.Now
        };
        boletosController.AgregarBoleto(nuevoBoleto);
        Console.WriteLine("🎟 Boleto agregado correctamente.\n");

        // ✅ Listar todos los boletos
        Console.WriteLine("🎟 Listado de Boletos:");
        List<Boleto> boletos = boletosController.ListadoBoletos();
        foreach (var boleto in boletos)
        {
            Console.WriteLine($"🆔 {boleto.Id} | 🎭 Función {boleto.FuncionId} | 💺 Asiento {boleto.Asiento} | 💰 Precio: {boleto.Precio:C} | 📅 {boleto.FechaCompra}");
        }

        // ✅ Obtener boletos por usuario (ID 3)
        Console.WriteLine("\n🔍 Buscando boletos del usuario con ID 3:");
        List<Boleto> boletosUsuario = boletosController.ObtenerBoletosPorUsuario(3);
        foreach (var boleto in boletosUsuario)
        {
            Console.WriteLine($"🎟 Función {boleto.FuncionId} | Asiento {boleto.Asiento}");
        }

        // ✅ Actualizar un boleto (suponiendo que existe con ID 1)
        Console.WriteLine("\n✏️ Actualizando boleto con ID 1...");
        boletosController.ActualizarBoleto(1, "D20", 15.00m);
        Console.WriteLine("✅ Boleto actualizado.\n");

        // ✅ Eliminar un boleto (suponiendo que existe con ID 2)
        Console.WriteLine("\n🗑 Eliminando boleto con ID 2...");
        boletosController.EliminarBoleto(2);
        Console.WriteLine("✅ Boleto eliminado.");

        Console.WriteLine("🎟 Listado de Boletos:");
        foreach (var boleto in boletos)
        {
            Console.WriteLine($"🆔 {boleto.Id} | 🎭 Función {boleto.FuncionId} | 💺 Asiento {boleto.Asiento} | 💰 Precio: {boleto.Precio:C} | 📅 {boleto.FechaCompra}");
        }

        Console.WriteLine("\n🎬 Fin del programa.");
    }
}
