using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public GameManager gameManager;
    public TMPro.TMP_Text Score;
    public string format = "";

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Score.SetText(string.Format(format, gameManager.score));
    }
}
