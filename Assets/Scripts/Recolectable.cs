using System;
using UnityEngine;

public class Recolectable : MonoBehaviour
{
    
    private void Update() 
    {
        this.transform.Rotate(20f * Time.deltaTime, 20f * Time.deltaTime, 20f * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other) 
    {
        this.Recolectar();
    }

    private void Recolectar()
    {
        GameObject.FindObjectOfType<Level_Controller>().RegisterRecolection();
        Destroy(this.gameObject);
    }

}
