using System;
using System.ComponentModel.DataAnnotations;

namespace Sample_ASP.NET_Site.Models
{
    public class Client
    {
        public int ID
        {
            get;
            set;
        }

        public string LastName
        {
            get;
            set;
        }

        public string FirstName
        {
            get;
            set;
        }

        public DateTime? Timestamp
        {
            get;
            set;
        }
    }
}
