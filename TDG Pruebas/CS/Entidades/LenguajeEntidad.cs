using System;

namespace TFI.DAL
{
	public class LenguajeEntidad
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the LenguajeEntidad class.
		/// </summary>
		public LenguajeEntidad()
		{
		}

		/// <summary>
		/// Initializes a new instance of the LenguajeEntidad class.
		/// </summary>
		public LenguajeEntidad(string descripcionLenguaje)
		{
			this.DescripcionLenguaje = descripcionLenguaje;
		}

		/// <summary>
		/// Initializes a new instance of the LenguajeEntidad class.
		/// </summary>
		public LenguajeEntidad(int idLenguaje, string descripcionLenguaje)
		{
			this.IdLenguaje = idLenguaje;
			this.DescripcionLenguaje = descripcionLenguaje;
		}

		#endregion

		#region Properties
		/// <summary>
		/// Gets or sets the IdLenguaje value.
		/// </summary>
		public int IdLenguaje { get; set; }

		/// <summary>
		/// Gets or sets the DescripcionLenguaje value.
		/// </summary>
		public string DescripcionLenguaje { get; set; }

		#endregion
	}
}
