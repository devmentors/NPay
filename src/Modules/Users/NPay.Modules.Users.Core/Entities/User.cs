using System;
using NPay.Modules.Users.Core.Exceptions;

namespace NPay.Modules.Users.Core.Entities;

internal sealed class User
{
    public Guid Id { get; private set; }
    public string Email { get; private set; }
    public string FullName { get; private set; }
    public string Address { get; private set; }
    public string Nationality { get; private set; }
    public string Identity { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime? VerifiedAt { get; private set; }

    private User()
    {
    }

    public User(Guid id, string email, string fullName, string address, string nationality, string identity,
        DateTime createdAt)
    {
        Id = id;
        Email = email;
        FullName = fullName;
        Address = address;
        Nationality = nationality;
        Identity = identity;
        CreatedAt = createdAt;
    }

    public void Verify(DateTime verifiedAt)
    {
        if (VerifiedAt.HasValue)
        {
            throw new UserAlreadyVerifiedException(Id);
        }

        VerifiedAt = verifiedAt;
    }
}