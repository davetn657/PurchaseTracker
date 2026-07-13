using PurchaseTracker.Api.Dtos;
using PurchaseTracker.Api.Models;

namespace PurchaseTracker.Api.Mappers;

public static class PurchaseItemMapper
{
    public static PurchaseItemDto ToPurchaseDto(this PurchaseItem item)
    {
        return new PurchaseItemDto
        {
            ItemName = item.ItemName,
            Price = item.Price,
            Quantity = item.Quantity,
            PurchaseDate = item.PurchaseDate,
            PaymentStatus = item.PaymentStatus,
            PaymentPrice = item.PaymentPrice,
        };
    }

    public static PurchaseItem ToPurchaseItem(this PurchaseItemDto itemDto)
    {
        return new PurchaseItem
        {
            ItemName = itemDto.ItemName,
            Price = itemDto.Price,
            Quantity = itemDto.Quantity,
            PurchaseDate = itemDto.PurchaseDate,
            PaymentStatus = itemDto.PaymentStatus,
            PaymentPrice = itemDto.PaymentPrice,
        };
    }
}