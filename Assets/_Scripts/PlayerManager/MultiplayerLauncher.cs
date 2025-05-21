using Unity.Netcode;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MultiplayerLauncher : MonoBehaviour
{
    public string gameSceneName = "Level_1";

    public void StartAsHost()
    {
        NetworkManager.Singleton.StartHost();
        NetworkManager.Singleton.SceneManager.LoadScene(gameSceneName, LoadSceneMode.Single);
    }

    public void StartAsClient()
    {
        NetworkManager.Singleton.StartClient();
    }
}
