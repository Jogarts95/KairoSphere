using UnityEngine;
using UnityEngine.UI;
using System;

public class LosePanel : MonoBehaviour
{
    [SerializeField] private GameObject panel;
    [SerializeField] private Text txtLose;
    [SerializeField] private Button btnPlayAgain;
    [SerializeField] private Button btnBackToMenu;

    public void Show(string message, Action onRetry, Action onBackToMenu)
    {
        txtLose.text = message;
        panel.SetActive(true);

        btnPlayAgain.onClick.RemoveAllListeners();
        btnBackToMenu.onClick.RemoveAllListeners();

        btnPlayAgain.onClick.AddListener(() => onRetry?.Invoke());
        btnBackToMenu.onClick.AddListener(() => onBackToMenu?.Invoke());
    }
}
