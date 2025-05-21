using UnityEngine;
using UnityEngine.UI;
using System;

public class WinPanel : MonoBehaviour
{
    [Header("Buttons")]

    [SerializeField] private Button btnNext;
    [SerializeField] private Button btnMenu;

    public void Init(Action onNextLevel, Action onBackToMenu)
    {
        if (btnNext != null)
        {
            btnNext.onClick.RemoveAllListeners();
            btnNext.onClick.AddListener(() => onNextLevel?.Invoke());
        }

        if (btnMenu != null)
        {
            btnMenu.onClick.RemoveAllListeners();
            btnMenu.onClick.AddListener(() => onBackToMenu?.Invoke());
        }
    }

    public void Show() => gameObject.SetActive(true);
    public void Hide() => gameObject.SetActive(false);
}
