using System;

namespace TFI.DAL
{
	public class EstadoPedidoEntidad
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the EstadoPedidoEntidad class.
		/// </summary>
		public EstadoPedidoEntidad()
		{
		}

		/// <summary>
		/// Initializes a new instance of the EstadoPedidoEntidad class.
		/// </summary>
		public EstadoPedidoEntidad(string descripcionEstadoPedido)
		{
			this.DescripcionEstadoPedido = descripcionEstadoPedido;
		}

		/// <summary>
		/// Initializes a new instance of the EstadoPedidoEntidad class.
		/// </summary>
		public EstadoPedidoEntidad(int idEstadoPedido, string descripcionEstadoPedido)
		{
			this.IdEstadoPedido = idEstadoPedido;
			this.DescripcionEstadoPedido = descripcionEstadoPedido;
		}

		#endregion

		#region Properties
		/// <summary>
		/// Gets or sets the IdEstadoPedido value.
		/// </summary>
		public int IdEstadoPedido { get; set; }

		/// <summary>
		/// Gets or sets the DescripcionEstadoPedido value.
		/// </summary>
		public string DescripcionEstadoPedido { get; set; }

		#endregion
	}
}
