using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using SQLite;
namespace NotitasApp.Modelos
{
    public sealed class ConfiguracionSqlite
    {
        #region Patron Singleton
        public static ConfiguracionSqlite Instancia { get; } = new ConfiguracionSqlite();
        #endregion

        #region Propiedades
        public SQLiteAsyncConnection BaseDatos;
        #endregion

        #region Constructor
        private ConfiguracionSqlite()
        {
            //Asignamos la ruta en el dispositivo movil donde se guardará el archivo de la BD
            var RutaDB = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Notas.db");

            //Creamos la Conexion a la BD atraves de la ruta
            BaseDatos = new SQLiteAsyncConnection(RutaDB);

            //Creamos la tabla Alumnos
            BaseDatos.CreateTableAsync<AlumnoModel>().Wait();
        }
        #endregion
    }
}
