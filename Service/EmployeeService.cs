using BusinessObject;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class EmployeeService
    {
        /// <summary>
        /// Listado de Empleados
        /// </summary>
        /// <returns></returns>
        public static async Task<List<EmployeeBO>> Listado()
        {
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://crudcrud.com/api/bcd2318cbafb413db148ac63c28b51da/qbo"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    List<EmployeeBO> employees = JsonConvert.DeserializeObject<List<EmployeeBO>>(apiResponse);
                    return employees;
                }
            }
        }

        /// <summary>
        /// Insertar Empleados
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        public static async Task<EmployeeBO> Insertar(EmployeeBO employee)
        {
            var data = new
            {
                nombre = employee.nombre,
                salario = employee.salario,
                edad = employee.edad,
                perfil = employee.perfil
            };

            var contenido = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.PostAsync("https://crudcrud.com/api/bcd2318cbafb413db148ac63c28b51da/qbo", contenido))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    EmployeeBO employeeResponse = JsonConvert.DeserializeObject<EmployeeBO>(apiResponse);
                    return employeeResponse;
                }
            }

        }

        /// <summary>
        /// Actualizar Empleados
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        public static async Task<EmployeeBO> Actualizar(EmployeeBO employee)
        {
            var data = new
            {
                nombre = employee.nombre,
                salario = employee.salario,
                edad = employee.edad,
                perfil = employee.perfil
            };

            var contenido = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");
            string url = "https://crudcrud.com/api/bcd2318cbafb413db148ac63c28b51da/qbo/" + employee._id ;

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.PutAsync(url, contenido))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    EmployeeBO employeeResponse = JsonConvert.DeserializeObject<EmployeeBO>(apiResponse);
                    return employeeResponse;
                }
            }

        }
        /// <summary>
        /// Eliminar empleados
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public static async Task<string> Eliminar(string ID)
        {            
            string url = "https://crudcrud.com/api/bcd2318cbafb413db148ac63c28b51da/qbo/" + ID;
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.DeleteAsync(url))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();                                        
                    return apiResponse;
                }
            }

        }






    }
}
