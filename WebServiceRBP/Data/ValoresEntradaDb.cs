using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebServiceRBP.Data.Configuration;
using WebServiceRBP.Entities;

namespace WebServiceRBP.Data
{
    public class ValoresEntradaDb
    {
        private readonly IMongoCollection<ValoresEntrada> _ValuesCollection;

        public ValoresEntradaDb(IRaspberryPiDatabaseSettings settings)
        {
            // var mdbClient = new MongoClient(settings.ConnectionString);
            var mdbRaspberryPi = new MongoClient(settings.ConnectionString);

            var database = mdbRaspberryPi.GetDatabase(settings.DatabaseName);

            _ValuesCollection = database.GetCollection<ValoresEntrada>(settings.RaspberryPiCollectionName);
        }

        public List<ValoresEntrada> Get()
        {
            return _ValuesCollection.Find(cli => true).ToList();
        }

       

        public ValoresEntrada GetById(string id)
        {
            return _ValuesCollection.Find<ValoresEntrada>(ValoresEntrada => ValoresEntrada.Id == id).FirstOrDefault();
        }

        public ValoresEntrada Create(ValoresEntrada cli)
        {
            _ValuesCollection.InsertOne(cli);
            return cli;
        }

        public void Update(string id, ValoresEntrada cli)
        {
            _ValuesCollection.ReplaceOne(ValoresEntrada => ValoresEntrada.Id == id, cli);
        }

        public void Delete(ValoresEntrada cli)
        {
            _ValuesCollection.DeleteOne(ValoresEntrada => ValoresEntrada.Id == cli.Id);
        }

        public void DeleteById(string id)
        {
            _ValuesCollection.DeleteOne(ValoresEntrada => ValoresEntrada.Id == id);
        }
    }
}
