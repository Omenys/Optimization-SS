using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static int score = 0;
    [SerializeField] Text text;


    void Update()
    {
        text.text = "Score: " + score;
    }
}
