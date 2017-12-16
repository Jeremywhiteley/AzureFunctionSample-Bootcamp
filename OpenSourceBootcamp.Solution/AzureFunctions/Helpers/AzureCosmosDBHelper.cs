using Microsoft.Azure.Documents.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureFunctions.Helpers
{
    public class AzureCosmosDBHelper : IDisposable
    {
        private const string _dbName = "DataBaseName";
        private const string _endpoint = "DataBaseEndPoint";
        private const string _authKey = "DataBaseKey";

        public Task Save<T>(T item) where T : class
        {
            using (var _client = new DocumentClient(new Uri(_endpoint), _authKey))
            {
                var result = _client.UpsertDocumentAsync(UriFactory.CreateDocumentCollectionUri(_dbName, (typeof(T).Name)), item, new RequestOptions() { }, true);
            }

            return null;
        }

        public T Get<T>(string key) where T : class
        {
            using (var _client = new DocumentClient(new Uri(_endpoint), _authKey))
            {
                return _client.ReadDocumentAsync<T>(
                    UriFactory.CreateDocumentUri(_dbName, (typeof(T).Name), key)).GetAwaiter().GetResult();
            }
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

    }
}
