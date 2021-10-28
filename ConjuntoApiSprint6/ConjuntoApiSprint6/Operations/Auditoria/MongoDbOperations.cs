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
		public static void InsertNewDataInMongoDb(string StringConnection, string DatabaseName, string CollectionName, T Error)
		{
			var Server = AbrirConexaoComMongoDB(StringConnection);
			var Database = AbrirConexaoComDatabaseMongoDB(Server, DatabaseName);
			var Collection = AbrirConexaoComColecaoMongoDB(Database, CollectionName);
			Collection.InsertOne(Error);
		}
		private static IMongoClient AbrirConexaoComMongoDB(string StringConnection)
		{
			return new MongoClient(StringConnection);
		}
		private static IMongoDatabase AbrirConexaoComDatabaseMongoDB(IMongoClient Servidor, string NomeDatabase)
		{
			return Servidor.GetDatabase(NomeDatabase);
		}

		private static IMongoCollection<T> AbrirConexaoComColecaoMongoDB(IMongoDatabase BancoPedidos, string NomeColecao)
		{
			return BancoPedidos.GetCollection<T>(NomeColecao);
		}
	}
}
