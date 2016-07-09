namespace Csharp_ADO.NET_MSSQL_Example
{
    public class Faculty : IModel
    {

        public int? Id { get; }
        public string ShortName { get; private set; }

        public Faculty(string shortName, string fullname)
        {
            ShortName = shortName;
           
        }
    }
}