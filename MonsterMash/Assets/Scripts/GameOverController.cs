using UnityEngine;

public class GameOverController : MonoBehaviour
{
    private MonsterScript monster;
    private int bestScore = 7000;
    private float bestTime = 60f * 4.5f; //minutes
    private int bestLifes;

    private Rank rank;
    public enum Rank
    {
        S,
        A_Plus,
        A_Minus,
        B_Plus,
        B_Minus,
        C_Plus,
        C_Minus,
        D_Plus,
        D_Minus
    }

    private void Awake()
    {
        monster = GameController.instance.pumpkinMan.gameObject.GetComponent<MonsterScript>();
        bestLifes = monster.initLifes;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player") && !GameController.instance.GameOver)
        {
            GameController.instance.GameOver = true;

            CalculateRank();
            StartCoroutine(GameController.instance.GameOverSequence(rank));
        }
    }

    void CalculateRank()
    {
        int score = GameController.instance.Score;
        float time = GameController.instance.CurrentTime;
        int lifes = monster.GetLifes();

        if(score >= bestScore && time <= bestTime) //A perfect run
        {
            if(lifes == bestLifes)
            {
                rank = Rank.S;
            }
            else
            {
                rank = Rank.A_Plus;
            }
        }
        else if(score < bestScore && time <= bestTime)
        {
            if(lifes == bestLifes)
            {
                rank = Rank.A_Plus;
            }
            if(lifes == bestLifes - 1)
            {
                rank = Rank.A_Minus;
            }
            if(lifes == bestLifes - 2)
            {
                rank = Rank.B_Plus;
            }
        }
        else if(score < bestScore && time > bestTime)
        {
            if (lifes == bestLifes)
            {
                rank = Rank.B_Minus;
            }
            if (lifes == bestLifes - 1)
            {
                rank = Rank.C_Plus;
            }
            if (lifes == bestLifes - 2)
            {
                rank = Rank.C_Minus;
            }
        }
        
        if(score < bestScore / 2 && time > bestTime * 2)
        {
            if(lifes == bestLifes)
            {
                rank = Rank.D_Plus;
            } 
            else
            {
                rank = Rank.D_Minus;
            }
        }
    }
}
