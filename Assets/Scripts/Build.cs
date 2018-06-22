using UnityEditor;

class Build
{
     static void PerformBuild ()
     {
         string[] scenes = { "Assets/_Scenes/Main.unity" };
         EditorUserBuildSettings.SwitchActiveBuildTarget(BuildTargetGroup.WebGL, BuildTarget.WebGL);
         BuildPipeline.BuildPlayer(scenes, "build/web", BuildTarget.WebGL, BuildOptions.None);
     }
}