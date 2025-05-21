using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class BallVisualController : MonoBehaviour
{
    [Header("Movements Settings")]
    [SerializeField] private float velocity = 3.5f;

    [Header("Death Settings")]
    [SerializeField] private Animator animator;
    [SerializeField] private float deathDelay = 2.5f;
    [SerializeField] private GameObject youLoseUI;
    [SerializeField] private Renderer meshRenderer;
    [SerializeField] private string dissolveProperty = "_DissolveAmount";
    [SerializeField] private Material dissolveMaterialTemplate;

    private Rigidbody rb;
    private Material dissolveMaterialInstance;
    public bool IsDead { get; private set; }

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        IsDead = false;

        if (meshRenderer != null)
        {
            meshRenderer.material.SetFloat(dissolveProperty, 0f);
        }
    }

    public void Move(Vector2 direction)
    {
        if (IsDead) return;

        Vector3 force = new Vector3(direction.x * velocity, 0f, direction.y * velocity);
        rb.AddForce(force);
    }

    public void Kill()
    {
        if (IsDead) return;
        IsDead = true;

        rb.linearVelocity = Vector3.zero;
        rb.isKinematic = true;

        Collider col = GetComponent<Collider>();
        if (col != null) col.enabled = false;

        if (meshRenderer != null && dissolveMaterialTemplate != null)
        {
            dissolveMaterialInstance = new Material(dissolveMaterialTemplate);
            dissolveMaterialInstance.SetFloat(dissolveProperty, 0f);
            meshRenderer.material = dissolveMaterialInstance;
        }

        StartCoroutine(DissolveAndShowLose());
    }

    private IEnumerator DissolveAndShowLose()
    {
        float timer = 0f;

        if (meshRenderer == null || dissolveMaterialInstance == null)
        {
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
        meshRenderer.enabled = false;

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
