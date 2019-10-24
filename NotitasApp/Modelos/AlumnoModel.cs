using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace NotitasApp.Modelos
{
    #region NombreTabla
    [Table("Alumnos")]
    #endregion
    public class AlumnoModel
    {
        #region Propiedades
        private int id;
        [PrimaryKey, AutoIncrement, Unique]
        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        private string nombre_estudiante;
        public string NombreEstudiante
        {
            get { return nombre_estudiante; }
            set { nombre_estudiante = value; }
        }

        private double nota;
        public double Nota
        {
            get { return nota; }
            set { nota = value; }
        }

        private string grado;
        public string Grado
        {
            get { return grado; }
            set { grado = value; }
        }
        #endregion
    }
}
