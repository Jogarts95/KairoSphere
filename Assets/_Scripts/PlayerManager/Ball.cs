using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Ball : MonoBehaviour
{
    [Header("Movements Settings")]
    [SerializeField] private float velocity = 3.5f;
    [SerializeField] private bool canMove = true;

    [Header("Death Settings")]
    [SerializeField] private Animator animator;
    [SerializeField] private float deathDelay = 2.5f;
    [SerializeField] private GameObject youLoseUI;
    [SerializeField] private Renderer meshRenderer;
    [SerializeField] private string dissolveProperty = "_DissolveAmount";
    [SerializeField] private Material dissolveMaterialTemplate;

    private Rigidbody rb;
    private bool isDead = false;
    private Material dissolveMaterial;
    private Material dissolveMaterialInstance;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        if (meshRenderer != null)
        {
            dissolveMaterial = meshRenderer.material;
            dissolveMaterial.SetFloat(dissolveProperty, 0f);
        }
    }

    protected virtual void Update()
    {
        if (!canMove || isDead) return;
        {
            float axisH = Input.GetAxis("Horizontal");
            float axisV = Input.GetAxis("Vertical");

            this.GetComponent<Rigidbody>().AddForce(new Vector3(axisH * this.velocity, 0f, axisV * this.velocity));
        }

    }

    public virtual void KillPlayer()
    {
        if (isDead) return;
        isDead = true;
        canMove = false;

        rb.linearVelocity = Vector3.zero;
        rb.isKinematic = true;

        Collider col = GetComponent<Collider>();
        if (col != null) col.enabled = false;

        // Aplicar material de disolución
        if (meshRenderer != null && dissolveMaterialTemplate != null)
        {
            dissolveMaterialInstance = new Material(dissolveMaterialTemplate); // copia nueva
            dissolveMaterialInstance.SetFloat(dissolveProperty, 0f);           // inicia en 0
            meshRenderer.material = dissolveMaterialInstance;
        }

        StartCoroutine(DissolveAndShowLose());
    }

    private IEnumerator DissolveAndShowLose()
    {
        float timer = 0f;

        if (meshRenderer == null || dissolveMaterialInstance == null)
        {
            Debug.LogWarning("No se encontró MeshRenderer o Dissolve Material.");
            ShowLoseMessage();
            yield break;
        }

        while (timer < deathDelay)
        {
            float t = timer / deathDelay;
            dissolveMaterialInstance.SetFloat(dissolveProperty, t);
            timer += Time.deltaTime;
            yield return null;
        }

        dissolveMaterialInstance.SetFloat(dissolveProperty, 1f);
        meshRenderer.enabled = false; // o gameObject.SetActive(false);
        ShowLoseMessage();
    }


    private void ShowLoseMessage()
    {
        if (youLoseUI != null)
        {
            youLoseUI.SetActive(true);
        }
    }

}