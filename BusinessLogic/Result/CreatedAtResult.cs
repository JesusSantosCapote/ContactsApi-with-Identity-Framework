namespace BusinessLogic.Result
{
    internal class CreatedAtResult<T> : Result<T>
    {
        private readonly T _data;
        public CreatedAtResult(T data) 
        {
            _data = data;
        }
        public override ResultType ResultType => ResultType.CreatedAt;

        public override List<string> Errors => new List<string>();

        public override T Data => _data;
    }
}
