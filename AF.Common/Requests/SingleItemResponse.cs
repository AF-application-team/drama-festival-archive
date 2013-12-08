using System;
using System.Runtime.Serialization;

namespace AF.Common.Requests
{
    [DataContract]
    public class SingleItemResponse<TData> : ResponseBase
    {
        [DataMember]
        public TData Data { get; set; }

        public SingleItemResponse(TData data)
        {
            Data = data;
        }
    }

    public static class SingleItemResponse
    {
        public static SingleItemResponse<TData> Create<TData>(RequestBase request, TData data)
        {
            return new SingleItemResponse<TData>(data);
        }
    }
}