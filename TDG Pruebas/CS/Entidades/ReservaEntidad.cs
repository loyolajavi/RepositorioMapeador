using System;

namespace TFI.DAL
{
	public class ReservaEntidad
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ReservaEntidad class.
		/// </summary>
		public ReservaEntidad()
		{
		}

		/// <summary>
		/// Initializes a new instance of the ReservaEntidad class.
		/// </summary>
		public ReservaEntidad(int idPedido, int idPedidoDetalle, int idSucursal, bool activo, DateTime fecha)
		{
			this.IdPedido = idPedido;
			this.IdPedidoDetalle = idPedidoDetalle;
			this.IdSucursal = idSucursal;
			this.Activo = activo;
			this.Fecha = fecha;
		}

		/// <summary>
		/// Initializes a new instance of the ReservaEntidad class.
		/// </summary>
		public ReservaEntidad(int idReserva, int idPedido, int idPedidoDetalle, int idSucursal, bool activo, DateTime fecha)
		{
			this.idReserva = idReserva;
			this.idPedido = idPedido;
			this.idPedidoDetalle = idPedidoDetalle;
			this.idSucursal = idSucursal;
			this.activo = activo;
			this.fecha = fecha;
		}

		#endregion

		#region Properties
		/// <summary>
		/// Gets or sets the IdReserva value.
		/// </summary>
		public int IdReserva { get; set; }

		/// <summary>
		/// Gets or sets the IdPedido value.
		/// </summary>
		public int IdPedido { get; set; }

		/// <summary>
		/// Gets or sets the IdPedidoDetalle value.
		/// </summary>
		public int IdPedidoDetalle { get; set; }

		/// <summary>
		/// Gets or sets the IdSucursal value.
		/// </summary>
		public int IdSucursal { get; set; }

		/// <summary>
		/// Gets or sets the Activo value.
		/// </summary>
		public bool Activo { get; set; }

		/// <summary>
		/// Gets or sets the Fecha value.
		/// </summary>
		public DateTime Fecha { get; set; }

		#endregion
	}
}
