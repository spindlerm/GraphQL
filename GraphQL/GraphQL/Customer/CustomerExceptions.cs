using System;
using HotChocolate;


namespace GraphQL.GraphQL
{
    public class CustomerNotFoundException : Exception
    {
        public int CustomerId { get; internal set; }
    }

    public class CustomerNotFoundExceptionFilter : IErrorFilter
    {
        public IError OnError(IError error)
        {
            if (error.Exception is CustomerNotFoundException ex)
                return error.WithMessage($"Customer with id: {ex.CustomerId} not found");
                
            return error;
        }
    }

}
