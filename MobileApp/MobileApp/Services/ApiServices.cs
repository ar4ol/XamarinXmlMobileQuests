using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MobileApp.Models;
using MobileApp.Models.DataModels;
using MobileApp.Models.UserModels;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace MobileApp.Services
{
    public class ApiServices
    {
        public async Task<bool> RegisterVisitorAsync(RegisterVisitor rem)
        {
            ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;
            HttpClient client = new HttpClient();
            var jsonModel = JsonConvert.SerializeObject(rem);
            HttpContent content = new StringContent(jsonModel);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var address = $@"https://webapplication6-up3.conveyor.cloud/api/visitor/create";
            var response = await client.PostAsync(address, content);
            if (response.IsSuccessStatusCode)
            {
                var res = await response.Content.ReadAsStringAsync();
                var baseApl = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<RegisterVisitor, Visitor>();
                }).CreateMapper().Map<Visitor>(rem);
                Data.Visitor = baseApl;
                return true;
            }
            return false;                 
        }

        public async Task<bool> LoginVisitorAsync(LoginViewModel rem)
        { 
            ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;
            HttpClient client = new HttpClient();
            var jsonModel = JsonConvert.SerializeObject(rem);
            HttpContent content = new StringContent(jsonModel);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var address = $@"https://webapplication6-up3.conveyor.cloud/api/visitor/authorization";
            var response = await client.PostAsync(address, content);
            if (response.IsSuccessStatusCode)
            {
                var res = await response.Content.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject<VisitorDataModel>(res);
                Data.VisitorDataModel = data;
                return true;
            }
            return false;
        }

        public async Task<bool> GetRoute(int questid)
        {
            ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;
            HttpClient client = new HttpClient();
            var jsonModel = JsonConvert.SerializeObject(questid);
            HttpContent content = new StringContent(jsonModel);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var address = $@"https://webapplication6-up3.conveyor.cloud/api/visitor/getroute";
            var response = await client.PostAsync(address, content);
            if (response.IsSuccessStatusCode)
            {
                var data_json = await response.Content.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject<string>(data_json);
                Data.Route = data;
                return true;
            }           

            Data.Route = "Quest is empty.";
            return false;            
        }

        public async Task<bool> GetZones(int questid)
        {
            ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;
            HttpClient client = new HttpClient();
            Quest quest = new Quest();
            quest.Id = questid;
            var jsonModel = JsonConvert.SerializeObject(quest);
            HttpContent content = new StringContent(jsonModel);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var address = $@"https://webapplication6-up3.conveyor.cloud/api/zone/getlistzones";
            var response = await client.PostAsync(address, content);
            if (response.IsSuccessStatusCode)
            {
                var data_json = await response.Content.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject<List<Zone>>(data_json);
                Data.Zones = data;
                return true;
            }
            Data.Zones = new List<Zone>();
            return false;
        }
        public async Task<bool> ZoneEnter(int questId)
        {
            VisitorDataModel visitorDataModel = Data.VisitorDataModel;
            ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;
            HttpClient client = new HttpClient();
            var jsonModel = JsonConvert.SerializeObject(visitorDataModel);
            HttpContent content = new StringContent(jsonModel);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var address = $@"https://webapplication6-up3.conveyor.cloud/api/visitor/enterzone/{questId}";
            var response = await client.PostAsync(address, content);
            if (response.IsSuccessStatusCode)
            {
                var data_json = await response.Content.ReadAsStringAsync();
                var visitor = JsonConvert.DeserializeObject<VisitorDataModel>(data_json);

                Data.VisitorDataModel = visitor;
                return true;
            }
            return false;
        }      

    }
}
