using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using NotitasApp.Modelos;
namespace NotitasApp.Servicios
{
    public interface ICrud
    {
        #region Metodos CRUD
        Task<int> CreateAlumno(AlumnoModel alumno);
        Task<int> UpdateAlumno(AlumnoModel alumno);
        Task<List<AlumnoModel>> ReadAlumnos();
        Task<AlumnoModel> ReadAlumnoNombre(string nombre);
        Task<int> DeleteAlumno(AlumnoModel alumno);
        #endregion
    }
}
