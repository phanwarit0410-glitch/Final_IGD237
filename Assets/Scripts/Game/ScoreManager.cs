using System;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance { get; private set; }

    [Header("Score Settings")]
    [SerializeField] private int correctOrderPoints = 100;
    [SerializeField] private int wrongOrderPenalty = 20;
    [SerializeField] private int rewardPerCorrectOrder = 50;

    public int CurrentScore { get; private set; }
    public int TotalMoney { get; private set; }
    public int CorrectOrders { get; private set; }
    public int WrongOrders { get; private set; }

    public event Action OnScoreChanged;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }

    public void AddCorrectOrder()
    {
        CurrentScore += correctOrderPoints;
        TotalMoney += rewardPerCorrectOrder;
        CorrectOrders++;

        OnScoreChanged?.Invoke();
        Debug.Log("Correct Order! Score: " + CurrentScore);
    }

    public void AddWrongOrder()
    {
        CurrentScore = Mathf.Max(0, CurrentScore - wrongOrderPenalty);
        WrongOrders++;

        OnScoreChanged?.Invoke();
        Debug.Log("Wrong Order! Score: " + CurrentScore);
    }

    public void ResetScore()
    {
        CurrentScore = 0;
        TotalMoney = 0;
        CorrectOrders = 0;
        WrongOrders = 0;

        OnScoreChanged?.Invoke();
    }

    private void OnDestroy()
    {
        if (Instance == this)
        {
            Instance = null;
        }
    }
}