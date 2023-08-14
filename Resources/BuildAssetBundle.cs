using UnityEditor;
using System.IO;

public class CreateAssetBundles
{
    [MenuItem("Assets/Build TaleSpire Asset Bundles")]
    static void BuildAllAssetBundles()
    {
        string assetBundleDirectory = "Assets/AssetBundles";
        if (!Directory.Exists(assetBundleDirectory))
        {
            Directory.CreateDirectory(assetBundleDirectory);
        }
        BuildPipeline.BuildAssetBundles(assetBundleDirectory, BuildAssetBundleOptions.None, BuildTarget.StandaloneWindows);
        foreach(string assetBundle in System.IO.Directory.EnumerateFiles(assetBundleDirectory, "*."))
        {
            if (assetBundle!=assetBundleDirectory+"\\AssetBundles")
            {
                try
                {
                    Directory.CreateDirectory(assetBundleDirectory + "/CustomData/Minis/" + Path.GetFileNameWithoutExtension(assetBundle));
                    File.Move(assetBundle, assetBundleDirectory + "/CustomData/Minis/" + Path.GetFileNameWithoutExtension(assetBundle) + "/" + Path.GetFileNameWithoutExtension(assetBundle));
                    File.Delete(assetBundle + ".manifest");
                }
                catch (System.Exception) {; }
            }
        }
    }
}