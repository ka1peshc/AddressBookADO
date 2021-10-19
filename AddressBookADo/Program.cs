using System;

namespace AddressBookADo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Contact contact = new Contact();
            contact.Firstname="Shivani";
            contact.Lastname = "Maynak";
            contact.Address = "Bandra";
            contact.City = "Mumbai";
            contact.State = "Maharashtra";
            contact.Email = "shiva@gmail.com";
            contact.Zipno = 400035;
            contact.PhoneNo = 9892414408;

            CRUDOperation crudOperation = new CRUDOperation();
            //crudOperation.InsertDataToAddressBook(contact);
            crudOperation.UpdatePhoneNumber();
        }
    }
}
