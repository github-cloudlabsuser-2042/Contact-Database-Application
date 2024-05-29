using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRUD_application_2.Models
{
    public class SearchModel
    {
        public string SearchTerm { get; set; }
        public System.Collections.Generic.List<User> Results { get; set; }
    }
}