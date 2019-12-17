using CarDealership.Data.Interfaces;
using CarDealership.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Data.QARepositories
{
    public class ContactRepositoryQA : IContactRepository
    {

        static List<Contact> contactList = new List<Contact>();

        public void AddContact(Contact contact)
        {
            int maxContactId = 1;

            if (contactList.Any())
            {
                maxContactId = contactList.Max(c => c.Id);
            }


            contactList.Add(new Contact()
            {
                Id = maxContactId + 1,
                Email = contact.Email,
                Name = contact.Name,
                Phone = contact.Phone,
                Message = contact.Message
            });
        }


    }
}
