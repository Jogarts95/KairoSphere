using UnityEngine;
using UnityEngine.UI;

public class UI_Controller : MonoBehaviour
{
    public void UpdateInterface(string nameLevel, int currentsQuantitysRecolectables, int currentsQuantitysTotalRecolectables)
    {
        GameObject.Find("TXTnameLevel").GetComponent<Text>().text = nameLevel;
        GameObject.Find("TXTrecolectable").GetComponent<Text>().text = currentsQuantitysRecolectables + "/" + currentsQuantitysTotalRecolectables + " recolectables ";
    }

    public void ShowMessageLose()
    {
        this.transform.Find("MessageLose").gameObject.SetActive(true);
    }

    public void ShowMessageLevel() 
    {
        this.transform.Find("MessageWin").gameObject.SetActive(true);
    }
}
