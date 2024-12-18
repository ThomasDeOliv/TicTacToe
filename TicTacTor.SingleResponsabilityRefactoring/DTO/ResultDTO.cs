using System;

namespace TicTacTor.SingleResponsabilityRefactoring.DTO
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
        public T? Value
        {
            get
            {
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
