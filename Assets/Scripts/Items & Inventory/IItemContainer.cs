public interface IItemContainer
{
    ItemSlot AddItem(ItemSlot itemSlot);
    void RemoveItem(ItemSlot itemSlot);
    void RemoveAt(int slotIndex);
    void Swap(int indexOne, int indexTwo);
    bool HasItem(InventoryItem item);
    public int GetTotalQuantity(InventoryItem item);

}
