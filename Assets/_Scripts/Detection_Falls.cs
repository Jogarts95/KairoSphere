using UnityEngine;

public class Detection_Falls : MonoBehaviour
{

    public float destroyDelay = 0.5f;

    private void OnTriggerEnter(Collider other) 
    {
        if (Level_Controller.levelComplete) return;

        UI_Controller ui = FindObjectOfType<UI_Controller>();
        ui.ShowMessageLose();

        Destroy(other.gameObject, destroyDelay);
    }
}
