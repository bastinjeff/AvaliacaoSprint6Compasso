using ConjuntoApiSprint6.Models.Auditoria;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConjuntoApiSprint6.Operations.Auditoria
{
	public static class MongoDbOperations<T>
	{
		public static void InsertNewDataInMongoDb(string StringConnection, string DatabaseName, string CollectionName, T Data)
		{
			var Server = OpenConnectionMongoDB(StringConnection);
			var Database = OpenConnectionDatabaseMongoDB(Server, DatabaseName);
			var Collection = OpenConnectionCollectionMongoDB(Database, CollectionName);
			Collection.InsertOne(Data);
		}
		private static IMongoClient OpenConnectionMongoDB(string StringConnection)
		{
			return new MongoClient(StringConnection);
		}
		private static IMongoDatabase OpenConnectionDatabaseMongoDB(IMongoClient Servidor, string NomeDatabase)
		{
			return Servidor.GetDatabase(NomeDatabase);
		}

		private static IMongoCollection<T> OpenConnectionCollectionMongoDB(IMongoDatabase BancoPedidos, string NomeColecao)
		{
			return BancoPedidos.GetCollection<T>(NomeColecao);
		}
	}
}
