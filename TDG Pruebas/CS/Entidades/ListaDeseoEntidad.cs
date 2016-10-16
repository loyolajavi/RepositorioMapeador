using System;

namespace TFI.DAL
{
	public class ListaDeseoEntidad
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ListaDeseoEntidad class.
		/// </summary>
		public ListaDeseoEntidad()
		{
		}

		/// <summary>
		/// Initializes a new instance of the ListaDeseoEntidad class.
		/// </summary>
		public ListaDeseoEntidad(int cUIT, string nombreUsuario)
		{
			this.CUIT = cUIT;
			this.NombreUsuario = nombreUsuario;
		}

		/// <summary>
		/// Initializes a new instance of the ListaDeseoEntidad class.
		/// </summary>
		public ListaDeseoEntidad(int idListaDeseos, int cUIT, string nombreUsuario)
		{
			this.idListaDeseos = idListaDeseos;
			this.cUIT = cUIT;
			this.nombreUsuario = nombreUsuario;
		}

		#endregion

		#region Properties
		/// <summary>
		/// Gets or sets the IdListaDeseos value.
		/// </summary>
		public int IdListaDeseos { get; set; }

		/// <summary>
		/// Gets or sets the CUIT value.
		/// </summary>
		public int CUIT { get; set; }

		/// <summary>
		/// Gets or sets the NombreUsuario value.
		/// </summary>
		public string NombreUsuario { get; set; }

		#endregion
	}
}
