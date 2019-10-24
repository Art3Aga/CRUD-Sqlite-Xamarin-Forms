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
    public partial class HomePage : ContentPage
    {
        List<AlumnoModel> AlumnosLista = new List<AlumnoModel>();
        public HomePage()
        {
            InitializeComponent();
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            var resultado = await CrudModel.Instancia.ReadAlumnos();
            AlumnosLista = resultado.ToList();
            listViewAlumnos.ItemsSource = AlumnosLista;
        }

        private async void btnAlumno_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AgregarAlumnoPage());
        }

        private void txtBuscar_TextChanged(object sender, TextChangedEventArgs e)
        {
            List<AlumnoModel> busqueda = AlumnosLista.Where(alumno =>  alumno.NombreEstudiante.Contains(txtBuscar.Text)).ToList();
            listViewAlumnos.ItemsSource = busqueda;
        }

        private async void btnEliminar_Clicked(object sender, EventArgs e)
        {
            var item = ((MenuItem)sender);
            var alumno = ((AlumnoModel)item.CommandParameter);
            try
            {
                var eliminarAlumno = CrudModel.Instancia.DeleteAlumno(alumno);
                if (eliminarAlumno.Result == 1)
                {
                    await DisplayAlert("Info", $"Alumno Eliminado Correctamente", "OK");
                    var resultado = await CrudModel.Instancia.ReadAlumnos();
                    AlumnosLista = resultado.ToList();
                    listViewAlumnos.ItemsSource = AlumnosLista;
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", $"Error al Eliminar {ex.Message}", "OK");
            }
        }

        private async void listViewAlumnos_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            AlumnoModel item = e.SelectedItem as AlumnoModel;
            await Navigation.PushAsync(new AlumnoDetallePage() { BindingContext = item });
        }
    }
}