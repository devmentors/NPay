using System;

namespace NPay.Modules.Wallets.Shared.DTO;

public class TransferDto
{
    public string Direction { get; set; }
    public Guid TransferId { get; set; }
    public Guid? ReferenceId { get; set; }
    public Guid WalletId { get; set; }
    public decimal Amount { get; set; }
    public string Currency { get; set; }
    public DateTime CreatedAt { get; set; }
}