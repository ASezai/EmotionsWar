using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    public static float Healt = 100f;
    public static float MoveSpeed = 3f;
    public static int ScoreValue = 100;
    public static int Score = 0;

    public static void UpdateScore(int s)
    {
        Score += s;
        Debug.Log("Stats:"+Score);
        if (Score % 300 == 0)
        {
            Healt += 100f;
            Debug.Log(Healt);
        }
        if (Score % 4000 == 0 && MoveSpeed < 17)
        {
            MoveSpeed += 1f;
        }
    }
}