using System;
using HotChocolate;


namespace GraphQL.GraphQL
{
    public class OrderNotFoundException : Exception
    {
        public int OrderId { get; internal set; }
    }

    public class OrderNotFoundExceptionFilter : IErrorFilter
    {
        public IError OnError(IError error)
        {
            if (error.Exception is OrderNotFoundException ex)
                return error.WithMessage($"Order with id {ex.OrderId} not found");
                
            return error;
        }
    }

}