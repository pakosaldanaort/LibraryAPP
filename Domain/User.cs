using System;
using System.Collections.Generic;

namespace Domain
{
    public class User
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool IsLibrerian { get; set; }
        public virtual ICollection<Book> Books { get; set; }
    }
}
