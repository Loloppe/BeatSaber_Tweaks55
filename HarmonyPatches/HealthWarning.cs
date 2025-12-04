using System;
using System.Reflection;
using HarmonyLib;

namespace Tweaks55.HarmonyPatches {
	[HarmonyPatch(typeof(HealthWarningScenesTransitionSetupDataSO), nameof(HealthWarningScenesTransitionSetupDataSO.Init))]
	static class PatchHealthWarning {
		[HarmonyPriority(int.MinValue)]
		static void Prefix(ref HealthWarningSceneSetupData healthWarningSceneSetupData) {
			if(Config.Instance.disableHealthWarning) {
				healthWarningSceneSetupData.taskCompletionSource.SetResult(true);
			}
		}
		static Exception Cleanup(MethodBase original, Exception ex) => Plugin.PatchFailed(original, ex);
	}
}
