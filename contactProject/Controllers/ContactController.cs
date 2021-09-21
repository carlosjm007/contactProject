using ContactProject.Models;
using ContactProject.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace ContactProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactService _ContactService;

        public ContactController(IContactService contactService)
        {
            _ContactService = contactService;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ContactModel), (int)HttpStatusCode.OK)]
        public async Task<ContactModel> Get(Guid id)
        {
            var result = await _ContactService.Find(id);
            return result;
        }

        // GET api/values/5
        [HttpGet]
        [ProducesResponseType(typeof(ContactModel), (int)HttpStatusCode.OK)]
        public async Task<List<ContactModel>> getByCity(string city)
        {
            var result = await _ContactService.FindByCity(city);
            return result;
        }

        // GET api/values/5
        [HttpGet("FindByPhoneOrEmail")]
        [ProducesResponseType(typeof(ContactModel), (int)HttpStatusCode.OK)]
        public async Task<List<ContactModel>> findByPhoneOrEmail(string phone, string email)
        {
            var result = await _ContactService.FindByPhoneOrEmail(phone, email);
            return result;
        }

        // POST api/values
        [HttpPost]
        [ProducesResponseType(typeof(ResponseModel), (int)HttpStatusCode.Created)]
        public async Task<ResponseModel> Post(ContactModel contactModel)
        {
            var result = await _ContactService.Create(contactModel);
            return result;
        }

        // PUT api/values/5
        [HttpPut]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
        public async Task<ResponseModel> Put(ContactModel contactModel)
        {
            var result = await _ContactService.Update(contactModel);
            return result;
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task<bool> Delete(Guid id)
        {
            var result = await _ContactService.Delete(id);
            return result;
        }
    }
}
