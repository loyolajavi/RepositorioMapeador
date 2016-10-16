using System;

namespace TFI.DAL
{
	public class FormaEntregaEntidad
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the FormaEntregaEntidad class.
		/// </summary>
		public FormaEntregaEntidad()
		{
		}

		/// <summary>
		/// Initializes a new instance of the FormaEntregaEntidad class.
		/// </summary>
		public FormaEntregaEntidad(string descripcionFormaEntrega)
		{
			this.DescripcionFormaEntrega = descripcionFormaEntrega;
		}

		/// <summary>
		/// Initializes a new instance of the FormaEntregaEntidad class.
		/// </summary>
		public FormaEntregaEntidad(int idFormaEntrega, string descripcionFormaEntrega)
		{
			this.IdFormaEntrega = idFormaEntrega;
			this.DescripcionFormaEntrega = descripcionFormaEntrega;
		}

		#endregion

		#region Properties
		/// <summary>
		/// Gets or sets the IdFormaEntrega value.
		/// </summary>
		public int IdFormaEntrega { get; set; }

		/// <summary>
		/// Gets or sets the DescripcionFormaEntrega value.
		/// </summary>
		public string DescripcionFormaEntrega { get; set; }

		#endregion
	}
}
