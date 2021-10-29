using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    private RandomEnemySpawn randomEnemySpawn;
    private const float SecondsBeforeReloadToTitleScreen = 3f;

    private void Awake()
    {
        randomEnemySpawn = GetComponent<RandomEnemySpawn>();
    }

    private void Update()
    {
        randomEnemySpawn.SpawnEnemies(true);
    }

    internal void LoadSceneWithDelay() => Invoke(nameof(ReloadTitleScreen), SecondsBeforeReloadToTitleScreen);

    private void ReloadTitleScreen() => SceneManager.LoadScene("TitleScreen");
}
