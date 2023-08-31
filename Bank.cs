using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Bank : MonoBehaviour
{

    [SerializeField] int startBalance = 150;
    [SerializeField] int currentBalance;
    
    public int CurrentBalance { get { return currentBalance; } }

    [SerializeField] TextMeshProUGUI displayBalance;

    void Awake()
    {
        currentBalance = startBalance;
        UpdateDisplay();
    }


   public void Deposit(int amount)
   {
    currentBalance += Mathf.Abs(amount);
    UpdateDisplay();
   }

   public void Withdraw(int amount)
   {
    currentBalance -= Mathf.Abs(amount);
    UpdateDisplay();
    if (currentBalance < 0)
    {
        ReloadScene();
    }

   }

   void ReloadScene()
   {
    Scene currentScene = SceneManager.GetActiveScene();
    SceneManager.LoadScene(currentScene.buildIndex);
   }

   void UpdateDisplay()
   {
    displayBalance.text = "Gold: " + currentBalance;
   }
}
