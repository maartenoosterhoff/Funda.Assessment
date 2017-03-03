using System.Linq;

using Funda.Assessment.Entities;
using Funda.Assessment.Interfaces;

namespace Funda.Assessment.Implementations
{
    public sealed class FundaDataAggregator : DataAggregator<FundaDataResult>
    {

        public FundaDataAggregator(IDataRetriever retriever) : base(retriever) { }

        protected override int GetPageCount(FundaDataResult dataItem)
        {
            return dataItem?.Paging?.AantalPaginas ?? 0;
        }

        protected override void MergeResults(FundaDataResult aggregated, FundaDataResult dataItem)
        {
            // Add new objects to aggregated result.
            var aggregatedObjectIds = aggregated.Objects.Select(z => z.Id).ToArray();
            var objectsToAdd = dataItem.Objects
                .Where(x => !aggregatedObjectIds.Contains(x.Id))
                .ToArray();
            aggregated.Objects.AddRange(objectsToAdd);
        }
    }
}
