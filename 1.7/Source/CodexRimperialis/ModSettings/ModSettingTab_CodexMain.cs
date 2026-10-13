using System;
using Core40k;
using UnityEngine;
using Verse;

namespace CodexRimperialis;

public class ModSettingTab_CodexMain : ModSettingTab
{
    private const float MinRepairCostFactor = 0f;
    private const float MaxRepairCostFactor = 2f;

    public override void DrawTab(Rect inRect, ModSettings settings)
    {
        if (settings is not CodexRimperialisModSettings codexSettings)
        {
            Log.Error("Settings not correct type");
            return;
        }

        var viewRect = new Rect(inRect.x, inRect.y, inRect.width - 16f, scrollViewHeight);
        scrollViewHeight = 0f;

        Widgets.BeginScrollView(inRect, ref scrollPos, viewRect);
        var listingStandard = new Listing_Standard();
        listingStandard.Begin(viewRect);
        listingStandard.Gap(36);
        scrollViewHeight += ListingHeightIncreaseGap;

        listingStandard.Label("BEWH.CodexRimperialis.ModSettings.RepairCostFactor".Translate(codexSettings.repairCostFactor.ToStringPercent()), -1f, "BEWH.CodexRimperialis.ModSettings.RepairCostFactorTooltip".Translate());
        scrollViewHeight += ListingHeightIncrease;

        var value = listingStandard.Slider(codexSettings.repairCostFactor, MinRepairCostFactor, MaxRepairCostFactor);
        codexSettings.repairCostFactor = (float)Math.Round(value * 20f) / 20f;
        scrollViewHeight += ListingHeightIncrease;

        if (listingStandard.ButtonText("BEWH.CodexRimperialis.ModSettings.ResetToDefault".Translate(), null, 0.25f))
        {
            codexSettings.repairCostFactor = CodexRimperialisModSettings.DefaultRepairCostFactor;
        }
        scrollViewHeight += ListingHeightIncreaseGap;

        listingStandard.End();
        Widgets.EndScrollView();
    }
}
