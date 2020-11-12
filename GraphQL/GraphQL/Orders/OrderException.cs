using System;
using HotChocolate;


namespace GraphQL.GraphQL
{
    public class OrderNotFoundException : Exception
    {
        public OrderNotFoundException()
        {

        }
        public OrderNotFoundException(string message)
        : base(message) 
        
        {
        }

        public OrderNotFoundException(string message, Exception inner)
            : base(message, inner) 
        {
            
        }
        public int OrderId { get; internal set; }
    }

    public class CreateOrderException : Exception
    {
        public CreateOrderException()
        {
            
        }

        public CreateOrderException(string message)
        : base(message) 
        
        {
        }

        public CreateOrderException(string message, Exception inner)
            : base(message, inner) 
        {
            
        }
        public int CustomerId { get; internal set; }
    }


    public class UpdateOrderException : Exception
    {
        public UpdateOrderException()
        {
            
        }

        public UpdateOrderException(string message)
        : base(message) 
        
        {
        }

        public UpdateOrderException(string message, Exception inner)
            : base(message, inner) 
        {
            
        }

         public int OrderId { get; internal set; }
    }


    public class CreateOrderExceptionFilter : IErrorFilter
    {
        public IError OnError(IError error)
        {
            if (error.Exception is CreateOrderException ex)
                return error.WithMessage($"Failed to create Order, order with customer id: {ex.CustomerId} not found");
                
            return error;
        }
    }

    public class OrderNotFoundExceptionFilter : IErrorFilter
    {
        public IError OnError(IError error)
        {
            if (error.Exception is OrderNotFoundException ex)
                return error.WithMessage($"Order with id: {ex.OrderId} not found");
                
            return error;
        }
    }

}