using System;

namespace TFI.DAL
{
	public class MarcaEntidad
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the MarcaEntidad class.
		/// </summary>
		public MarcaEntidad()
		{
		}

		/// <summary>
		/// Initializes a new instance of the MarcaEntidad class.
		/// </summary>
		public MarcaEntidad(string descripcionMarca)
		{
			this.DescripcionMarca = descripcionMarca;
		}

		/// <summary>
		/// Initializes a new instance of the MarcaEntidad class.
		/// </summary>
		public MarcaEntidad(int idMarca, string descripcionMarca)
		{
			this.IdMarca = idMarca;
			this.DescripcionMarca = descripcionMarca;
		}

		#endregion

		#region Properties
		/// <summary>
		/// Gets or sets the IdMarca value.
		/// </summary>
		public int IdMarca { get; set; }

		/// <summary>
		/// Gets or sets the DescripcionMarca value.
		/// </summary>
		public string DescripcionMarca { get; set; }

		#endregion
	}
}
