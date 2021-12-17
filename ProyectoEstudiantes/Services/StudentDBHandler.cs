using Newtonsoft.Json;
using ProyectoEstudiantes.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoEstudiantes.Services
{
    public class StudentDBHandler
    {
        private static ObservableCollection<EstudianteModel> listaEstudiantes = new ObservableCollection<EstudianteModel>();

        public static void CargarListaFicticia()
        {
            for(int i = 0; i<60; i++)
            {
                EstudianteModel e = new EstudianteModel();
                e._id = i.ToString();
                e.Nombre = "Estudiante "+ i.ToString(); 
                e.Curso = "Primero";
                listaEstudiantes.Add(e);
            }
        }


        public static bool GuardarNotasEstudiante(EstudianteModel estudiante)
        {
            bool okguardar = false;

            foreach (EstudianteModel e in listaEstudiantes)
            {
                if (e._id == estudiante._id)
                {
                    e.Notas.DI = estudiante.Notas.DI;
                    e.Notas.EIE = estudiante.Notas.EIE;
                    e.Notas.SGE = estudiante.Notas.SGE;
                    e.Notas.PMDM = estudiante.Notas.PMDM;
                    e.Notas.PSP = estudiante.Notas.PSP;
                    e.Notas.AD = estudiante.Notas.AD;
                    okguardar = true;
                    break;
                }

            }

            return okguardar;
        }

        public static bool GuardarEstudiante(EstudianteModel estudiante)
        {
            bool okguardar = false;

            foreach(EstudianteModel e in listaEstudiantes)
            {
                if(e._id == estudiante._id)
                {
                    e.Nombre = estudiante.Nombre;
                    e.Fecha = estudiante.Fecha;
                    e.Curso = estudiante.Curso;
                    okguardar = true;
                    break;
                }
                
            }

            return okguardar;
        }

        public static bool NuevoEstudiante2(EstudianteModel estudiante)
        {
            bool okinsertar = false;

            try
            {
                listaEstudiantes.Add(estudiante);
                okinsertar = true;
            }catch (Exception ex) { }

            return okinsertar;
        }

        public static ObservableCollection<EstudianteModel> ObtenerListaEstudiantes()
        {
            return listaEstudiantes;
        }



        public static async Task<bool> NuevoEstudiante(EstudianteModel estudiante)
        {
            bool okinsertar = false;

            var handler = new WinHttpHandler();
            var client = new HttpClient(handler);

            var request = new HttpRequestMessage(HttpMethod.Post, "http://localhost:5000/students");

            var data = JsonConvert.SerializeObject(estudiante);

            request.Headers.Add("Accept", "application/json");
            request.Content = new StringContent(data.ToString(), Encoding.UTF8, "application/json");

            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                string responseJSON = await response.Content.ReadAsStringAsync();
                Console.WriteLine(responseJSON);
                okinsertar = true;
            }
            
            return okinsertar;
        }

    }
}
