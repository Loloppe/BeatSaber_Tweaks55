using System;
using System.Reflection;
using HarmonyLib;

namespace Tweaks55.HarmonyPatches {
	[HarmonyPatch(typeof(HealthWarningViewController), nameof(HealthWarningViewController.DidActivate))]
	static class PatchHealthWarning {
		static void Postfix(HealthWarningViewController __instance) {
			if(Config.Instance.disableHealthWarning)
				SharedCoroutineStarter.instance.StartCoroutine(__instance.DismissHealthAndSafety());
		}
		static Exception Cleanup(MethodBase original, Exception ex) => Plugin.PatchFailed(original, ex);
	}
}
