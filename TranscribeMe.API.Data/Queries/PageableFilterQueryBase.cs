namespace TranscribeMe.API.Data.Queries
{
    public abstract class PageableFilterQueryBase<TResult> : IEntityListingQuery<TResult>
    {
        public int? From { get; set; }

        public int? To { get; set; }

        public long? Start { get; set; }

        public long? End { get; set; }
    }
}