using System;

namespace TFI.DAL
{
	public class EmpresaEntidad
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the EmpresaEntidad class.
		/// </summary>
		public EmpresaEntidad()
		{
		}

		/// <summary>
		/// Initializes a new instance of the EmpresaEntidad class.
		/// </summary>
		public EmpresaEntidad(int cUIT, string nombreEmpresa)
		{
			this.CUIT = cUIT;
			this.NombreEmpresa = nombreEmpresa;
		}

		#endregion

		#region Properties
		/// <summary>
		/// Gets or sets the CUIT value.
		/// </summary>
		public int CUIT { get; set; }

		/// <summary>
		/// Gets or sets the NombreEmpresa value.
		/// </summary>
		public string NombreEmpresa { get; set; }

		#endregion
	}
}
