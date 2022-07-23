using System;

namespace NPay.Modules.Wallets.Core.Wallets.ValueObjects;

internal sealed class TransferId : IEquatable<TransferId>
{
    public Guid Value { get; }

    public TransferId() : this(Guid.NewGuid())
    {
    }
        
    public TransferId(Guid value)
    {
        Value = value;
    }

    public bool Equals(TransferId other)
    {
        if (ReferenceEquals(null, other)) return false;
        return ReferenceEquals(this, other) || Value.Equals(other.Value);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        return obj.GetType() == GetType() && Equals((TransferId)obj);
    }

    public override int GetHashCode() => Value.GetHashCode();
        
    public override string ToString() => Value.ToString();
        
    public static implicit operator TransferId(Guid value) => new(value);

    public static implicit operator Guid(TransferId value) => value.Value;
        
    public static implicit operator Guid?(TransferId value) => value?.Value;
}