namespace BusinessLogic.Result
{
    public class NoContentResult<T> : Result<T>
    {
        public override ResultType ResultType => ResultType.NoContent;

        public override List<string> Errors => new List<string>();

        public override T Data => default(T);
    }
}
