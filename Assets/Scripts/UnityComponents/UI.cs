using UnityEngine;

namespace UnityComponents
{
    public class UI : MonoBehaviour
    {
        public WinScreen WinScreen => _winScreen;
        public LoseScreen LoseScreen => _loseScreen;
    
        [SerializeField] private WinScreen _winScreen;
        [SerializeField] private LoseScreen _loseScreen;
    }
}