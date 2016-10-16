using System;

namespace TFI.DAL
{
	public class MonedaEntidad
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the MonedaEntidad class.
		/// </summary>
		public MonedaEntidad()
		{
		}

		/// <summary>
		/// Initializes a new instance of the MonedaEntidad class.
		/// </summary>
		public MonedaEntidad(int idMoneda, string nombre, decimal cotizacion)
		{
			this.IdMoneda = idMoneda;
			this.Nombre = nombre;
			this.Cotizacion = cotizacion;
		}

		#endregion

		#region Properties
		/// <summary>
		/// Gets or sets the IdMoneda value.
		/// </summary>
		public int IdMoneda { get; set; }

		/// <summary>
		/// Gets or sets the Nombre value.
		/// </summary>
		public string Nombre { get; set; }

		/// <summary>
		/// Gets or sets the Cotizacion value.
		/// </summary>
		public decimal Cotizacion { get; set; }

		#endregion
	}
}
