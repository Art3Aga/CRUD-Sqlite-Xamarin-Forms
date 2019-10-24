using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NotitasApp.Modelos;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NotitasApp.Vistas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AgregarAlumnoPage : ContentPage
    {
        public AgregarAlumnoPage()
        {
            InitializeComponent();
        }

        private void btnGuardar_Clicked(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtNombre.Text) || string.IsNullOrEmpty(txtGrado.Text) || string.IsNullOrEmpty(txtNota.Text))
                {
                    DisplayAlert("ERROR", "Faltan Datos!!", "OK");
                }
                else
                {
                    Task<int> GuardarAlumno = CrudModel.Instancia
                    .CreateAlumno(new AlumnoModel()
                    {
                        NombreEstudiante = txtNombre.Text,
                        Nota = Convert.ToDouble(txtNota.Text),
                        Grado = txtGrado.Text
                    });
                    if (GuardarAlumno.Result == 1)
                    {
                        DisplayAlert("Info", $"Alumno {txtNombre.Text} Guardado Correctamente", "OK");
                        Navigation.PopAsync();
                    }
                }
            }
            catch (Exception ex)
            {
                DisplayAlert("Error", $"Error al Guardar {ex.Message}", "OK");
            }
        }

        private void btnCancelar_Clicked(object sender, EventArgs e)
        {
            txtNombre.Text = "";
            txtGrado.Text = "";
            txtNota.Text = "";
        }
    }
}