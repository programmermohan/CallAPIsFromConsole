using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace CallAPIs.Classes
{
    public class CallAPIs
    {
        public static string baseUrl = "http://localhost:8783/";

        public static string BearerToken { get; set; }

        //---------------------------------------------------------------------------------------------------------------------------------------------//

        public void RegisterUser()
        {
            try
            {
                RegisterModel model = new RegisterModel() { UserName = "MohanChands", Email = "developer.mohan89@gmail.com", Password = "Mohan@1234" };

                using (HttpClient webRequest = new HttpClient())
                {
                    string url = baseUrl + "api/Authentication/Register";

                    string JsonString = JsonConvert.SerializeObject(model);
                    ASCIIEncoding encoding = new ASCIIEncoding();
                    byte[] data = encoding.GetBytes(JsonString);

                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);

                    request.Method = "Post";
                    request.ContentLength = data.Length;
                    request.ContentType = "application/json";

                    using (Stream stream = request.GetRequestStream())
                    {
                        stream.Write(data, 0, data.Length);
                    }

                    HttpWebResponse response = (HttpWebResponse)request.GetResponse();

                    if (response != null)
                    {
                        using (var streamReader = new StreamReader(response.GetResponseStream()))
                        {
                            var result = streamReader.ReadToEnd();
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        //---------------------------------------------------------------------------------------------------------------------------------------------//

        public void RegisterAdminUser()
        {
            try
            {
                RegisterModel model = new RegisterModel() { UserName = "Manoj11", Email = "developer.manoj88@gmail.com", Password = "Mohan@1234" };

                using (HttpClient webRequest = new HttpClient())
                {
                    string url = baseUrl + "api/Authentication/RegisterAdmin";

                    string JsonString = JsonConvert.SerializeObject(model);
                    ASCIIEncoding encoding = new ASCIIEncoding();
                    byte[] data = encoding.GetBytes(JsonString);

                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);

                    request.Method = "Post";
                    request.ContentLength = data.Length;
                    request.ContentType = "application/json";

                    using (Stream stream = request.GetRequestStream())
                    {
                        stream.Write(data, 0, data.Length);
                    }

                    HttpWebResponse response = (HttpWebResponse)request.GetResponse();

                    if (response != null)
                    {
                        using (var streamReader = new StreamReader(response.GetResponseStream()))
                        {
                            var result = streamReader.ReadToEnd();
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        //---------------------------------------------------------------------------------------------------------------------------------------------//
        public async Task GetEmployeesByToken()
        {
            try
            {
                using HttpClient client = new HttpClient { BaseAddress = new Uri(baseUrl) };
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json");
                string uri = "api/Employees/GetEmployees";

                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", BearerToken);

                var response = await client.GetAsync(uri);

                if (response.IsSuccessStatusCode)
                {
                    var stringData = await response.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject<List<string>>(stringData);

                }
            }
            catch (Exception ex)
            {

                throw;
            }

        }

        //---------------------------------------------------------------------------------------------------------------------------------------------//
        public void LoginToGetBearerToken()
        {
            try
            {
                LoginModel model = new LoginModel() { UserName = "MohanChandra", Password = "Mohan@1234" };

                TokenManager manager = new TokenManager();
                using (HttpClient webRequest = new HttpClient())
                {
                    string url = baseUrl + "api/Authentication/Login";

                    string JsonString = JsonConvert.SerializeObject(model);
                    ASCIIEncoding encoding = new ASCIIEncoding();
                    byte[] data = encoding.GetBytes(JsonString);

                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);

                    request.Method = "Post";
                    request.ContentLength = data.Length;
                    request.ContentType = "application/json";

                    using (Stream stream = request.GetRequestStream())
                    {
                        stream.Write(data, 0, data.Length);
                    }

                    HttpWebResponse response = (HttpWebResponse)request.GetResponse();

                    if (response != null)
                    {
                        using (var streamReader = new StreamReader(response.GetResponseStream()))
                        {
                            var result = streamReader.ReadToEnd();
                            manager = JsonConvert.DeserializeObject<TokenManager>(result);

                            BearerToken = manager.Token;

                            //GetEmployeesByToken(BearerToken);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //---------------------------------------------------------------------------------------------------------------------------------------------//

    }
}
