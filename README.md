# Contact project

This code is a RESTful API, which allows you to manage contacts info; it was built with:
* .Net core 3.1
* MongoDB

##  Getting started
Make sure you have installed Docker and Visual Studio (2017 or 2019), git and Postman.

### How run run this project
First, we are going to clone this project as follows:
```
$ git clone https://github.com/carlosjm007/contactProject.git
$ cd contactProject
```
Then, let's install mongodb into a docker container:
```
$ docker-compose up --build
```
Finally, open the next solution with Visual Studio and run it with IIS Express:
```
contactProject/ContactProject.sln
```

### How to use this API
In order to handle the contacts info, this API provides 6 endpoints:
* POST `/api/contact`: It creates a contact

Body example:
```
{
    "name": "Carlos",  // Name
    "company": "Emsa",  // Company
    "profile": "teacher", // Profile
    "email": "carlos@emsa.com", // Email
    "phoneNumberWork": "22222",  // Phone number (work)
    "phoneNumberPersonal": "99999",  // Phone number (Personal)
    "address": "Av 89 # 87 - 32", //  Address
    "city": "Chicago" //  City
}
```
It returns something like:
```
{
    "contact": {
        "id": "f6e2a956-69fe-4805-93c9-96367df179c9",
        "name": "Marla",
        "company": "emsa",
        "profile": "teacher",
        "image": null,
        "email": "carlos@emsa.com",
        "birthDate": null,
        "phoneNumberWork": "22222",
        "phoneNumberPersonal": "99999",
        "address": "Av 89 # 87 - 32",
        "city": "Chicago"
    },
    "errors": null
}
```
When the field `errors` is equal to `null` it means that it was created succesfully; otherwise it will show all errors found. Example:
```
[
    {
        "field": "Email",
        "code": "email_invalid",
        "message": "A valid email is required"
    }
]
```

* GET `/api/contact/{id}`: It returns a contact
* DELETE `/api/contact/{id}`: It deletes a contact
* PUT `/api/contact`: It updates a contact

Body example:
```
{
    "id": "b283ca22-2204-47d9-96b2-2aff1314711a", //  Important
    "name": "Carlos",
    "company": "emsa",
    "profile": "teacher",
    "email": "carlos@emsa.comm",
    "phoneNumberWork": null,
    "phoneNumberPersonal": "3333333",
    "address": "Av 89 # 87 - 32",
    "city": "villavo"
}
```
It returns similar as if it were created.

* GET `/api/contact/FindByPhoneOrEmail?phone={phone}&email={email}`: It return a contact list, those contacts match with phone and email
* GET `/api/contact/FindByPhoneOrEmail?city={city}`: It return a contact list, those contacts match with city


## Run unit test
Inside the solution you will find a project called `XUnitTestProject1`; this countains a unit test that evaluates a contact emai.
Unit test: `contactProject\XUnitTestProject1\UnitTest1.cs`
```
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
```
### To run this unit test
With visual Studio, just righ clic over `XUnitTestProject1` project, and select `Run unit test`, then `UnitTest1.cs` is going to be excecuted.
