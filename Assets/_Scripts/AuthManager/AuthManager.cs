using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AuthManager : MonoBehaviour
{
    public InputField usernameInput;

    private string savedUsernameKey = "username";

    void Start()
    {
        // Si ya hay usuario, ir directo al menú
        if (PlayerPrefs.HasKey(savedUsernameKey))
        {
            SceneManager.LoadScene("Main_Menu");
        }
    }

    public void OnLogin()
    {
        string name = usernameInput.text;
        if (!string.IsNullOrEmpty(name))
        {
            PlayerPrefs.SetString(savedUsernameKey, name);
            SceneManager.LoadScene("Main_Menu");
        }
    }

    public void ConnectWallet()
    {
        Application.OpenURL("http://localhost:3000/connect"); // reemplaza con tu web companion
    }
}
