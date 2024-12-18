using System;

namespace TicTacTor.SingleResponsabilityRefactoring.DTOs
{
    internal record ResultDTO<T> where T : class?
    {
        private readonly bool _success;
        private readonly T? _result;
        private readonly string? _reason;

        private ResultDTO(T result)
        {
            this._success = true;
            this._result = result;
            this._reason = null;
        }

        private ResultDTO(string reason)
        {
            this._success = false;
            this._result = null;
            this._reason = reason;
        }

        public bool Success { get => this._success; }
        public string? Reason { get => this._reason; }
        public bool HasValue { get => this._reason is not null; }
        public T? Value
        {
            get
            {
                if (!this.HasValue)
                    throw new InvalidOperationException("Cannot access Value because operation failed.");
                return this._result;
            }
        }

        public static ResultDTO<T> SuccessdResult(T result)
        {
            return new ResultDTO<T>(result);
        }

        public static ResultDTO<T> FailedResult(string reason)
        {
            return new ResultDTO<T>(reason);
        }
    }
}
