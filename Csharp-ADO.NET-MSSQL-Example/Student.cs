using System;

namespace Csharp_ADO.NET_MSSQL_Example
{
    public class Student : IModel
    {

        public int? Id { get; }
        public string FirstName { get; private set; }
        public string Lastname { get; private set; }
        public string Patronym { get; private set; }
        public DateTime Birthday { get; private set; }
        public int UniverId { get; private set; }
        public int FacultyId { get; private set; }
        public DateTime AcceptanceDate { get; private set; }

        public Student(string firstName, string lastname1, string patronym1, DateTime birthday, int univerId, int facultyId, DateTime acceptanceDate)
        {
            FirstName = firstName;
            Lastname = lastname1;
            Patronym = patronym1;
            Birthday = birthday;
            UniverId = univerId;
            FacultyId = facultyId;
            AcceptanceDate = acceptanceDate;
        }
    }
}