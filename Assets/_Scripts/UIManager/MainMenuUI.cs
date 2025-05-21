using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class MainMenuUI : MonoBehaviour
{
    [Header("Pantalla de carga")]
    [SerializeField] private GameObject loadingPanel;

    public void StartGame()
    {
        loadingPanel.SetActive(true);
        StartCoroutine(LoadLevelAsync("Level_1")); // Cambia el nombre según tu escena
    }

    public void CloseGame()
    {
        Application.Quit();
    }

    private IEnumerator LoadLevelAsync(string sceneName)
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName);

        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }
}
