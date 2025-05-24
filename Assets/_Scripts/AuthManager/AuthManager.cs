using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class AuthManager : MonoBehaviour
{
    public TextMeshProUGUI usernameInput;
    private string savedUsernameKey = "username";
    private bool redirected = false;

    void Start()
    {
        bool hasName = PlayerPrefs.HasKey(savedUsernameKey);
        bool hasWallet = PlayerPrefs.HasKey("wallet");

        if (hasName || hasWallet)
        {
            SceneManager.LoadScene("Main_Menu");
        }
    }

    void Update()
    {
        if (!redirected && PlayerPrefs.HasKey("wallet"))
        {
            redirected = true;
            Debug.Log("Wallet detectada en tiempo real, redirigiendo...");
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
        Debug.Log("🔁 Abriendo navegador hacia companion...");
        Application.OpenURL("https://kairowalletconnect.vercel.app/connect");
    }
}
