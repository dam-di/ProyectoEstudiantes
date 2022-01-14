using Newtonsoft.Json;
using ProyectoEstudiantes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoEstudiantes.Services
{

    

    public class APIHandler
    {

        static string USER = "profe2";
        static string PASSWORD = "abcd1234z";
        
        public static string ComputeSHA256Hash(string text)
        {
            StringBuilder Sb = new StringBuilder();
            using (var hash = SHA256.Create())
            {
                Encoding enc = Encoding.UTF8;
                byte[] result = hash.ComputeHash(enc.GetBytes(text));

                foreach (byte b in result)
                    Sb.Append(b.ToString("x2"));
            }
            return Sb.ToString();
        }


        public static async Task<ResponseModel> ConsultAPI(RequestModel requestModel)
        {
            var responseModel = new ResponseModel();

            var data = JsonConvert.SerializeObject(requestModel);
            var handler = new WinHttpHandler();
            var client = new HttpClient(handler);
            var request = new HttpRequestMessage(new HttpMethod(requestModel.method),
                "http://localhost:5000" + requestModel.route);


            string token = ComputeSHA256Hash(USER + requestModel.route + ComputeSHA256Hash(PASSWORD) + DateTime.Now.Minute);
            
            var byteArray = new UTF8Encoding().GetBytes(USER + ":" + token);

            client.DefaultRequestHeaders.Authorization =
                new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));




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
