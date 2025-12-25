using System;
using System.Reflection;
using HarmonyLib;

namespace Tweaks55.HarmonyPatches {
	[HarmonyPatch(typeof(HealthWarningViewController), nameof(HealthWarningViewController.Init))]
	static class PatchHealthWarning {
		static void Postfix(HealthWarningViewController __instance) {
			if(Config.Instance.disableHealthWarning)
				__instance.DismissHealthAndSafety();
		}
		static Exception Cleanup(MethodBase original, Exception ex) => Plugin.PatchFailed(original, ex);
	}
}
