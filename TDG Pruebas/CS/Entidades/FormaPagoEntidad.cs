using System;

namespace TFI.DAL
{
	public class FormaPagoEntidad
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the FormaPagoEntidad class.
		/// </summary>
		public FormaPagoEntidad()
		{
		}

		/// <summary>
		/// Initializes a new instance of the FormaPagoEntidad class.
		/// </summary>
		public FormaPagoEntidad(string descripFormaPago)
		{
			this.DescripFormaPago = descripFormaPago;
		}

		/// <summary>
		/// Initializes a new instance of the FormaPagoEntidad class.
		/// </summary>
		public FormaPagoEntidad(int idFormaPago, string descripFormaPago)
		{
			this.idFormaPago = idFormaPago;
			this.descripFormaPago = descripFormaPago;
		}

		#endregion

		#region Properties
		/// <summary>
		/// Gets or sets the IdFormaPago value.
		/// </summary>
		public int IdFormaPago { get; set; }

		/// <summary>
		/// Gets or sets the DescripFormaPago value.
		/// </summary>
		public string DescripFormaPago { get; set; }

		#endregion
	}
}
