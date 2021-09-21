using ContactProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactProject.Context
{
    public interface IMongoContactContext
    {
        Task<ContactModel> Create(ContactModel contact);

        Task<ContactModel> Find(Guid id);

        Task<List<ContactModel>> FindByCity(string city);

        Task<bool> Update(ContactModel contact);

        Task<List<ContactModel>> FindByPhoneOrEmail(string phone, string email);

        Task<bool> Delete(Guid id);
    }
}
