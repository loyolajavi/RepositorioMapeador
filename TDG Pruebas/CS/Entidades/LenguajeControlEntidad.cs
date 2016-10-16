using System;

namespace TFI.DAL
{
	public class LenguajeControlEntidad
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the LenguajeControlEntidad class.
		/// </summary>
		public LenguajeControlEntidad()
		{
		}

		/// <summary>
		/// Initializes a new instance of the LenguajeControlEntidad class.
		/// </summary>
		public LenguajeControlEntidad(string texto, int idLenguaje, string valor)
		{
			this.Texto = texto;
			this.IdLenguaje = idLenguaje;
			this.Valor = valor;
		}

		#endregion

		#region Properties
		/// <summary>
		/// Gets or sets the Texto value.
		/// </summary>
		public string Texto { get; set; }

		/// <summary>
		/// Gets or sets the IdLenguaje value.
		/// </summary>
		public int IdLenguaje { get; set; }

		/// <summary>
		/// Gets or sets the Valor value.
		/// </summary>
		public string Valor { get; set; }

		#endregion
	}
}
