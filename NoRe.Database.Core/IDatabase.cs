using NoRe.Database.Core.Models;
using System;
using System.Collections.Generic;

namespace NoRe.Database.Core
{
    /// <summary>
    /// Base interface of all database wrappers of relational databases
    /// </summary>
    public interface IDatabase : IDisposable
    {
        /// <summary>
        /// Executes a non query 
        /// </summary>
        /// <param name="commandText">the command</param>
        /// <param name="parameters">the parameters, use @0, @1, @2 in the command to assign the values</param>
        /// <returns>returns the amount of changed entries</returns>
        int ExecuteNonQuery(string commandText, params object[] parameters);

        /// <summary>
        /// Executes a scalar
        /// </summary>
        /// <param name="commandText">the command</param>
        /// <param name="parameters">the parameters, use @0, @1, @2 in the command to assign the values</param>
        /// <returns>returns the only value found as T</returns>
        T ExecuteScalar<T>(string commandText, params object[] parameters);

        /// <summary>
        /// Executes a reader
        /// </summary>
        /// <param name="commandText">the command</param>
        /// <param name="parameters">the parameters, use @0, @1, @2 in the command to assign the values</param>
        /// <returns>returns the result in a table object</returns>
        Table ExecuteReader(string commandText, params object[] parameters);

        /// <summary>
        /// Starts a transaction and executes multiple commands
        /// Commits the transaction if successfull
        /// Rollsback if an exception is thrown
        /// </summary>
        /// <param name="commandText">the command</param>
        /// <param name="parameters">the parameters, use @0, @1, @2 in the command to assign the values</param>
        void ExecuteTransaction(List<Query> queries);

        /// <summary>
        /// Starts a transaction and executes the command
        /// Commits the transaction if successfull
        /// Rollsback if an exception is thrown
        /// </summary>
        /// <param name="commandText">the command</param>
        /// <param name="parameters">the parameters, use @0, @1, @2 in the command to assign the values</param>
        void ExecuteTransaction(string commandText, params object[] parameters);

        /// <summary>
        /// Checks if the wrapper can connect to the database
        /// </summary>
        /// <param name="error">returns a potential error message</param>
        /// <returns>true if connection is successfull</returns>
        bool TestConnection(out string error);
    }
}
