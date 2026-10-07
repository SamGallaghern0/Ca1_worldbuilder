using UnityEngine; 
using UnityEngine.SceneManagement; 
 
public class LevelLoader : MonoBehaviour
{
    [Tooltip("Name of the scene to load. It must be listed in Build Settings.")]
    [SerializeField] string nextSceneName = "level_2";

    public void LoadNextLevel()
    {
        Debug.Log("loading next Level: ");
        // ScoreManager pauses the game when the level is complete, 

        // so unpause before loading 
        Time.timeScale = 1f;
        SceneManager.LoadScene(nextSceneName);
    }
}