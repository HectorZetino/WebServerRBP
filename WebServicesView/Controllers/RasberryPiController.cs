using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebServicesView.Helper;
using WebServicesView.Models;

namespace WebServicesView.Controllers
{
    public class RasberryPiController : Controller
    {
        public static ValorRecibido _DatoEntrada = new ValorRecibido();
        //get : RaspberryPi
        RsbAPi _api = new RsbAPi();
        [HttpPost("RasberryPi/Resultante")]
        public async Task<ActionResult> Resultante()
        {
            string ValorRetornado = "";
            NumeroIngresado NumIngresado = new NumeroIngresado();
            //ValorRecibido NumRecibido = new ValorRecibido();
            NumIngresado.numero = Request.Form["numero"].ToString();
            HttpClient client = _api.Initial();
            HttpResponseMessage res = await client.GetAsync($"api/RaspberryPi/{NumIngresado.numero}/{_DatoEntrada.valorRBP}/{_DatoEntrada.Binario}");
            if (res.IsSuccessStatusCode)
            {
                var result = res.Content.ReadAsStringAsync().Result;
                ValorRetornado = JsonConvert.DeserializeObject<string>(result);
            }


            return Ok(ValorRetornado);
        }
        /// <summary>
        /// Ya funciona tomando el ultimo valor de la base de datos, y esto se hara cada vez que inicie la aplicacion.
        /// </summary>
        /// <returns></returns>
        public async Task<ActionResult> Datos()
        {   
            ValoresEntrada ValorRetornado = new ValoresEntrada();
            //ValorRecibido _DatoEntrada = new ValorRecibido();
            

            HttpClient client = _api.Initial();
            HttpResponseMessage res = await client.GetAsync($"api/RaspberryPi/Busqueda");
            if (res.IsSuccessStatusCode)
            {
                var result = res.Content.ReadAsStringAsync().Result;
                ValorRetornado = JsonConvert.DeserializeObject<ValoresEntrada>(result);
            }
            _DatoEntrada.valorRBP = ValorRetornado.DatoEnviado;
            _DatoEntrada.Binario = ValorRetornado.operacion;
            return View(_DatoEntrada);
        }
    }
}
