using System.Collections;
using System.Collections.Generic;
using UnityEditor.Callbacks;
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

    private Rigidbody rb;
    private bool isDead = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (!canMove || isDead) return;
        {
            float axisH = Input.GetAxis("Horizontal");
            float axisV = Input.GetAxis("Vertical");

            this.GetComponent<Rigidbody>().AddForce(new Vector3(axisH * this.velocity, 0f, axisV * this.velocity));
        }

    }

    public void KillPlayer()
    {
        if (isDead) return;
        isDead = true;
        canMove = false;

        if (animator != null)
        {
            animator.SetTrigger("Die");
        }

        rb.linearVelocity = Vector3.zero;
        rb.isKinematic = true;

        Collider col = GetComponent<Collider>();
        if (col != null) col.enabled = false;

        Invoke(nameof(ShowLoseMessage), deathDelay);
    }

    private void ShowLoseMessage()
    {
        if (youLoseUI != null)
        {
            youLoseUI.SetActive(true);
        }
    }

}