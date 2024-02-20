using Core.Persistence.Repositories;
using Core.Security.Enums;

namespace Core.Security.Entities;

public class User<TId, TOperationClaimId> : Entity<TId>
{
    public string Email { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime BirthDay { get; set; }
    public string PhoneNumber { get; set; }
    public byte[] PasswordSalt { get; set; }
    public byte[] PasswordHash { get; set; }
    public AuthenticatorType AuthenticatorType { get; set; }

    public virtual ICollection<UserOperationClaim<TId, TOperationClaimId>> UserOperationClaims { get; set; } = null!;
    public virtual ICollection<RefreshToken<TId, TOperationClaimId>> RefreshTokens { get; set; } = null!;
    public virtual ICollection<EmailAuthenticator<TId, TOperationClaimId>> EmailAuthenticators { get; set; } = null!;
    public virtual ICollection<OtpAuthenticator<TId, TOperationClaimId>> OtpAuthenticators { get; set; } = null!;

    public User()
    {
        PhoneNumber = string.Empty;
        BirthDay = DateTime.MinValue;
        FirstName = string.Empty;
        LastName = string.Empty;
        Email = string.Empty;
        PasswordHash = Array.Empty<byte>();
        PasswordSalt = Array.Empty<byte>();
    }

    public User(string email,string lastName,string firstName,DateTime birthDay,string phoneNumber, byte[] passwordSalt, byte[] passwordHash, AuthenticatorType authenticatorType)
    {
        LastName = lastName;
        FirstName = firstName;
        BirthDay = birthDay;
        PhoneNumber = phoneNumber;
        Email = email;
        PasswordSalt = passwordSalt;
        PasswordHash = passwordHash;
        AuthenticatorType = authenticatorType;
    }

    public User(TId id, string email, string lastName, string firstName, DateTime birthDay, string phoneNumber, byte[] passwordSalt, byte[] passwordHash, AuthenticatorType authenticatorType)
        : base(id)
    {
        LastName = lastName;
        FirstName = firstName;
        BirthDay = birthDay;
        PhoneNumber = phoneNumber;
        Email = email;
        PasswordSalt = passwordSalt;
        PasswordHash = passwordHash;
        AuthenticatorType = authenticatorType;
    }
}
