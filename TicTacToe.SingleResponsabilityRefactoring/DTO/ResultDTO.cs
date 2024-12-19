namespace TicTacToe.SingleResponsabilityRefactoring.DTO
{
    public class ResultDTO<T> where T : class?
    {
        public bool Success { get; }
        public string? Reason { get; }
        public T? Value { get; }

        protected ResultDTO(T result)
        {
            this.Success = true;
            this.Reason = null;
            this.Value = result;
        }

        protected ResultDTO(string reason)
        {
            this.Success = false;
            this.Reason = reason;
            this.Value = null;
        }

        public static ResultDTO<T> CreateSuccessdResult(T result)
        {
            return new ResultDTO<T>(result);
        }

        public static ResultDTO<T> CreateFailedResult(string reason)
        {
            return new ResultDTO<T>(reason);
        }
    }
}
