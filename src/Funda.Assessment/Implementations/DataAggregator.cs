using System;

using Funda.Assessment.Interfaces;

namespace Funda.Assessment.Implementations
{
    public abstract class DataAggregator<TDataItem> : IDataAggregator<TDataItem>
    {
        private readonly IDataRetriever _retriever;

        protected DataAggregator(
            IDataRetriever retriever
        )
        {
            if (retriever == null)
                throw new ArgumentNullException(nameof(retriever));

            _retriever = retriever;
        }

        public TDataItem GetAll(string urlTemplate)
        {
            // Start at the first page
            var result = default(TDataItem);
            var page = 1;
            var pageCount = 1;

            while (page <= pageCount)
            {
                // Retrieve data from url, and aggregate it.
                var url = string.Format(urlTemplate, page);
                var data = _retriever.Get<TDataItem>(url);
                if (result == null)
                {
                    result = data;
                }
                else
                {
                    MergeResults(result, data);
                }

                pageCount = GetPageCount(data);
                page++;
            }
            return result;
        }

        protected abstract int GetPageCount(TDataItem dataItem);
        protected abstract void MergeResults(TDataItem aggregated, TDataItem dataItem);
    }
}
