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
    public partial class AlumnoDetallePage : ContentPage
    {
        public AlumnoDetallePage()
        {
            InitializeComponent();
        }

        private void btnModificar_Clicked(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtNombre.Text) || string.IsNullOrEmpty(txtGrado.Text) || string.IsNullOrEmpty(txtNota.Text))
                {
                    DisplayAlert("ERROR", "Faltan Datos!!", "OK");
                }
                else
                {
                    AlumnoModel alumnoSeleccionado = BindingContext as AlumnoModel;
                    var ModificarAlumno = CrudModel.Instancia.UpdateAlumno(alumnoSeleccionado);
                    if (ModificarAlumno.Result == 1)
                    {
                        DisplayAlert("Info", $"Alumno {alumnoSeleccionado.NombreEstudiante} Actualizado Correctamente", "OK");
                        Navigation.PopAsync();
                    }
                }
            }
            catch (Exception ex)
            {
                DisplayAlert("Error", $"Error al Actualizar {ex.Message}", "OK");
            }
        }
    }
}