using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AF.Common.Requests
{
    [DataContract]
    public class UpdateRequest<TData> : RequestBase
    {
        [DataMember]
        public TData Data { get; set; }
    }
}
