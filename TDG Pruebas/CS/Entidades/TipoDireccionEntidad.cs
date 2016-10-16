using System;

namespace TFI.DAL
{
	public class TipoDireccionEntidad
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the TipoDireccionEntidad class.
		/// </summary>
		public TipoDireccionEntidad()
		{
		}

		/// <summary>
		/// Initializes a new instance of the TipoDireccionEntidad class.
		/// </summary>
		public TipoDireccionEntidad(int idTipoDireccion, string descripcionDireccion)
		{
			this.IdTipoDireccion = idTipoDireccion;
			this.DescripcionDireccion = descripcionDireccion;
		}

		#endregion

		#region Properties
		/// <summary>
		/// Gets or sets the IdTipoDireccion value.
		/// </summary>
		public int IdTipoDireccion { get; set; }

		/// <summary>
		/// Gets or sets the DescripcionDireccion value.
		/// </summary>
		public string DescripcionDireccion { get; set; }

		#endregion
	}
}
