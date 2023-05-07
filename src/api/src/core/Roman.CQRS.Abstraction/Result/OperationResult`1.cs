using System;
using System.Collections.Generic;
using System.Linq;

namespace Roman.CQRS.Abstraction.Result
{
    public class OperationResult<TOut>
    {
        public Type? OperationType { get; set; }

        public Exception? Exception { get; protected set; }

        public TOut? Result { get; protected set; }

        public IEnumerable<KeyValuePair<string, string>> ValidationErrors { get; protected set; }

        public OperationResult()
        {
            ValidationErrors = new List<KeyValuePair<string, string>>();
        }

        public OperationResult(TOut result) : this()
        {
            Result = result;
        }

        //public OperationResult<TOut> OnSuccess(Action<TOut> action)
        //{
        //    if (this is ISuccessResult<TOut>)
        //        action?.Invoke(Result);

        //    return this;
        //}

        //public OperationResult<TOut> OnBusinessError(Action<IEnumerable<KeyValuePair<string, string>>> action)
        //{
        //    if (this is IBusinessErrorResult)
        //        action?.Invoke(ValidationErrors);
        //    return this;
        //}

        //public OperationResult<TOut> OnServerError(Action<Exception> action)
        //{
        //    if (this is IServerErrorResult)
        //        action?.Invoke(Exception);
        //    return this;
        //}
    }
}