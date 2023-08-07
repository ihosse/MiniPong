using UnityEngine;
using System.Collections;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] 
    private TextMeshProUGUI player1ScoreText;

    [SerializeField] 
    private TextMeshProUGUI player2ScoreText;

    [SerializeField] 
    private Rigidbody2D ball; 

    [SerializeField] 
    private Transform player1;

    [SerializeField] 
    private Transform player2;

    [SerializeField] 
    private int maxPoints = 10;

    private int player2Score = 0;
    private int player1Score = 0;

    public enum Player { player1, player2 }

    void Start()
    {
        Invoke("ResetGame",3);
    }

    private void ResetGame()
    {
        ResetBall();
        ball.gameObject.SetActive(true);
        
        player1.transform.position = new Vector2(player1.transform.position.x, 0);
        player2.transform.position = new Vector2(player2.transform.position.x, 0);

        player1Score = player2Score = 0;
        ShowPoints();
    }

    public void ResetBall() 
    {
        ball.transform.position = Vector2.zero;
    }

    private void ShowPoints() 
    {
        player1ScoreText.text = player1Score.ToString();
        player2ScoreText.text = player2Score.ToString();
    }

    public void AddPoint(Player player) 
    {
        if(player == Player.player1) 
        {
            player1Score++;
        }
        else 
        {
            player2Score++;
        }

        ShowPoints();

        if (player1Score >= maxPoints || player2Score >= maxPoints) 
        {
            ball.gameObject.SetActive(false);
            Invoke("ResetGame", 1);
        }
    }
}
