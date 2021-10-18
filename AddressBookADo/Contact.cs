using System;
using System.Collections.Generic;
using System.Text;

namespace AddressBookADo
{
    class Contact
    {
        private string firstname, lastname, address, city, state, email;
        private int zipNo;
        private long Phonenumber;

        public string Firstname { get { return firstname; } set { firstname = value; } }
        public string Lastname { get { return lastname; } set { lastname = value; } }
        public string Address { get { return address; } set { address = value; } }
        public string City { get { return city; } set { city = value; } }
        public string State { get { return state; } set { state = value; } }
        public string Email { get { return email; } set { email = value; } }
        public int Zipno { get { return zipNo; } set { zipNo = value; } }
        public long PhoneNo { get { return Phonenumber; } set { Phonenumber = value; } }
    }
}
