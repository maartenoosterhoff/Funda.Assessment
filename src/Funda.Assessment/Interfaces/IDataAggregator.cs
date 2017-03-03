namespace Funda.Assessment.Interfaces
{
    /// <summary>
    /// This interface defines the contract of a data-aggregator.
    /// A data-aggregator is a class that can aggregate the (paging) results which are retrieved by a data-retriever.
    /// </summary>
    /// <typeparam name="TDataItem">The type of the data-item.</typeparam>
    public interface IDataAggregator<out TDataItem>
    {
        /// <summary>
        /// Retrieves all data.
        /// </summary>
        /// <param name="urlTemplate">The url template where {0} will be replaced with the page number.</param>
        /// <returns>All aggregated data.</returns>
        TDataItem GetAll(string urlTemplate);
    }
}
