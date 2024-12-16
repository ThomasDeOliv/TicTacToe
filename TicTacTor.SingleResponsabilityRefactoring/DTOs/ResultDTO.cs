namespace TicTacTor.SingleResponsabilityRefactoring.DTOs
{
    internal abstract record ResultDTO
    {
        private readonly bool _success;

        protected ResultDTO(bool success)
        {
            _success = success;
        }

        public bool Success { get => _success; }
    }

    internal record SuccessResult<T> : ResultDTO where T : class
    {
        private readonly T _result;

        public SuccessResult(T result) : base(true)
        {
            _result = result;
        }

        public T Result { get => _result; }
    }

    internal record FailResult : ResultDTO
    {
        private readonly string _errorMessage;

        public FailResult(string errorMessage) : base(false)
        {
            _errorMessage = errorMessage;
        }

        public string ErrorMessage { get => _errorMessage; }
    }
}
