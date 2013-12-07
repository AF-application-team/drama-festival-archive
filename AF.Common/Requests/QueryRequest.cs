using System.Runtime.Serialization;

namespace AF.Common.Requests
{
    [DataContract]
    public class QueryRequest<TQuery> : RequestBase
        where TQuery : QueryBase
    {
        public QueryRequest()
        {}

        public QueryRequest(TQuery query)
        {
            Query = query;
        }

        [DataMember]
        public TQuery Query { get; set; }
    }

    public static class QueryRequest
    {
        public static QueryRequest<T> New<T>(T query)
            where T : QueryBase
        {
            return new QueryRequest<T>(query);
        }
    }
}