using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Test1.Model
{
    public class Persons
    {

        public bool IsSelected { get; set; }
        public int Id { get; set; }
        public string? userName { get; set; }
        public string? password { get; set; }
        public string? FName { get; set; }
        public string? LName { get; set; }
        public string? FullName
        {
            get
            {
                return $"{FName} {LName}";
            }
        }
        public string? Gender { get; set; }
        public int Age { get; set; }
        public string? Address { get; set; }
        public string? phoneNumber { get; set; }
        public string? Email { get; set; }
        public DateTime DateOfBirth { get; set; }

        public string? pathImagePerson { get; set; }

        public bool roleAccount { get; set; }
     
    }
}
