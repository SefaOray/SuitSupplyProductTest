using System;
using System.Collections.Generic;
using System.Text;

namespace SuitSupplyProductTest.Data.Config
{
    /// <summary>
    /// Configurations for data layer
    /// </summary>
    public class DataConfig
    {
        public SqlConfig SqlConfig { get; set; }
    }

    public class SqlConfig
    {
        public string ConnectionStr { get; set; }
    }
}
