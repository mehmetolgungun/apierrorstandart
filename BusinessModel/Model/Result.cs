using System;

namespace Business.Model
{
    public abstract class Result
    {
        public Problem ErrorResult { get; private set; }

        public bool Status => ErrorResult == null;

        protected Result()
        {
            ErrorResult = null;
        }

        protected Result(Problem errorResult)
        {
            ErrorResult = errorResult;
        }

        private class Success : Result { }

        private class Error : Result
        {
            public Error(Problem errorResult) : base(errorResult)
            {
            }
        }

        public static Result WithoutError => new Success();

        public static implicit operator Result(Problem errorResult) => new Error(errorResult);
    }

    public class Result<T> : Result
    {
        public T Value { get; private set; }

        private Result(T value)
        {
            Value = value;
        }

        private Result(Problem errorResult) : base(errorResult)
        {
        }

        public static implicit operator Result<T>(T value) => new Result<T>(value);

        public static implicit operator Result<T>(Problem errorResult) => new Result<T>(errorResult);
    }
}
