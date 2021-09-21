using ContactProject.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactProject.Context
{
    public class MongoContactContext : IMongoContactContext
    {
        private readonly IMongoCollection<ContactModel> _FormsContact;

        public MongoContactContext(IMongoCollection<ContactModel> formsContact)
        {
            _FormsContact = formsContact;
        }

        public async Task<ContactModel> Create(ContactModel contact)
        {
            await _FormsContact.InsertOneAsync(contact);
            return contact;
        }


        public async Task<ContactModel> Find(Guid id)
        {
            return await _FormsContact.FindAsync(item => item.ID.Equals(id)).Result.FirstOrDefaultAsync();
        }


        public async Task<List<ContactModel>> FindByCity(string city)
        {
            return await _FormsContact.FindAsync(item => item.City.Equals(city)).Result.ToListAsync();
        }

        public async Task<bool> Update(ContactModel contact)
        {
            var filters = Builders<ContactModel>.Filter.Eq("ID", contact.ID);

            var updates = Builders<ContactModel>.Update
                .Set("Name", contact.Name)
                .Set("Company", contact.Company)
                .Set("Profile", contact.Profile)
                .Set("Image", contact.Image)
                .Set("Email", contact.Email)
                .Set("BirthDate", contact.BirthDate)
                .Set("PhoneNumberWork", contact.PhoneNumberWork)
                .Set("PhoneNumberPersonal", contact.PhoneNumberPersonal)
                .Set("Address", contact.Address)
                .Set("City", contact.City);

            var updateResult = await _FormsContact.UpdateOneAsync(filters, updates);

            return updateResult.IsAcknowledged && updateResult.ModifiedCount > 0;
        }


        public async Task<List<ContactModel>> FindByPhoneOrEmail(string phone, string email)
        {
            return await _FormsContact.FindAsync(item =>
                item.Email.Equals(email) ||
                item.PhoneNumberPersonal.Equals(phone) ||
                item.PhoneNumberWork.Equals(phone)).Result.ToListAsync();
        }

        public async Task<bool> Delete(Guid id)
        {
            var updateResult = await _FormsContact.DeleteOneAsync(item => item.ID.Equals(id));
            return updateResult.IsAcknowledged && updateResult.DeletedCount > 0;
        }

    }
}
