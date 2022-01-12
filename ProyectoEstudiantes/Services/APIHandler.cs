using Newtonsoft.Json;
using ProyectoEstudiantes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoEstudiantes.Services
{
    public class APIHandler
    {

        public static async Task<ResponseModel> ConsultAPI(RequestModel requestModel)
        {
            var responseModel = new ResponseModel();

            var data = JsonConvert.SerializeObject(requestModel);
            var handler = new WinHttpHandler();
            var client = new HttpClient(handler);
            var request = new HttpRequestMessage(new HttpMethod(requestModel.method),
                "http://localhost:5000" + requestModel.route);

            request.Headers.Add("Accept", "application/json");
            request.Content = new StringContent(data.ToString(), Encoding.UTF8, "application/json");
            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                var stringResponse = await response.Content.ReadAsStringAsync();
                responseModel = JsonConvert.DeserializeObject<ResponseModel>(stringResponse);
            }
            else
            {
                Console.WriteLine(response.StatusCode);
            }
            return await Task.FromResult(responseModel);
        }
    }
}
