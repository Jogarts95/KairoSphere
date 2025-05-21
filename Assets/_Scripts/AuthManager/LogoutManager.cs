using UnityEngine;
using UnityEngine.SceneManagement;

public class LogoutManager : MonoBehaviour
{
    public void OnLogout()
    {
        PlayerPrefs.DeleteKey("username");
        PlayerPrefs.DeleteKey("wallet"); // si estás guardando la dirección
        SceneManager.LoadScene("AuthScene");
    }
}
