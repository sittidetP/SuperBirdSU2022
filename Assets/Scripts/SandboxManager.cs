using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SandboxManager : MonoBehaviour
{
    public int blueScore = 0;
    public int redScore = 0;

    public myGoal blueGoal;
    public myGoal redGoal;

    public Text textScoreBoard;

    private void Update()
    {
        blueScore = blueGoal.score;
        redScore = redGoal.score;
        textScoreBoard.text = redScore + " - " + blueScore;
    }
}
