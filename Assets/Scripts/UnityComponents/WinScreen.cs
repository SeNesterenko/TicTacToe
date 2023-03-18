using Services;
using UnityEngine;
using UnityEngine.UI;

namespace UnityComponents
{
    public class WinScreen : Screen
    {
        [SerializeField] private Text _text;
    
        public void SetWinner(SignType winnerSignSign)
        {
            _text.text = winnerSignSign switch
            {
                SignType.Cross => "Cross win",
                SignType.Ring => "Ring win",
                _ => _text.text
            };
        }
    }
}