using Dapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace GadgetsAndGizmos.DataAccessLayer.Repository.IRepository
{
    public interface ISP_Call : IDisposable
    {
        /// <summary>
        /// Uses execute scalar which returns integer or boolean
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="procedureName"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        T Single<T>(string procedureName, DynamicParameters param = null);

        void Execute(string procedureName, DynamicParameters param = null);

        /// <summary>
        /// Returns one complete row
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="procedureName"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        T OneRecord<T>(string procedureName, DynamicParameters param = null);

        /// <summary>
        /// Gets All Rows
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="procedureName"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        IEnumerable<T> List<T>(string procedureName, DynamicParameters param = null);

        /// <summary>
        /// Returns two tables
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <param name="procedureName"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        Tuple<IEnumerable<T1>, IEnumerable<T2>> List<T1, T2>(string procedureName, DynamicParameters param = null);
    }
}
