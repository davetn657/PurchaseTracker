using Microsoft.AspNetCore.Mvc;
using PurchaseTracker.Api.Dtos;
using PurchaseTracker.Api.Mappers;
using PurchaseTracker.Api.Repository;

namespace PurchaseTracker.Api.Controllers;

[Route("api/")]
[ApiController]
public class PurchaseItemController : ControllerBase
{
    private readonly PurchaseItemRepository _itemRepo;

    public PurchaseItemController(PurchaseItemRepository itemRepo)
    {
        _itemRepo = itemRepo;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetItemById(int id)
    {
        var purchaseItem = await _itemRepo.GetItemById(id);

        if (purchaseItem == null) return NotFound();

        return Ok(purchaseItem);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllItems()
    {
        var purchaseItems = await _itemRepo.GetAllItems();

        return Ok(purchaseItems);
    }

    [HttpPost]
    public async Task<IActionResult> CreateItem([FromBody] PurchaseItemDto newItemInfo)
    {
        var createdItem = await _itemRepo.CreateItem(newItemInfo);

        return CreatedAtAction(nameof(GetItemById), new { id = createdItem.Id }, createdItem.ToPurchaseDto());
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteItem(int id)
    {
        var deletedItem = await _itemRepo.DeleteItem(id);

        if (deletedItem == null) return NotFound();

        return Ok(deletedItem);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateItem(int id, [FromBody] PurchaseItemDto updatedItemInfo)
    {
        var updatedItem = await _itemRepo.UpdateItem(id, updatedItemInfo);

        if (updatedItem == null) return NotFound(updatedItem);

        return Ok(updatedItem);
    }
}