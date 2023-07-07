using Empleados.Entities;
using Empleados.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Empleados23AM
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        EmpleadoServices services = new EmpleadoServices();
        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            Empleado empleado = new Empleado()
            {
                Name = txtNombre.Text,
                LastName = txtApellido.Text,
                Email = txtCorreo.Text,
                RegisterDate = DateTime.Now
            };
            if (!string.IsNullOrEmpty(txtNombre.Text) || !string.IsNullOrEmpty(txtApellido.Text) || !string.IsNullOrEmpty(txtApellido.Text))
            {
                services.Add(empleado);
                txtNombre.Clear();
                txtApellido.Clear();
                txtCorreo.Clear();
                MessageBox.Show("Los datos han sido agregados correctamente");
            }
            else
                MessageBox.Show("Los datos no sido agregados correctamente");
        }
        private void BtnRead_Click(object sender, RoutedEventArgs e)
        {
            int Id = int.Parse(txtId.Text);
            Empleado empleado = services.Read(Id);
            txtNombre.Text = empleado.Name;
            txtApellido.Text = empleado.LastName;
            txtCorreo.Text = empleado.Email;
            txtFecha.Text = empleado.RegisterDate.ToString();
            txtId.Text = empleado.PKEmpleado.ToString();
        }
        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            int Id = int.Parse(txtId.Text);
            if (string.IsNullOrEmpty(txtId.Text))
            {
                MessageBox.Show("ID NECESARIO");
            }
            else
            {
                services.Delete(Id);
                txtNombre.Clear();
                txtApellido.Clear();
                txtCorreo.Clear();
                txtFecha.Clear();
                MessageBox.Show("Se elimino el usuario");
            }
        }

        private void BtnUpdate_Click(object sender, RoutedEventArgs e)
        {
            int Id = int.Parse(txtId.Text);//para obtener el valor
            Empleado empleado = new Empleado();
            empleado.PKEmpleado = Id;
            empleado.Name = txtNombre.Text;
            empleado.LastName = txtApellido.Text;
            empleado.Email = txtCorreo.Text;
            services.Update(empleado);
            MessageBox.Show("Se modifico el registro");
            //empleado.RegisterDate = DateTime.Now;            
        }
    }
}