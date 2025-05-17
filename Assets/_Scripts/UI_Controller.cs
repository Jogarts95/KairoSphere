using UnityEngine;
using UnityEngine.UI;

public class UI_Controller : MonoBehaviour
{
    [Header("Referencias de UI")]
    [SerializeField] private Text txtNameLevel;
    [SerializeField] private Text txtRecolectable;

    [Header("Paneles de mensaje")]
    [SerializeField] private GameObject messageLose;
    [SerializeField] private GameObject messageWin;

    [Header("Botones del mensaje de victoria")]
    [SerializeField] private Button btnNextLevel;
    [SerializeField] private Button btnBackToMenu;

    private Scene_Controller sceneController;

    private void Awake()
    {
        // Asumimos que Scene_Controller es único
        sceneController = Scene_Controller.Instance;
    }

    public void UpdateInterface(string nameLevel, int currentsQuantitysRecolectables, int currentsQuantitysTotalRecolectables)
    {
        txtNameLevel.text = nameLevel;
        txtRecolectable.text = $"{currentsQuantitysRecolectables}/{currentsQuantitysTotalRecolectables} recolectables";
    }

    public void ShowMessageLose()
    {
        messageLose.SetActive(true);
    }

    public void ShowMessageLevel()
{
    messageWin.SetActive(true);

     GameObject ball = GameObject.FindWithTag("Player");
    if (ball != null)
    {
        ball.GetComponent<Rigidbody>().isKinematic = true;
        ball.GetComponent<Ball>().enabled = false;
    }

    if (sceneController == null)
        sceneController = Scene_Controller.Instance;

    // Intentamos reasignar si por algún motivo están vacíos
    if (btnNextLevel == null)
        btnNextLevel = messageWin.transform.Find("btnNextLevel")?.GetComponent<Button>();

    if (btnBackToMenu == null)
        btnBackToMenu = messageWin.transform.Find("btnBackToMenu")?.GetComponent<Button>();

    if (btnNextLevel != null)
    {
        btnNextLevel.onClick.RemoveAllListeners();
        btnNextLevel.onClick.AddListener(sceneController.ChargeNextLevel);
    }
    else
    {
        Debug.LogWarning("btnNextLevel no encontrado al activar MessageWin");
    }

    if (btnBackToMenu != null)
    {
        btnBackToMenu.onClick.RemoveAllListeners();
        btnBackToMenu.onClick.AddListener(sceneController.BackToMenu);
    }
    else
    {
        Debug.LogWarning("btnBackToMenu no encontrado al activar MessageWin");
    }
}

}

