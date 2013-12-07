using System;
using System.Runtime.Serialization;

namespace WinLabs.Common.Requests
{
    [DataContract]
    public class SingleItemResponse<TData> : ResponseBase
    {
        [DataMember]
        public TData Data { get; set; }

        public SingleItemResponse(Guid requestId, TData data) : base(requestId)
        {
            Data = data;
        }
    }

    public static class SingleItemResponse
    {
        public static SingleItemResponse<TData> Create<TData>(RequestBase request, TData data)
        {
            return new SingleItemResponse<TData>(request.Id, data);
        }
    }
}