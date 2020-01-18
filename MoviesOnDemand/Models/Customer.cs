using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MoviesOnDemand.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsSubcribeToNewsLetter { get; set; }
        public MembershipType MembershipType { get; set; }
    }
}