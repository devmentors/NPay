using System.Threading.Tasks;
using NPay.Modules.Wallets.Core.Owners.Aggregates;
using NPay.Modules.Wallets.Core.SharedKernel;

namespace NPay.Modules.Wallets.Core.Owners.Repositories;

internal interface IOwnerRepository
{
    Task<Owner> GetAsync(OwnerId id);
    Task AddAsync(Owner owner);
    Task UpdateAsync(Owner owner);
}