using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    private Animator animator;
    private SpriteRenderer spriteRenderer;
    private Color originalColor;

    public float health = 100f;

    [Tooltip("Flash color (default: red)")]
    public Color flashColor = Color.red;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        originalColor = spriteRenderer.color;
    }

    private void Update()
    {
        if (health <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    public void DealDamage(float damage)
    {
        health -= damage;
        animator.SetTrigger("damage");
        Flash();
    }

    public void Flash()
    {
        StopCoroutine(FlashRoutine());
        StartCoroutine(FlashRoutine());
    }

    private IEnumerator FlashRoutine()
    {
        int numberOfFlashes = 3;
        float flashInterval = 0.15f;
        // Flash specified number of times
        for (int i = 0; i < numberOfFlashes; i++)
        {
            // Change to flash color
            spriteRenderer.color = flashColor;
            yield return new WaitForSeconds(flashInterval);

            // Revert to original color
            spriteRenderer.color = originalColor;
            yield return new WaitForSeconds(flashInterval);
        }

        // Ensure final color is original
        spriteRenderer.color = originalColor;
    }
}
