using HarmonyLib;
using RimWorld;
using Verse;

namespace CodexRimperialis;

[HarmonyPatch(typeof(Bill), nameof(Bill.GetWorkAmount))]
public static class HarmonyPatch_RepairWorkAmount
{
    public static void Postfix(Bill __instance, Thing thing, ref float __result)
    {
        if (thing == null)
        {
            return;
        }
        var extension = __instance.recipe?.GetModExtension<DefModExtension_RepairRecipe>();
        if (extension == null)
        {
            return;
        }
        var target = RepairUtility.FindRepairTarget(__instance, thing);
        if (target != null)
        {
            __result = RepairUtility.GetRepairWork(target, extension);
        }
    }
}
