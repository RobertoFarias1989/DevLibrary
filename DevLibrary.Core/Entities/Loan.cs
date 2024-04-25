using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevLibrary.Core.Entities
{
    public class Loan : BaseEntity
    {
        public Loan(int idUser, int idBook)
        {
            IdUser = idUser;
            IdBook = idBook;
            //NumberLoanDay = numberLoanDay;

            //LoanedQuanity = null;
            //ReturnedQuantity = null;
            LoanDate = DateTime.Now;
            ReturnedDate = null;


        }

        public int IdUser { get; private set; }
        public User User { get; private set; }
        public int IdBook { get; private set; }
        public Book Book { get; private set; }
        //public int? LoanedQuanity { get; private set; }
        //public int? ReturnedQuantity { get; private set; }
        //public int NumberLoanDay { get; private set; }
        public DateTime LoanDate { get; private set; }
        public DateTime ExpectedReturnDate { get; private set; }
        public DateTime? ReturnedDate { get; private set; }

        public void ExpectedReturnedDate(int numberLoanDay)
        {
            ExpectedReturnDate = LoanDate.AddDays(numberLoanDay);
        }
        public void RenewLoan(int day)
        {
            ExpectedReturnDate = ExpectedReturnDate.AddDays(day);
        }
        public void ReturnedBook()
        {
            ReturnedDate = DateTime.Now;
        }
    }
}
