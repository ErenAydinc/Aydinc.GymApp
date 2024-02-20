namespace Core.Application.Dtos;

public class UserForRegisterDto : IDto
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime BirthDay { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }

    public UserForRegisterDto()
    {
        PhoneNumber = string.Empty;
        BirthDay = DateTime.MinValue;
        FirstName = string.Empty;
        LastName = string.Empty;
        Email = string.Empty;
        Password = string.Empty;
    }

    public UserForRegisterDto(string email, string password, string lastName, string firstName, DateTime birthDay, string phoneNumber)
    {
        LastName = lastName;
        FirstName = firstName;
        BirthDay = birthDay;
        PhoneNumber = phoneNumber;
        Email = email;
        Password = password;
    }
}
