using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.IO;
using System.Threading.Tasks;

namespace PostRequest
{
    class myController
    {
        private static HttpClient _client = new HttpClient();
        public int startPost = 4;
        public int endPost = 13;
        private static string fileName = "result.txt";
        private static string fullName {
            get {
                return Environment.CurrentDirectory + "\\" + fileName;
            }
        }

        static myController()
        {
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            if (File.Exists(fullName))
            {
                File.Delete(fullName);
            }

        }

        public async Task<RequestDTO> GetId(int ID)
        {
            if (ID < startPost | ID > endPost)
            {
                throw new ArgumentException($"Parameter {ID} is out of the allowed range.");
            }
            string strRequest = "https://jsonplaceholder.typicode.com/posts/" + ID.ToString();
            var request = new HttpRequestMessage(HttpMethod.Get,
                strRequest);
            HttpResponseMessage response = _client.SendAsync(request).Result;
            var dataResponse = new RequestDTO();
            if (response.IsSuccessStatusCode)
            {
                var responseStream = response.Content.ReadAsStreamAsync().Result;
                dataResponse = JsonSerializer.DeserializeAsync
                    <RequestDTO>(responseStream, new JsonSerializerOptions { PropertyNameCaseInsensitive = true }).Result;
            }
            await Task.Delay(3000);
            return dataResponse;
        }

        public void writeResponse(RequestDTO req)
        {
            StreamWriter f = new StreamWriter(fullName, true);
            f.WriteLine();
            f.WriteLine(req.id.ToString());
            f.WriteLine(req.userId.ToString());
            f.WriteLine(req.title.ToString());
            f.WriteLine(req.body.ToString());
            f.WriteLine();
            f.Close();
        }
    }
}
