using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace AF.Common.Requests
{
    [DataContract]
    public class ListResponse<TData> : ResponseBase
    {
        [DataMember]
        public IList<TData> Data { get; set; }

        public ListResponse(Guid requestGuid, IList<TData> data) : base(requestGuid)
        {
            Data = data;
        }
    }

    public static class ListResponse
    {
        public static ListResponse<TData> Create<TData>(RequestBase request, IList<TData> data)
        {
            return new ListResponse<TData>(request.Id, data);
        }

        public static ListResponse<TData> Create<TData>(RequestBase request, IEnumerable<TData> data)
        {
            return new ListResponse<TData>(request.Id, new List<TData>(data));
        }
    }
}