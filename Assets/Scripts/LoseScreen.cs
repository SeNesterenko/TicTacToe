using UnityEngine.SceneManagement;

public class LoseScreen : Screen
{
    public void OnRestartClicked()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}