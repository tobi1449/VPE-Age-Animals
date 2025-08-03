using HarmonyLib;
using VanillaPsycastsExpanded.Chronopath;
using VEF.Abilities;
using Verse;

namespace VPE_Age_Animals
{
    [StaticConstructorOnStartup]
    public static class Main
    {
        static Main()
        {
            var harmony = new Harmony("tobi.VPE.Age.Animals");
            harmony.PatchAll();
            Log.Message("VPE Age Animals loaded successfully!");
        }
    }

    [HarmonyPatch(typeof(AbilityExtension_Age), nameof(AbilityExtension_Age.CanApplyOn))]
    public static class AgePatch
    {
        static void Postfix(LocalTargetInfo target, Ability ability, bool throwMessages, ref bool __result)
        {
            if (__result)
                return;

            __result = target.Thing is Pawn pawn && pawn.IsAnimal;
        }
    }
}