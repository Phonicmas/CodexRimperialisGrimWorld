using Verse;

namespace CodexRimperialis;

public class CodexRimperialisModSettings : ModSettings
{
    public const float DefaultRepairCostFactor = 0.5f;

    public float repairCostFactor = DefaultRepairCostFactor;

    public override void ExposeData()
    {
        base.ExposeData();
        Scribe_Values.Look(ref repairCostFactor, "repairCostFactor", DefaultRepairCostFactor);
    }
}
