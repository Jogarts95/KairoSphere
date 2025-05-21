using UnityEngine;
using UnityEngine.UI;

public class UI_Controller : MonoBehaviour
{
    [Header("Referencias de UI")]
    [SerializeField] private Text txtNameLevel;
    [SerializeField] private Text txtRecolectable;

    [Header("Paneles de mensaje")]
    [SerializeField] private LosePanel losePanel;
    [SerializeField] private WinPanel winPanel;


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
        if (sceneController == null)
            sceneController = Scene_Controller.Instance;

        losePanel.Show(
            "¡Has perdido!",
            sceneController.RechargedCurrentScene,
            sceneController.BackToMenu
        );
    }


    public void ShowMessageLevel()
    {
        winPanel.Show();

        GameObject ball = GameObject.FindWithTag("Player");
        if (ball != null)
        {
            ball.GetComponent<Rigidbody>().isKinematic = true;
            ball.GetComponent<Ball>().enabled = false;
        }

        if (sceneController == null)
            sceneController = Scene_Controller.Instance;

        winPanel.Init(sceneController.ChargeNextLevel, sceneController.BackToMenu);
    }


}

