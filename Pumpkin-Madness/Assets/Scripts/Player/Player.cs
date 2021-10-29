using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField] private int maxHealth;
    public int currentHealth;
    private bool Enemy;
    private bool isInvincible = false;
    [SerializeField] private float invincibilityDurationSeconds;
    [SerializeField] private GameObject gameOverTitle;
    public HealthBarID HealthBarID;
    public Sprite Transparent;
    private SpriteRenderer spriteRenderer;
    public Sprite NotTransparent;
    private GameController gameController;

    private void Awake()
    {
        gameController = GameObject.FindObjectOfType<GameController>();
    }

    void Start()
    {
        currentHealth = maxHealth;
        HealthBarID.SetMaxHealth(maxHealth);
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    public void TakeDamage(int damage)
    {
        if(isInvincible) return;
        Debug.Log($"Player lost {damage} health!");

        currentHealth -= damage;
        HealthBarID.SetHealth(currentHealth);
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
            Destroy(GameObject.FindGameObjectWithTag("Weapon"));
            ShowGameOver();
        }
        MethodThatTriggersInvulnerability();
    }

    private void ShowGameOver()
    {
        gameOverTitle.SetActive(true);
        gameController.LoadSceneWithDelay();
    }

    private void LoadTitleScreen() => SceneManager.LoadScene("TitleScreen");
    
    void MethodThatTriggersInvulnerability()
    {
        if (!isInvincible)
        {
            StartCoroutine(BecomeTemporarilyInvincible());
        }
    }

    private IEnumerator BecomeTemporarilyInvincible()
    {
        Debug.Log("Player turned invincible!");
        isInvincible = true;

        var temp = 0;
        for (float i = 0; i < invincibilityDurationSeconds; i += 0.2f)
        {
            if (temp == 2)
            {
                temp = 0;
                spriteRenderer.sprite = NotTransparent;
            }
            else
            {
                temp++;
                spriteRenderer.sprite = Transparent;
            }
            yield return new WaitForSeconds(0.2f);
        }

        spriteRenderer.sprite = NotTransparent;
        Debug.Log("Player is no longer invincible!");
        isInvincible = false;
    }

    private void ScaleModelTo(Vector3 scale)
    {
        gameObject.transform.localScale = scale;
    }
}
