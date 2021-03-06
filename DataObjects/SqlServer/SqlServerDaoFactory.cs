using System;
using System.Collections.Generic;
using System.Text;

namespace DoFactory.DataLayer.DataObjects.SqlServer
{
    /// <summary>
    /// Sql Server specific factory that creates Sql Server specific data access objects.
    /// 
    /// GoF Design Pattern: Factory.
    /// </summary>
    public class SqlServerDaoFactory : DaoFactory
    {
        /// <summary>
        /// Gets a Sql server specific customer data access object.
        /// </summary>
        public override ICustomerDao CustomerDao
        {
            get { return new SqlServerCustomerDao(); }
        }

        /// <summary>
        /// Gets a Sql server specific order data access object.
        /// </summary>
        public override IOrderDao OrderDao
        {
            get { return new SqlServerOrderDao(); }
        }

        /// <summary>
        /// Gets a Sql server specific product data access object.
        /// </summary>
        public override IProductDao ProductDao
        {
            get { return new SqlServerProductDao(); }
        }
    }
}
