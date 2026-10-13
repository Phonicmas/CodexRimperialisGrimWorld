using Verse;

namespace CodexRimperialis;

public class RecipeWorker_RepairEquipment : RecipeWorker
{
    public override void ConsumeIngredient(Thing ingredient, RecipeDef recipe, Map map)
    {
        if (RepairUtility.IsRepairTarget(ingredient, recipe))
        {
            return;
        }
        base.ConsumeIngredient(ingredient, recipe, map);
    }
}
