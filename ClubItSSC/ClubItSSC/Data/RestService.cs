using ClubItConsole.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ClubItSSC.Data
{
    public class RestService
    {
        HttpClient client;
        string grant_type = "password";

        public RestService()
        {
            client = new HttpClient();
            client.MaxResponseContentBufferSize = 256000;
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/x-www-form-urlencoded"));
        }

        public async Task<Token> Login(User user)
        {
            var postData = new List<KeyValuePair<string, string>>();
            postData.Add(new KeyValuePair<string, string>("grant_type", grant_type));
            postData.Add(new KeyValuePair<string, string>("username", user.Username));
            postData.Add(new KeyValuePair<string, string>("password", user.Password));
            var content = new FormUrlEncodedContent(postData);
            var webUrl = "www.test.com";
            var response = await PostResponseLogin<Token>(Constants.LoginURL, content);
            DateTime date = new DateTime();
            date = DateTime.Today;
            response.expire_date = date.AddSeconds(response.expire_In);
            return response;

        }

        public async Task<Token> PostResponseLogin<Token>(string webUrl, FormUrlEncodedContent content)
        {

            var response = await client.PostAsync(webUrl, content);
            var jsonResult = response.Content.ReadAsStringAsync().Result;
            var token = JsonConvert.DeserializeObject<Token>(jsonResult);
            return token;
        }

        public async Task<Token> PostResponse<Token>(string webUrl, string jsonString) where Token : class
        {
            var TokenObject = App.TokenDatabase.GetToken();
            string contentType = "application/json";
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("ClubIt", TokenObject.access_token);
            try
            {
                var Result = await client.PostAsync(webUrl, new StringContent(jsonString, Encoding.UTF8, contentType));
                if (Result.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var jsonResult = Result.Content.ReadAsStringAsync().Result;
                    try
                    {
                        var ContentResponse = JsonConvert.DeserializeObject<Token>(jsonResult);
                        return ContentResponse;
                    }
                    catch { return null; }
                }
            }
            catch { return null; }
            return null;
        }

        public async Task<Token> GetResponse<Token>(string webUrl) where Token : class
        {
            var TokenObject = App.TokenDatabase.GetToken();
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("ClubIt", TokenObject.access_token);
            try
            {
                var response = await client.GetAsync(webUrl);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var jsonResult = response.Content.ReadAsStringAsync().Result;
                    try
                    {
                        var contentResponse = JsonConvert.DeserializeObject<Token>(jsonResult);
                        return contentResponse;
                    }
                    catch
                    {
                        return null;
                    }
                }
            }
            catch
            {
                return null;
            }
            return null;
        }
    }
}
