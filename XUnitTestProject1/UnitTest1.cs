using FluentAssertions;
using ContactProject.Models;
using ContactProject.Service;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using Xunit;

namespace XUnitTestProject1
{
    [ExcludeFromCodeCoverage]
    public class UnitTest1
    {
        [Fact]
        public void verify_email()
        {
            ContactModel contact = new ContactModel();
            contact.Email = "bad_email";
            contact.PhoneNumberPersonal = "00000";
            ContactService contactService = new ContactService(null);
            Task<ResponseModel> response = contactService.Create(contact);
            response.Result.Errors.Count.Should().Be(1);
            response.Result.Errors[0].Code.Should().Be("email_invalid");
        }
    }
}
