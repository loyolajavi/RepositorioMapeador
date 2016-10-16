using System;

namespace TFI.DAL
{
	public class ProvinciaEntidad
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ProvinciaEntidad class.
		/// </summary>
		public ProvinciaEntidad()
		{
		}

		/// <summary>
		/// Initializes a new instance of the ProvinciaEntidad class.
		/// </summary>
		public ProvinciaEntidad(int idProvincia, string descripcionProvincia)
		{
			this.IdProvincia = idProvincia;
			this.DescripcionProvincia = descripcionProvincia;
		}

		#endregion

		#region Properties
		/// <summary>
		/// Gets or sets the IdProvincia value.
		/// </summary>
		public int IdProvincia { get; set; }

		/// <summary>
		/// Gets or sets the DescripcionProvincia value.
		/// </summary>
		public string DescripcionProvincia { get; set; }

		#endregion
	}
}
