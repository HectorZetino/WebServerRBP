using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebServiceRBP.Data.Configuration;
using WebServiceRBP.Entities;

namespace WebServiceRBP.Data
{
    public class dbValoresEntradaDb
    {
        private readonly IMongoCollection<dbValoresEntrada> _ValuesCollection;

        public dbValoresEntradaDb(IdbDatabaseSettings settings)
        {
            // var mdbClient = new MongoClient(settings.ConnectionString);
            var mdbRaspberryPi = new MongoClient(settings.ConnectionString);

            var database = mdbRaspberryPi.GetDatabase(settings.DatabaseName);

            _ValuesCollection = database.GetCollection<dbValoresEntrada>(settings.dbCollectionName);
        }

        public List<dbValoresEntrada> Get()
        {
            return _ValuesCollection.Find(cli => true).ToList();
        }



        public dbValoresEntrada GetById(string id)
        {
            return _ValuesCollection.Find<dbValoresEntrada>(ValoresEntrada => ValoresEntrada.Id == id).FirstOrDefault();
        }

        public dbValoresEntrada Create(dbValoresEntrada cli)
        {
            _ValuesCollection.InsertOne(cli);
            return cli;
        }

        public void Update(string id, dbValoresEntrada cli)
        {
            _ValuesCollection.ReplaceOne(ValoresEntrada => ValoresEntrada.Id == id, cli);
        }

        public void Delete(dbValoresEntrada cli)
        {
            _ValuesCollection.DeleteOne(ValoresEntrada => ValoresEntrada.Id == cli.Id);
        }

        public void DeleteById(string id)
        {
            _ValuesCollection.DeleteOne(ValoresEntrada => ValoresEntrada.Id == id);
        }
    }

}
