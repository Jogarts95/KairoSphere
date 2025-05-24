using UnityEngine;

public class DeepLinkManager : MonoBehaviour
{
    public static string walletAddress;

    void Awake()
    {
        Debug.Log("🔥 DeepLinkManager.cs está vivo (Awake)");
        Debug.Log("🟡 DeepLinkManager iniciado");

        Application.deepLinkActivated += OnDeepLinkActivated;

        if (!string.IsNullOrEmpty(Application.absoluteURL))
        {
            Debug.Log("🟢 Se inició con deep link directo: " + Application.absoluteURL);
            OnDeepLinkActivated(Application.absoluteURL);
        }
        else
        {
            Debug.Log("🔵 No se detectó deep link al inicio.");
        }

        DontDestroyOnLoad(this.gameObject);
    }

    void OnDeepLinkActivated(string url)
    {
        Debug.Log("🟠 Deep link recibido: " + url);

        if (url.Contains("wallet-connected"))
        {
            string[] parts = url.Split("address=");

            if (parts.Length > 1)
                {
                    walletAddress = parts[1];
                    PlayerPrefs.SetString("wallet", walletAddress);
                    PlayerPrefs.Save(); // <--- ✅ ESTA LÍNEA ES CLAVE
                    Debug.Log("✅ Wallet guardada en PlayerPrefs: " + walletAddress);
                }
            else
            {
                Debug.LogWarning("⚠️ URL no contiene una dirección válida.");
            }
        }
        else
        {
            Debug.LogWarning("⚠️ Deep link recibido, pero no es de tipo 'wallet-connected'.");
        }
    }
}
