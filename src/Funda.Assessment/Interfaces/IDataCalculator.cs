using Funda.Assessment.Entities;

namespace Funda.Assessment.Interfaces
{
    /// <summary>
    /// This interface defines the contract of a data-calculator.
    /// A data-calculator is a class that calculates a result based on some data.
    /// </summary>
    public interface IDataCalculator
    {
        /// <summary>
        /// Calculates a result from data and displays it.
        /// </summary>
        /// <param name="data">The data used to calculate.</param>
        /// <param name="title">The title to use when displaying the data.</param>
        void CalculateAndDisplay(FundaDataResult data, string title);
    }
}
