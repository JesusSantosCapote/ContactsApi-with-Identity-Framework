namespace BusinessLogic.Result
{
    public class UnexpectedResult<T> : Result<T>
    {
        private readonly string _error;
        public UnexpectedResult(string error = "") 
        {
            _error = error;
        }
        public override ResultType ResultType => ResultType.Unexpected;
        public override List<string> Errors => new List<string> { "There was an unexpected problem: " + $"{_error}" };
        public override T Data => default(T);
    }
}
