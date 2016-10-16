using System;

namespace TFI.DAL
{
	public class EstadoPagoEntidad
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the EstadoPagoEntidad class.
		/// </summary>
		public EstadoPagoEntidad()
		{
		}

		/// <summary>
		/// Initializes a new instance of the EstadoPagoEntidad class.
		/// </summary>
		public EstadoPagoEntidad(string descripEstadoPago)
		{
			this.DescripEstadoPago = descripEstadoPago;
		}

		/// <summary>
		/// Initializes a new instance of the EstadoPagoEntidad class.
		/// </summary>
		public EstadoPagoEntidad(int idEstadoPago, string descripEstadoPago)
		{
			this.idEstadoPago = idEstadoPago;
			this.descripEstadoPago = descripEstadoPago;
		}

		#endregion

		#region Properties
		/// <summary>
		/// Gets or sets the IdEstadoPago value.
		/// </summary>
		public int IdEstadoPago { get; set; }

		/// <summary>
		/// Gets or sets the DescripEstadoPago value.
		/// </summary>
		public string DescripEstadoPago { get; set; }

		#endregion
	}
}
