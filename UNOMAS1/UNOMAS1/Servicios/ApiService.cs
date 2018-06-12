using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net.Http;
using UNOMAS1.Modelos;
using ModernHttpClient;

namespace UNOMAS1.Servicios
{
   public  class ApiService
    {
        static HttpClient Client = new HttpClient(new NativeMessageHandler());

        public async Task<SolicitudLogin> Login(SolicitudLogin Datos)
        {
            try
            {
                string url = "https://www.creativasoftlineapps.com/ScriptAppUnoMasCliente/frmLoginAppBitacora.aspx";
                string content = JsonConvert.SerializeObject(Datos);
                StringContent body = new StringContent(content, Encoding.UTF8, "application/json");
                var response = await Client.PostAsync(url, body);
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    if (json.Substring(0, 5) != "Error")
                    {
                        var resultado = (SolicitudLogin)JsonConvert.DeserializeObject(json, typeof(SolicitudLogin));
                        return resultado;
                    }
                }
                return null;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<ListaEntrenador> getEntrenadores()
        {
            try
            {
                string url = "https://www.creativasoftlineapps.com/ScriptAppUnoMasCliente/frmGetComboEntrenador.aspx";
                string content = JsonConvert.SerializeObject("");
                StringContent body = new StringContent(content, Encoding.UTF8, "application/json");
                var response = await Client.PostAsync(url, body);
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    if (json.Substring(0, 5) != "Error")
                    {
                        var resultado = (ListaEntrenador)JsonConvert.DeserializeObject(json, typeof(ListaEntrenador));
                        return resultado;
                    }
                }
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<ClaseVM> GetClasesProgreso(SolicitudClase datos)
        {
            try
            {
                string url = "https://www.creativasoftlineapps.com/ScriptAppUnoMasCliente/frmGetClases.aspx";
                string content = JsonConvert.SerializeObject(datos);
                StringContent body = new StringContent(content, Encoding.UTF8, "application/json");
                var response = await Client.PostAsync(url, body);
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    if (json.Substring(0, 5) != "Error")
                    {
                        var resultado = (ClaseVM)JsonConvert.DeserializeObject(json, typeof(ClaseVM));
                        return resultado;
                    }
                }
                return null;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<SolicitudEntrenador> AbcEntrenador(SolicitudEntrenador Datos)
        {
            try
            {
                string url = "https://www.creativasoftlineapps.com/ScriptAppUnoMasCliente/frmAbcEntrenador.aspx";
                string content = JsonConvert.SerializeObject(Datos);
                StringContent body = new StringContent(content, Encoding.UTF8, "application/json");
                var response = await Client.PostAsync(url, body);
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    if (json.Substring(0, 5) != "Error")
                    {
                        var resultado = (SolicitudEntrenador)JsonConvert.DeserializeObject(json, typeof(SolicitudEntrenador));
                        return resultado;
                    }
                }
                return null;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<ListaPreguntas> GetPreguntas(SolicitudPregunta datos)
        {
            try
            {
                string url = "https://www.creativasoftlineapps.com/ScriptAppUnoMasCliente/frmGetPreguntas.aspx";
                string content = JsonConvert.SerializeObject(datos);
                StringContent body = new StringContent(content, Encoding.UTF8, "application/json");
                var response = await Client.PostAsync(url, body);
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    if (json.Substring(0, 5) != "Error")
                    {
                        var resultado = (ListaPreguntas)JsonConvert.DeserializeObject(json, typeof(ListaPreguntas));
                        return resultado;
                    }
                }
                return null;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<EntrenamientoVM> GetWodPreview(SolicitudEntrenamiento datos)
        {
            try
            {
                string url = "https://www.creativasoftlineapps.com/ScriptAppUnoMasCliente/frmGetWodPreview.aspx";
                string content = JsonConvert.SerializeObject(datos);
                StringContent body = new StringContent(content, Encoding.UTF8, "application/json");
                var response = await Client.PostAsync(url, body);
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    if (json.Substring(0, 5) != "Error")
                    {
                        var resultado = (EntrenamientoVM)JsonConvert.DeserializeObject(json, typeof(EntrenamientoVM));
                        return resultado;
                    }
                }
                return null;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
