using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using NotitasApp.Servicios;
namespace NotitasApp.Modelos
{
    public sealed class CrudModel : ICrud
    {
        #region Patron Singleton
        public static CrudModel Instancia { get; } = new CrudModel();
        #endregion

        #region Constructor
        private CrudModel() { }
        #endregion

        #region Metodos CRUD
        public Task<int> CreateAlumno(AlumnoModel alumno)
        {
            /*Insertamos el Alumno INSERT INTO Alumnos (NombreEstudiante, Nota, Grado) 
                                                    VALUES (alumno.NombreEstudiante, alumno.Nota, alumno.Grado)*/
            return ConfiguracionSqlite.Instancia.BaseDatos.InsertAsync(alumno);
        }

        public Task<int> DeleteAlumno(AlumnoModel alumno)
        {
            //Borramos el Alumno DELETE FROM Alumnos WHERE ID = alumno.ID
            return ConfiguracionSqlite.Instancia.BaseDatos.DeleteAsync(alumno);
        }

        public Task<AlumnoModel> ReadAlumnoNombre(string nombre)
        {
            //SELECT * FROM Alumnos WHERE NombreEstudiante = nombre
            return ConfiguracionSqlite.Instancia.BaseDatos.Table<AlumnoModel>()
                .Where(alumno => alumno.NombreEstudiante == nombre).FirstOrDefaultAsync();
        }

        public Task<List<AlumnoModel>> ReadAlumnos()
        {
            //SELECT * FROM Alumnos
            return ConfiguracionSqlite.Instancia.BaseDatos.Table<AlumnoModel>().ToListAsync();
        }

        public Task<int> UpdateAlumno(AlumnoModel alumno)
        {
            //UPDATE Alumnos SET NombreEstudiante = alumno.NombreEstudiante, Nota = alumno.Nota, Grado = alumno.Grado
            return ConfiguracionSqlite.Instancia.BaseDatos.UpdateAsync(alumno);
        }
        #endregion
    }
}
