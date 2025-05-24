using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class MainMenuUI : MonoBehaviour
{
    [Header("Pantalla de carga")]
    [SerializeField] private GameObject loadingPanel;

    [Header("Advertencia")]
    [SerializeField] private GameObject walletWarningPanel; // ← Agrega este panel opcional

    public void StartGame()
    {
        string wallet = PlayerPrefs.GetString("wallet", "");

        if (string.IsNullOrEmpty(wallet))
        {
            Debug.LogWarning("🚫 No se puede iniciar: Wallet no conectada.");

            if (walletWarningPanel != null)
                walletWarningPanel.SetActive(true); // ← muestra mensaje visual si existe

            return;
        }

        loadingPanel.SetActive(true);
        StartCoroutine(LoadLevelAsync("Level_1")); // Cambia si tu escena tiene otro nombre
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
