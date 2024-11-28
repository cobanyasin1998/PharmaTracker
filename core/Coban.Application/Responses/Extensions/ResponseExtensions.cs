//using Coban.Application.Responses.Base.Concretes;
//using Coban.Application.Responses.GetAll;

//public static class ResponseExtensions
//{
//    public static Response<TResponse, TError> CreatePagingSuccess<TResponse, TError>(
//        this Response<TResponse, TError> response,
//        TResponse data,
//        int totalCount,
//        int pageSize,
//        int page)
//        where TResponse : GetAllResponse<object>
//        where TError : class
//    {
//        int totalPage = (int)Math.Ceiling((double)totalCount / pageSize);
//        var next = page < totalPage;
//        var previous = page > 1;
//        var next3Page = page + 3 < totalPage;
//        var previous3Page = page - 3 > 1;

//        if (data is GetAllResponse<object> responseData)
//        {
//            responseData.TotalCount = totalCount;
//            responseData.TotalPage = totalPage;
//            responseData.Next = next;
//            responseData.Previous = previous;
//            responseData.Next3Page = next3Page;
//            responseData.Previous3Page = previous3Page;
//        }

//        return Response<TResponse, TError>.CreateSuccess(data);
//    }
//}
