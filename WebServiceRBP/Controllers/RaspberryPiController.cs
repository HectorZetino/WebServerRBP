using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebServiceRBP.Data;
using WebServiceRBP.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebServiceRBP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RaspberryPiController : ControllerBase
    {
        
        private readonly ValoresEntradaDb _veDb;
        private readonly dbValoresEntradaDb _ve2Db;
        static string operacion;
        static int valorEntrada;
        static int Restador;
        static int Resultante;
        public RaspberryPiController(ValoresEntradaDb valorDb, dbValoresEntradaDb valor2Db) {
            _veDb = valorDb;
            _ve2Db = valor2Db;
        }

        // GET: api/<RaspberryPiController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_veDb.Get());
        }

        //Cuando se Manda un pulso
        [HttpGet("{puerto}/on")]
        public IActionResult CreateOn(string puerto) {
            ValoresEntrada valor = new ValoresEntrada();
            //valor.Puerto = puerto;
            //valor.Estado = "Encendido";
            //valor.FechaHora = DateTime.Now.ToString();
            _veDb.Create(valor);
            return Ok();
        }

        [HttpGet("{puerto}/off")]
        public IActionResult CreateOff(string puerto)
        {
            ValoresEntrada valor = new ValoresEntrada();
            //valor.Puerto = puerto;
            //valor.Estado = "Apagado";
            //valor.FechaHora = DateTime.Now.ToString();
            _veDb.Create(valor);
            return Ok();
        }


        [HttpGet("{Entrada}/{Binario}/{operacion}")]
        public IActionResult CreateMetode(string Entrada,string Binario, string operacion)
        {

            dbValoresEntrada valor  = new dbValoresEntrada();
            
            valor.NoRestado = Restador.ToString();
            _ve2Db.Create(valor);
            
            if (operacion == "0001")//Suma
            {
                valorEntrada = Convert.ToInt32(Binario, 2);
                Restador = Convert.ToInt32(Entrada);
                Resultante = valorEntrada + Restador;
                valor.NoRestado = Resultante.ToString();
                _ve2Db.Create(valor);
                return Ok(Resultante);
            }
            else if (operacion == "0010")//Resta
            {
                valorEntrada = Convert.ToInt32(Binario, 2);
                Restador = Convert.ToInt32(Entrada);
                Resultante = valorEntrada - Restador;

                valor.NoRestado = Resultante.ToString();
                _ve2Db.Create(valor);
                return Ok(Resultante);

            }
            else if (operacion == "0100")//Multiplicacion
            {
                valorEntrada = Convert.ToInt32(Binario, 2);
                Restador = Convert.ToInt32(Entrada);
                Resultante = valorEntrada * Restador;

                valor.NoRestado = Resultante.ToString();
                _ve2Db.Create(valor);
                return Ok(Resultante);
            }
            else if (operacion == "1000")//Division
            {
                valorEntrada = Convert.ToInt32(Binario, 2);
                Restador = Convert.ToInt32(Entrada);
                Resultante = valorEntrada / Restador;

                valor.NoRestado = Resultante.ToString();
                _ve2Db.Create(valor);
                return Ok(Resultante);
            }
            
            return Ok(Resultante);
        }
        /// <summary>
        /// Metodo que ira a buscar los valores ingresados a la vbase desde la raspberry pi (base de datos en comun)
        /// </summary>
        /// <returns></returns>
        [HttpGet("Busqueda")]
        public IActionResult BusquedaBD() {
            List<ValoresEntrada> _ListaValores = new List<ValoresEntrada>();
            _ListaValores = _veDb.Get();
            _veDb.Delete(_ListaValores[0]);//asi siempre se maneja el primero como el ultimo valor a obtener
            return Ok(_ListaValores[0]);
        }



    }
}
