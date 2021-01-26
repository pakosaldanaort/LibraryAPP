using System;

namespace Domain
{
    public class Book
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string ISBN { get; set; }
        public DateTime? CheckOutDate { get; set; }
        public DateTime? OverDueDate{ get; set; }
        public int? UserId { get; set; }
        public virtual User User { get; set; }
    }
}