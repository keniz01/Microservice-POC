namespace Microservice.Service.Application.Common
{
    public class Result
    {
        protected Result(List<string> errors) => Errors = errors ?? new List<string>();

        public static Result Fail(List<string> errors)
        {
            errors = errors ?? new List<string>();
            if(errors.Count == 0)
            {
                throw new ErrorListNullOrEmptyException(nameof(errors));
            }
            
            return new Result(errors);
        }

        public virtual bool Succeeded { get => false; }

        public IReadOnlyList<string> Errors { get; }

        public class ErrorListNullOrEmptyException : Exception
        {
            public ErrorListNullOrEmptyException(string message) : base(message)
            {
                
            }
        }
    }

    public class Result<T> : Result
    {
        private Result(T data) : base(new List<string> { }) => Data = data;

        public static Result<T> Ok(T data)
        {
            if(ReferenceEquals(null, data))
            {
                throw new DataNullException(nameof(data));
            }

            return new Result<T>(data);
        }

        public T Data { get; }

        public override bool Succeeded { get => true; }


        public class DataNullException : Exception
        {
            public DataNullException(string message) : base(message)
            {
                
            }
        }        
    }
}