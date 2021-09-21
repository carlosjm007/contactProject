using FluentValidation;
using FluentValidation.Results;
using ContactProject.Context;
using ContactProject.Models;
using ContactProject.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactProject.Service
{
    public class ContactService : IContactService
    {
        private readonly IMongoContactContext _contactRepository;

        public ContactService(IMongoContactContext contactRepository)
        {
            _contactRepository = contactRepository;
        }

        public async Task<ResponseModel> Create(ContactModel contact)
        {
            ResponseModel responseModel = new ResponseModel();
            List<ErrorsModel> listErrors = new List<ErrorsModel>();
            ContactValidator contactValidator = new ContactValidator();
            //Object 
            var errors = contactValidator.Validate(contact);
            if (!errors.IsValid)
            {
                foreach (var err in errors.Errors)
                {
                    var error = new ErrorsModel();
                    error.Field = err.PropertyName;
                    error.Code = err.ErrorCode;
                    error.Message = err.ErrorMessage;
                    listErrors.Add(error);
                }
                responseModel.Contact = contact;
                responseModel.Errors = listErrors;
                return responseModel;
            }
            var result = await _contactRepository.Create(contact);
            responseModel.Contact = result;
            return responseModel;
        }

        public async Task<ContactModel> Find(Guid id)
        {
            return await _contactRepository.Find(id);
        }


        public async Task<List<ContactModel>> FindByCity(string city)
        {
            return await _contactRepository.FindByCity(city);
        }
        public async Task<ResponseModel> Update(ContactModel contact)
        {
            ResponseModel responseModel = new ResponseModel();
            List<ErrorsModel> listErrors = new List<ErrorsModel>();
            ContactValidator contactValidator = new ContactValidator();
            //Object 
            var errors = contactValidator.Validate(contact);
            if (!errors.IsValid)
            {
                foreach (var err in errors.Errors)
                {
                    var error = new ErrorsModel();
                    error.Field = err.PropertyName;
                    error.Code = err.ErrorCode;
                    error.Message = err.ErrorMessage;
                    listErrors.Add(error);
                }
                responseModel.Contact = contact;
                responseModel.Errors = listErrors;
                return responseModel;
            }
            var result = await _contactRepository.Update(contact);
            responseModel.Contact = contact;
            return responseModel;
        }

        public async Task<List<ContactModel>> FindByPhoneOrEmail(string phone, string email)
        {
            return await _contactRepository.FindByPhoneOrEmail(phone, email);
        }

        public async Task<bool> Delete(Guid id)
        {
            return await _contactRepository.Delete(id);
        }
    }
}
