using UnityEngine;

public class Detection_Falls : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) 
    {
        GameObject.FindObjectOfType<UI_Controller>().ShowMessageLose();
    }
}
