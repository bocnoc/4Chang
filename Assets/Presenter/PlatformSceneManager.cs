using UnityEngine;
using UnityEngine.SceneManagement;

public static class PlatformSceneManager
{
    public enum Platform
    {
        PC,
        Mobile
    }

    public static Platform GetCurrentPlatform()
    {
#if UNITY_ANDROID || UNITY_IOS
        return Platform.Mobile;
#else
        return Platform.PC;
#endif
    }

    public static void LoadMainScene()
    {
        Platform platform = GetCurrentPlatform();
        string sceneName = GetSceneName("Mainscene", platform);
        LoadScene(sceneName);
    }

    public static void LoadCountingScene()
    {
        Platform platform = GetCurrentPlatform();
        string sceneName = GetSceneName("CountingScene", platform);
        LoadScene(sceneName);
    }

    public static void LoadFlirtingScene()
    {
        Platform platform = GetCurrentPlatform();
        string sceneName = GetSceneName("FlirtingScene", platform);
        LoadScene(sceneName);
    }

    private static string GetSceneName(string baseName, Platform platform)
    {
        if (platform == Platform.Mobile)
        {
            return baseName + "-mobile";
        }
        return baseName;
    }

    private static void LoadScene(string sceneName)
    {
        Debug.Log($"Loading scene: {sceneName} for platform: {GetCurrentPlatform()}");
        SceneManager.LoadScene(sceneName);
    }

    // Method để test trong editor
    public static void LoadSceneForced(string sceneName)
    {
        Debug.Log($"Force loading scene: {sceneName}");
        SceneManager.LoadScene(sceneName);
    }
}
