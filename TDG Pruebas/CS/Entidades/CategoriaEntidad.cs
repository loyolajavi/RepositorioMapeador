using System;

namespace TFI.DAL
{
	public class CategoriaEntidad
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the CategoriaEntidad class.
		/// </summary>
		public CategoriaEntidad()
		{
		}

		/// <summary>
		/// Initializes a new instance of the CategoriaEntidad class.
		/// </summary>
		public CategoriaEntidad(string descripCategoria)
		{
			this.DescripCategoria = descripCategoria;
		}

		/// <summary>
		/// Initializes a new instance of the CategoriaEntidad class.
		/// </summary>
		public CategoriaEntidad(int idCategoria, string descripCategoria)
		{
			this.idCategoria = idCategoria;
			this.descripCategoria = descripCategoria;
		}

		#endregion

		#region Properties
		/// <summary>
		/// Gets or sets the IdCategoria value.
		/// </summary>
		public int IdCategoria { get; set; }

		/// <summary>
		/// Gets or sets the DescripCategoria value.
		/// </summary>
		public string DescripCategoria { get; set; }

		#endregion
	}
}
