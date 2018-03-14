namespace TranscribeMe.API.Data.Queries
{
    public interface IEntityListingQuery<TResult> : IFilterQuery<TResult>
    {
        int? From { get; set; }

        int? To { get; set; }

        long? Start { get; set; }

        long? End { get; set; }
    }
}