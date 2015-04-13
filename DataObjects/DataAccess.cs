using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;

namespace DoFactory.DataLayer.DataObjects
{
    /// <summary>
    /// This class shields the client from the details of database specific 
    /// data-access objects. It returns the appropriate data-access objects 
    /// according to the configuration in web.config.
    /// 
    /// GoF Design Patterns: Factory, Singleton, Proxy.
    /// </summary>
    /// <remarks>
    /// This class makes extensive use of the Factory pattern in determining which 
    /// database specific DAOs (Data Access Objects) to return.
    /// 
    /// This class is like a Singleton -- it is a static class (Shared in VB) and 
    /// therefore only one 'instance' ever will exist.
    /// 
    /// This class is a Proxy in that it 'stands in' for the actual Data Access Object Factory.
    /// </remarks>
    public static class DataAccess
    {
        // The static field initializers below are thread safe.
        // Furthermore, they are executed in the order in which they appear
        // in the class declaration. Note: if a static constructor
        // is present you want to initialize these in that constructor.
        private static readonly string dataProvider = ConfigurationManager.AppSettings.Get("DataProvider");
        private static readonly DaoFactory factory = DaoFactories.GetFactory(dataProvider);

        /// <summary>
        /// Gets a provider specific customer data access object.
        /// </summary>
        public static ICustomerDao CustomerDao
        {
            get { return factory.CustomerDao; }
        }

        /// <summary>
        /// Gets a provider specific order data access object.
        /// </summary>
        public static IOrderDao OrderDao
        {
            get { return factory.OrderDao; }
        }

        /// <summary>
        /// Gets a provider specific product data access object.
        /// </summary>
        public static IProductDao ProductDao
        {
            get { return factory.ProductDao; }
        }
    }
}
