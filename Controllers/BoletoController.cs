using CineORM.Clases;
using CineORM.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CineORM.Negocio
{
    public sealed class BoletosController : CineContexto<Boleto, CineContext>
    {
        public BoletosController() { }

        // Obtener todos los boletos
        public List<Boleto> ListadoBoletos()
        {
            return (from b in Boletos select b).ToList();
        }

        // Obtener boletos por usuario
        public List<Boleto> ObtenerBoletosPorUsuario(int usuarioId)
        {
            return (from b in Boletos where b.UsuarioId == usuarioId select b).ToList();
        }

        // Obtener boletos por función
        public List<Boleto> ObtenerBoletosPorFuncion(int funcionId)
        {
            return (from b in Boletos where b.FuncionId == funcionId select b).ToList();
        }

        // Obtener boletos comprados en una fecha específica
        public List<Boleto> ObtenerBoletosPorFechaCompra(DateTime fecha)
        {
            return (from b in Boletos where b.FechaCompra.Date == fecha.Date select b).ToList();
        }

        // Agregar un nuevo boleto
        public void AgregarBoleto(Boleto boleto)
        {
            this.Add(boleto);
        }

        // Eliminar un boleto por ID
        public void EliminarBoleto(int idBoleto)
        {
            var boleto = (from b in Boletos where b.Id == idBoleto select b).FirstOrDefault();
            if (boleto != null)
            {
                this.Remove(boleto);
            }
        }

        // Actualizar datos de un boleto (cambiar asiento y precio)
        public void ActualizarBoleto(int idBoleto, string nuevoAsiento, decimal nuevoPrecio)
        {
            var boleto = (from b in Boletos where b.Id == idBoleto select b).FirstOrDefault();
            if (boleto != null)
            {
                boleto.Asiento = nuevoAsiento;
                boleto.Precio = nuevoPrecio;
                this.Update(boleto);
            }
        }
    }
}
