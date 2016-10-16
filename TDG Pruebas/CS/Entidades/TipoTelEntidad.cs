using System;

namespace TFI.DAL
{
	public class TipoTelEntidad
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the TipoTelEntidad class.
		/// </summary>
		public TipoTelEntidad()
		{
		}

		/// <summary>
		/// Initializes a new instance of the TipoTelEntidad class.
		/// </summary>
		public TipoTelEntidad(string descripcionTipoTel)
		{
			this.DescripcionTipoTel = descripcionTipoTel;
		}

		/// <summary>
		/// Initializes a new instance of the TipoTelEntidad class.
		/// </summary>
		public TipoTelEntidad(int idTipoTel, string descripcionTipoTel)
		{
			this.idTipoTel = idTipoTel;
			this.descripcionTipoTel = descripcionTipoTel;
		}

		#endregion

		#region Properties
		/// <summary>
		/// Gets or sets the IdTipoTel value.
		/// </summary>
		public int IdTipoTel { get; set; }

		/// <summary>
		/// Gets or sets the DescripcionTipoTel value.
		/// </summary>
		public string DescripcionTipoTel { get; set; }

		#endregion
	}
}
