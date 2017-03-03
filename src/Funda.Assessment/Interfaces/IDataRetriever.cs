namespace Funda.Assessment.Interfaces
{
    /// <summary>
    /// This interface defines the contract of a data-retriever.
    /// A data-retriever is a class that can retrieve data based on an url.
    /// </summary>
    public interface IDataRetriever
    {
        /// <summary>
        /// Retrieves json data from a url, and converts it into an instance of an object.
        /// </summary>
        /// <typeparam name="TDataItem">The type of the data-item.</typeparam>
        /// <param name="url">The url where the data can be found.</param>
        /// <returns>The data that was retrieved from the url.</returns>
        TDataItem Get<TDataItem>(string url);
    }
}
