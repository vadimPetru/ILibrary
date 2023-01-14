using DataBase.DAL.Context;
using DataBase.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace ILibrary
{
    public class ManagerDB
    {
        public void AddBooking(Booking booking)
        {
            using (IlibraryContext context = new IlibraryContext())
            {
                context.Bookings.Add(booking);
                context.SaveChanges();
            }
                
        }

        public Booking FindBooking(string? BookCode, string? ReaderCode,DateTime DateOfOrder)
        {
            Booking book = new();
            book.BookCode = BookCode;
            book.ReaderCode = ReaderCode;
            book.DateOfOrder = DateOfOrder;
            using(IlibraryContext context = new())
            {
                
                 var element = context.Bookings.FirstOrDefault(item => item.BookCode == book.BookCode
                                                                   && item.ReaderCode == book.ReaderCode
                                                                   && item.DateOfOrder == book.DateOfOrder);
                return element;
                
            }
        }

        

    }
}
