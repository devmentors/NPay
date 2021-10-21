using System;

namespace NPay.Shared.Time
{
    public interface IClock
    {
        DateTime CurrentDate();
    }
}