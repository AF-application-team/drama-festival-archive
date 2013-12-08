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

        public ListResponse(IList<TData> data)
        {
            Data = data;
        }
    }

    public static class ListResponse
    {
        public static ListResponse<TData> Create<TData>(RequestBase request, IList<TData> data)
        {
            return new ListResponse<TData>(data);
        }

        public static ListResponse<TData> Create<TData>(RequestBase request, IEnumerable<TData> data)
        {
            return new ListResponse<TData>(new List<TData>(data));
        }
    }
}