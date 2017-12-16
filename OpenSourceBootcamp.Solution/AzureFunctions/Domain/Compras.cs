using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace AzureFunctions.Domain
{
    [Serializable]
    public class Compras
    {
        [JsonProperty(PropertyName = "id")]
        public Guid Id { get; set; } = Guid.NewGuid();
        public decimal? Valor { get; set; }
        public string Cliente { get; set; } 

    }
}
