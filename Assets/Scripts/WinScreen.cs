using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WinScreen : Screen
{
    public Text Text;
    
    public void SetWinner(SignType winnerSignSign)
    {
        Text.text = winnerSignSign switch
        {
            SignType.Cross => "Cross win",
            SignType.Ring => "Ring win",
            _ => Text.text
        };
    }

    public void OnRestartClicked()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}