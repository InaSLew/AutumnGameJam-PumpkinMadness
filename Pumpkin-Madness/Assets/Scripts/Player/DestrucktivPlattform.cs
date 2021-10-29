using UnityEngine;

public class DestrucktivPlattform : MonoBehaviour
{
    private const float CoolDown = 4f;

    private void EnablePlatform()
    {
        gameObject.SetActive(true);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
            Invoke(nameof(DisablePlatform), CoolDown);
    }

    private void DisablePlatform()
    {
        gameObject.SetActive(false);
        Invoke(nameof(EnablePlatform), CoolDown);
    }
}
