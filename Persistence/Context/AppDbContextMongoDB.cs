using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace CleanArchtecture.Persistence.Context
{
    public class AppDbContextMongoDB
    {

        private readonly IMongoDatabase _database;

        public AppDbContextMongoDB(IMongoDatabase database)
        {
            _database = database;
        }

        public IMongoCollection<T> MongoCollection<T>(string name)
        {
            return _database.GetCollection<T>(name);
        }
    }        
}
