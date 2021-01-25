using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class ConsumableItem : InventoryItem
{
    [Header("Consumable Data")] [SerializeField]
    private string useText = "Does Something maybe?";

    public override string GetInfoDisplayText()
    {
        StringBuilder builder = new StringBuilder();

        builder.Append(name).AppendLine();
        builder.Append("<color=green>Use: ").Append(useText).Append("</color>").AppendLine();
        builder.Append("Max stack: ").Append(MaxStack).AppendLine();
        builder.Append("Sell price: ").Append(SellPrice).Append(" Gold").AppendLine();

        return builder.ToString();
    }
}
