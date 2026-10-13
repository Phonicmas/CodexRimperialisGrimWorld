using Core40k;
using HarmonyLib;
using Verse;

namespace CodexRimperialis;

public class CodexRimperialisMod : CoreMod
{
    public static string CurrentVersion;

    public static Harmony harmony;

    private static CodexRimperialisModSettings settings;
    public static CodexRimperialisModSettings CodexSettings => settings;
    public override ModSettings Settings => settings;

    private readonly ModSettingTab_CodexMain codexMainSettings = new();

    public CodexRimperialisMod(ModContentPack content) : base(content)
    {
        settings = GetSettings<CodexRimperialisModSettings>();
        CurrentVersion = content.ModMetaData.ModVersion;

        harmony = new Harmony("Phonicmas.CodexRimperialis");
        harmony.PatchAll();
    }

    public override void InitializeTabs()
    {
        var mainTab = new TabRecord("BEWH.ModSettings.TabMain".Translate(), delegate
        {
            currentSettingTab = codexMainSettings;
        }, () => currentSettingTab == codexMainSettings);
        tabs.Add(mainTab);

        currentSettingTab = codexMainSettings;
        base.InitializeTabs();
    }

    public override string SettingsCategory()
    {
        return "BEWH.CodexRimperialis.ModSettings.ModName".Translate(CurrentVersion);
    }
}
