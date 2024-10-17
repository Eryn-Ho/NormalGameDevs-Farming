using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneHandler : MonoBehaviour
{
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void Quit()
    {
        // quit application (not editor)
        Application.Quit();

        // stop editor play mode
#if UNITY_EDITOR
        UnityEditor.EditorApplication.ExitPlaymode();
#endif
    }
}