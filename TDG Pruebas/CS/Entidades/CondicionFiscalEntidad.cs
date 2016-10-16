using System;

namespace TFI.DAL
{
	public class CondicionFiscalEntidad
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the CondicionFiscalEntidad class.
		/// </summary>
		public CondicionFiscalEntidad()
		{
		}

		/// <summary>
		/// Initializes a new instance of the CondicionFiscalEntidad class.
		/// </summary>
		public CondicionFiscalEntidad(string descripcion)
		{
			this.Descripcion = descripcion;
		}

		/// <summary>
		/// Initializes a new instance of the CondicionFiscalEntidad class.
		/// </summary>
		public CondicionFiscalEntidad(int idCondicionFiscal, string descripcion)
		{
			this.idCondicionFiscal = idCondicionFiscal;
			this.descripcion = descripcion;
		}

		#endregion

		#region Properties
		/// <summary>
		/// Gets or sets the IdCondicionFiscal value.
		/// </summary>
		public int IdCondicionFiscal { get; set; }

		/// <summary>
		/// Gets or sets the Descripcion value.
		/// </summary>
		public string Descripcion { get; set; }

		#endregion
	}
}
