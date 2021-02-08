using System;
using System.Collections.Generic;

namespace ReqresAPITestsNetCore
{
    public partial class ListOfUsersDTO
    {
        public long Page { get; set; }
        public long PerPage { get; set; }
        public long Total { get; set; }
        public long TotalPages { get; set; }
        public List<Data> Data { get; set; }
    }

    public partial class Data
    {
        public long Id { get; set; }
        public string Email { get; set; }
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public Uri Avatar { get; set; }
    }
}


