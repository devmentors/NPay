using System;

namespace NPay.Modules.Wallets.Core.SharedKernel;

internal sealed class OwnerId : IEquatable<OwnerId>
{
    public Guid Value { get; }
        
    public OwnerId(Guid value)
    {
        Value = value;
    }

    public bool Equals(OwnerId other)
    {
        if (ReferenceEquals(null, other)) return false;
        return ReferenceEquals(this, other) || Value.Equals(other.Value);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        return obj.GetType() == GetType() && Equals((OwnerId)obj);
    }

    public override int GetHashCode() => Value.GetHashCode();
        
    public override string ToString() => Value.ToString();
        
    public static implicit operator OwnerId(Guid value) => new(value);

    public static implicit operator Guid(OwnerId value) => value.Value;
}