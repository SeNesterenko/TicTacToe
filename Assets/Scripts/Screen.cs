using UnityEngine;

public class Screen : MonoBehaviour
{
    public void Show(bool state)
    {
        gameObject.SetActive(state);
    }
}