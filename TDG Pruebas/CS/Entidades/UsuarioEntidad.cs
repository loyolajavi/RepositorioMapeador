using System;

namespace TFI.DAL
{
	public class UsuarioEntidad
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the UsuarioEntidad class.
		/// </summary>
		public UsuarioEntidad()
		{
		}

		/// <summary>
		/// Initializes a new instance of the UsuarioEntidad class.
		/// </summary>
		public UsuarioEntidad(int idCondicionFiscal, int idUsuarioTipo, string nombre, string apellido, string dni, int cUIT, string email, string nombreUsuario, string clave, int cUITEmpresa)
		{
			this.IdCondicionFiscal = idCondicionFiscal;
			this.IdUsuarioTipo = idUsuarioTipo;
			this.Nombre = nombre;
			this.Apellido = apellido;
			this.Dni = dni;
			this.CUIT = cUIT;
			this.Email = email;
			this.NombreUsuario = nombreUsuario;
			this.Clave = clave;
			this.CUITEmpresa = cUITEmpresa;
		}

		/// <summary>
		/// Initializes a new instance of the UsuarioEntidad class.
		/// </summary>
		public UsuarioEntidad(int idUsuario, int idCondicionFiscal, int idUsuarioTipo, string nombre, string apellido, string dni, int cUIT, string email, string nombreUsuario, string clave, int cUITEmpresa)
		{
			this.idUsuario = idUsuario;
			this.idCondicionFiscal = idCondicionFiscal;
			this.idUsuarioTipo = idUsuarioTipo;
			this.nombre = nombre;
			this.apellido = apellido;
			this.dni = dni;
			this.cUIT = cUIT;
			this.email = email;
			this.nombreUsuario = nombreUsuario;
			this.clave = clave;
			this.cUITEmpresa = cUITEmpresa;
		}

		#endregion

		#region Properties
		/// <summary>
		/// Gets or sets the IdUsuario value.
		/// </summary>
		public int IdUsuario { get; set; }

		/// <summary>
		/// Gets or sets the IdCondicionFiscal value.
		/// </summary>
		public int IdCondicionFiscal { get; set; }

		/// <summary>
		/// Gets or sets the IdUsuarioTipo value.
		/// </summary>
		public int IdUsuarioTipo { get; set; }

		/// <summary>
		/// Gets or sets the Nombre value.
		/// </summary>
		public string Nombre { get; set; }

		/// <summary>
		/// Gets or sets the Apellido value.
		/// </summary>
		public string Apellido { get; set; }

		/// <summary>
		/// Gets or sets the Dni value.
		/// </summary>
		public string Dni { get; set; }

		/// <summary>
		/// Gets or sets the CUIT value.
		/// </summary>
		public int CUIT { get; set; }

		/// <summary>
		/// Gets or sets the Email value.
		/// </summary>
		public string Email { get; set; }

		/// <summary>
		/// Gets or sets the NombreUsuario value.
		/// </summary>
		public string NombreUsuario { get; set; }

		/// <summary>
		/// Gets or sets the Clave value.
		/// </summary>
		public string Clave { get; set; }

		/// <summary>
		/// Gets or sets the CUITEmpresa value.
		/// </summary>
		public int CUITEmpresa { get; set; }

		#endregion
	}
}
