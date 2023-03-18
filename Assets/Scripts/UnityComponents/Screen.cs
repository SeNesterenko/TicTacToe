using UnityEngine;
using UnityEngine.SceneManagement;

namespace UnityComponents
{
    public class Screen : MonoBehaviour
    {
        public void Show(bool state)
        {
            gameObject.SetActive(state);
        }
        
        public void OnRestartClicked()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}