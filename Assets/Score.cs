using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Score : MonoBehaviour
{
    public TMP_Text myScoreText;
    public static int scoreNum = 0;



    void Start()
    {
        myScoreText = GetComponent<TMP_Text>();
    }

    private void Update()
    {
        myScoreText.text = "" + scoreNum;
    }


}
