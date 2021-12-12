namespace Microservice.Service.Application.Common
{
    public class Result<T>
    {
        public Result(T data, bool succeeded, List<string> errors) 
            => (Data, Succeeded, Errors) = (data, succeeded, errors);

        public T Data { get; }

        public bool Succeeded { get; } = false;

        public IReadOnlyList<string> Errors { get; } = new List<string>();
    }
}