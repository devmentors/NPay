using System;
using System.Collections.Generic;

namespace NPay.Modules.Wallets.Shared.DTO;

public class WalletDto
{
    public Guid WalletId { get; set; }
    public Guid OwnerId { get; set; }
    public string Currency { get; set; }
    public DateTime CreatedAt { get; set; }
    public decimal Amount { get; set; }
    public List<TransferDto> Transfers { get; set; }
}