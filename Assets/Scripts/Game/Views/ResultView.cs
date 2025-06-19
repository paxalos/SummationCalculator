using UnityEngine;
using TMPro;

namespace Game
{
    public class ResultView : MonoBehaviour
    {
        [SerializeField] private TMP_Text resultLabel;

        public void SetResultLabel(string result)
        {
            resultLabel.text = result;
        }
    }
}