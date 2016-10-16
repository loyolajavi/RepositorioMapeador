using System;

namespace TFI.DAL
{
	public class MonedaEmpresaEntidad
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the MonedaEmpresaEntidad class.
		/// </summary>
		public MonedaEmpresaEntidad()
		{
		}

		/// <summary>
		/// Initializes a new instance of the MonedaEmpresaEntidad class.
		/// </summary>
		public MonedaEmpresaEntidad(int idMoneda, int cUITEmpresa)
		{
			this.IdMoneda = idMoneda;
			this.CUITEmpresa = cUITEmpresa;
		}

		#endregion

		#region Properties
		/// <summary>
		/// Gets or sets the IdMoneda value.
		/// </summary>
		public int IdMoneda { get; set; }

		/// <summary>
		/// Gets or sets the CUITEmpresa value.
		/// </summary>
		public int CUITEmpresa { get; set; }

		#endregion
	}
}
