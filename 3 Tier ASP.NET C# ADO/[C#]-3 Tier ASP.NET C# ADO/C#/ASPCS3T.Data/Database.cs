//-----------------------------------------------------------------------
// <copyright file="Database.cs" company="Edson Castañeda">
//     Copyright © Edson Castañeda. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace ASPCS3T.Data
{
    using System.Configuration;
    using System.Data;
    using System.Data.SqlClient;

    /// <summary>
    /// The 'Database' class
    /// </summary>
    public class Database
    {
        public static SqlConnection GetConnection()
        {
            return new SqlConnection(ConfigurationManager.ConnectionStrings["ASPCS3T"].ConnectionString);
        }
    }
}