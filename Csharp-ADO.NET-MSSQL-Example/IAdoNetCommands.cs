using System.Collections.Generic;

namespace Csharp_ADO.NET_MSSQL_Example
{
    public interface IAdoNetCommands
    {
        void Insert(IModel model);

        void Update(IModel model);

        void Delete(IModel model);
        List<IModel> ReadDataFromSqlTable();

    }
}