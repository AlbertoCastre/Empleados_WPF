using Empleados.Context;
using Empleados.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Update.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Empleados.Services
{
    public class EmpleadoServices
    {
        public void Add(Empleado request)
        {
            try
            {   //abre la cadena de conexion y todo lo que se encuentre en using entrará a la DB
                using (var _context = new ApplicationDbContext())//para usar la base de datos
                {
                    Empleado empleado = new Empleado()//recibe los
                    {
                        Name = request.Name,
                        LastName = request.LastName,
                        Email = request.Email,
                        RegisterDate = DateTime.Now
                    };
                    _context.Empleados.Add(empleado);
                    _context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Sucedió un error" + ex.Message);
            }
        }
        public Empleado Read(int Id)
        {
            try
            {

                Empleado empleado = new Empleado();
                using (var _context = new ApplicationDbContext())
                {
                    empleado = _context.Empleados.Find(Id);//Empleados.Where(varibale para consultar)
                    return empleado;
                }
            }
            catch (Exception ex)
            {

                throw new Exception("Sucedió un error" + ex.Message);
            }
        }
        public void Delete(int Id)
        {
            try
            {
                using (var _context = new ApplicationDbContext())
                {
                    Empleado empleado = _context.Empleados.Find(Id);
                    if (empleado != null)
                    {
                        _context.Empleados.Remove(empleado);
                        _context.SaveChanges();
                    }
                    else
                    {
                        MessageBox.Show("NO HAY REGISTRO");
                    }
                }
            }
            catch (Exception ex)
            {

                throw new Exception("ERROR: " + ex.Message);
            }
        }
        public void Update(Empleado request)
        {
            try
            {
                using (var _context = new ApplicationDbContext())
                {
                    Empleado update = _context.Empleados.Find(request.PKEmpleado);
                    update.Name = request.Name;
                    update.LastName = request.LastName;
                    update.Email = request.Email;
                    update.RegisterDate = request.RegisterDate;
                    _context.Empleados.Update(update);
                    //_context.Entry(update).State = EntityState.Modified;
                    _context.SaveChanges();
                }
            }
            catch (Exception ex)
            {

                throw new Exception("Sucedio un error " + ex.Message);
            }
        }
    }
}