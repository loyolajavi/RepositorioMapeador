using System;

namespace TFI.DAL
{
	public class UsuarioTipoEntidad
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the UsuarioTipoEntidad class.
		/// </summary>
		public UsuarioTipoEntidad()
		{
		}

		/// <summary>
		/// Initializes a new instance of the UsuarioTipoEntidad class.
		/// </summary>
		public UsuarioTipoEntidad(string descripcion)
		{
			this.Descripcion = descripcion;
		}

		/// <summary>
		/// Initializes a new instance of the UsuarioTipoEntidad class.
		/// </summary>
		public UsuarioTipoEntidad(int idUsuarioTipo, string descripcion)
		{
			this.idUsuarioTipo = idUsuarioTipo;
			this.descripcion = descripcion;
		}

		#endregion

		#region Properties
		/// <summary>
		/// Gets or sets the IdUsuarioTipo value.
		/// </summary>
		public int IdUsuarioTipo { get; set; }

		/// <summary>
		/// Gets or sets the Descripcion value.
		/// </summary>
		public string Descripcion { get; set; }

		#endregion
	}
}
