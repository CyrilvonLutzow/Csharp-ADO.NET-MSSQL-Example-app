namespace Csharp_ADO.NET_MSSQL_Example
{
    public class University : IModel
    {

        public int? Id { get; }
        public string ShortName { get; private set; }
        public string FullName { get; private set; }

        public University(string shortName, string fullname)
        {
            ShortName = shortName;
            FullName = fullname;
        }
        public University(int id, string shortName, string fullname)
        {
            Id = id;
            ShortName = shortName;
            FullName = fullname;
        }
    }
}