using TMPro;
using UnityEngine;

namespace Assets.Scripts
{
    public class Score:MonoBehaviour
    {
        private TextMeshProUGUI scoreText;
        private float scoreValue;

        public float ScoreValue
        {
            get => scoreValue;
            set
            {
                scoreValue = value;
                TextUpdate();
            }
        }

        private void Start()
        {
            scoreText = GetComponent<TextMeshProUGUI>();
        }

        private void TextUpdate()
        {
            scoreText.text = scoreValue.ToString();
        }
    }
}
