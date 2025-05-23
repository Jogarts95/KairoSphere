using UnityEngine;
using UnityEngine.SceneManagement;

public class Level_Controller : MonoBehaviour
{
    private int currentQuantityRecolectables;
    private int levelTotalRecolectable;

    public static bool levelComplete = false;

    private void Start() 
    {
        levelComplete = false;
        this.currentQuantityRecolectables = 0;
        this.levelTotalRecolectable = GameObject.FindObjectsOfType<Recolectable>().Length;

        GameObject.FindObjectOfType<UI_Controller>().UpdateInterface(SceneManager.GetActiveScene().name, this.currentQuantityRecolectables, this.levelTotalRecolectable);
    }

    public void RegisterRecolection()
    {
        this.currentQuantityRecolectables++;
        GameObject.FindObjectOfType<UI_Controller>().UpdateInterface(SceneManager.GetActiveScene().name, this.currentQuantityRecolectables, this.levelTotalRecolectable);

        if (this.currentQuantityRecolectables >= this.levelTotalRecolectable)
        {
            levelComplete = true;
            GameObject.FindObjectOfType<UI_Controller>().ShowMessageLevel();
        }
    }
}
