using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rFile1
{
    class AccountRecord
    {

        private int _account;
        private string _firstName;
        private string _lastName;
        private double _balance;

        public AccountRecord ()
        {
            Account = 0;
            FirstName = "";
            LastName = "";
            Balance = 0.0;
        }
        public AccountRecord(int acct, string fn, string ln, double bal)
        {
            Account = acct;
            FirstName = fn;
            LastName = ln;
            Balance = bal;
        }

        public int Account
        {
            get
            {
                return _account;
            }
            set
            {
                _account = value;
            }
        }
        public string FirstName
        {
            get
            {
                return _firstName;
            }
            set
            {
                _firstName = value;
            }
        }
        public string LastName
        {
            get
            {
                return _lastName;
            }
            set
            {
                _lastName = value;
            }
        }
        public double Balance
        {
            get
            {
                return _balance;
            }
            set
            {
                _balance = value;
            }
        }
    }
}
