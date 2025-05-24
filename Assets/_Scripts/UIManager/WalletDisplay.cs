using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WalletDisplay : MonoBehaviour
{
    public TextMeshProUGUI walletText;

    void Start()
    {
        string wallet = PlayerPrefs.GetString("wallet", "Wallet no conectada");

        // Mostrar en consola para depuración
        Debug.Log("🔍 WalletDisplay.cs -> Valor de PlayerPrefs['wallet']: " + wallet);

        // Mostrar en UI
        walletText.text = $"Wallet: {wallet}";
    }
}
