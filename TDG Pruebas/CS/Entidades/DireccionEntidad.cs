using System;

namespace TFI.DAL
{
	public class DireccionEntidad
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the DireccionEntidad class.
		/// </summary>
		public DireccionEntidad()
		{
		}

		/// <summary>
		/// Initializes a new instance of the DireccionEntidad class.
		/// </summary>
		public DireccionEntidad(string calle, int numero, int piso, string departamento, string localidad, int idProvincia, int idTipoDireccion)
		{
			this.Calle = calle;
			this.Numero = numero;
			this.Piso = piso;
			this.Departamento = departamento;
			this.Localidad = localidad;
			this.IdProvincia = idProvincia;
			this.IdTipoDireccion = idTipoDireccion;
		}

		/// <summary>
		/// Initializes a new instance of the DireccionEntidad class.
		/// </summary>
		public DireccionEntidad(int idDireccion, string calle, int numero, int piso, string departamento, string localidad, int idProvincia, int idTipoDireccion)
		{
			this.idDireccion = idDireccion;
			this.calle = calle;
			this.numero = numero;
			this.piso = piso;
			this.departamento = departamento;
			this.localidad = localidad;
			this.idProvincia = idProvincia;
			this.idTipoDireccion = idTipoDireccion;
		}

		#endregion

		#region Properties
		/// <summary>
		/// Gets or sets the IdDireccion value.
		/// </summary>
		public int IdDireccion { get; set; }

		/// <summary>
		/// Gets or sets the Calle value.
		/// </summary>
		public string Calle { get; set; }

		/// <summary>
		/// Gets or sets the Numero value.
		/// </summary>
		public int Numero { get; set; }

		/// <summary>
		/// Gets or sets the Piso value.
		/// </summary>
		public int Piso { get; set; }

		/// <summary>
		/// Gets or sets the Departamento value.
		/// </summary>
		public string Departamento { get; set; }

		/// <summary>
		/// Gets or sets the Localidad value.
		/// </summary>
		public string Localidad { get; set; }

		/// <summary>
		/// Gets or sets the IdProvincia value.
		/// </summary>
		public int IdProvincia { get; set; }

		/// <summary>
		/// Gets or sets the IdTipoDireccion value.
		/// </summary>
		public int IdTipoDireccion { get; set; }

		#endregion
	}
}