using System.Collections.Generic;
using HarmonyLib;
using RimWorld;
using Verse;

namespace CodexRimperialis;

[HarmonyPatch(typeof(WorkGiver_DoBill), "TryFindBestBillIngredients")]
public static class HarmonyPatch_RepairIngredients
{
    public static bool Prefix(Bill bill, Pawn pawn, Thing billGiver, List<ThingCount> chosen, List<IngredientCount> missingIngredients, ref bool __result)
    {
        if (!RepairUtility.IsRepairRecipe(bill?.recipe))
        {
            return true;
        }
        __result = RepairUtility.TryFindRepairIngredients(bill, pawn, billGiver, chosen, missingIngredients);
        return false;
    }
}
