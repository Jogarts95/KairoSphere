using UnityEngine;

public class DeepLinkManager : MonoBehaviour
{
    public static string walletAddress;

    void Awake()
    {
        Application.deepLinkActivated += OnDeepLinkActivated;

        // Si se inició con un deep link directamente
        if (!string.IsNullOrEmpty(Application.absoluteURL))
        {
            OnDeepLinkActivated(Application.absoluteURL);
        }

        DontDestroyOnLoad(this.gameObject); // para mantenerlo entre escenas si lo deseas
    }

    void OnDeepLinkActivated(string url)
    {
        Debug.Log("Deep link recibido: " + url);

        if (url.Contains("wallet-connected"))
        {
            string[] parts = url.Split("address=");
            if (parts.Length > 1)
            {
                walletAddress = parts[1];
                PlayerPrefs.SetString("wallet", walletAddress);
                Debug.Log("Wallet address guardada: " + walletAddress);
            }
        }
    }
}
