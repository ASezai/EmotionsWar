using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum cardOptions
{
    MovementSpeed = 0,
    ProjectileSpeed = 1,
    Damage = 2,
    FireRate = 3
}
public class UpgradeManager : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> UpgradeCardsLocations;
    [SerializeField]
    private Sprite[] upgradeCards;
    [SerializeField]
    private GameObject updateButtons;
    [SerializeField]
    private GameObject pauseButton;

    private int score;
    private int[] clickedCardIndex = new int[3];
    private List<int> randomNumbers;
    public GameManager gameManager;
    public bool UpgradesApplied = false;

    private cardOptions cardOptions;

    private void Update()
    {
        score = gameManager.Score;
        if (score % 1000 == 0 && !UpgradesApplied && score != 0)
        {
            ApplyUpgrades();
        }
    }

    private void ApplyUpgrades()
    {
        Time.timeScale = 0f;
        pauseButton.SetActive(false);
        randomNumbers = GenerateUniqueRandomNumbers();
        for (int i = 0; i < 3; i++)
        {
            UpgradeCardsLocations[i].GetComponent<UnityEngine.UI.Image>().sprite = upgradeCards[randomNumbers[i]];
            clickedCardIndex[i] = randomNumbers[i];
        }
        updateButtons.SetActive(true);
        UpgradesApplied = true;
    }

    private List<int> GenerateUniqueRandomNumbers()
    {
        List<int> randomNumbers = new List<int>();

        while (randomNumbers.Count < 3)
        {
            int randomNumber = Random.Range(0, upgradeCards.Length);
            if (!randomNumbers.Contains(randomNumber))
            {
                randomNumbers.Add(randomNumber);
            }
        }

        return randomNumbers;
    }

    public void UpgradeButton(int ButtonIndex)
    {
        Debug.Log("Týklandý: Buton " + ButtonIndex);
        updateButtons.SetActive(false);
        pauseButton.SetActive(true);
        cardOptions = (cardOptions)clickedCardIndex[ButtonIndex];
        switch (cardOptions)
        {
            case cardOptions.MovementSpeed:
                Debug.Log("blue kart");
                Time.timeScale = 1f;
                GameManager.UpdateScore(100);
                if (ControllerForPC.MovementSpeed < 20)
                {
                    ControllerForPhone.MovementSpeed += 0.5f;
                    ControllerForPC.MovementSpeed += 0.5f;
                }
                Debug.Log(ControllerForPC.MovementSpeed);
                UpgradesApplied = false;
                break;
            case cardOptions.ProjectileSpeed:
                Debug.Log("green kart");
                Time.timeScale = 1f;
                GameManager.UpdateScore(100);
                if (ControllerForPC.ProjectileSpeed < 81)
                {
                    ControllerForPhone.ProjectileSpeed += 3f;
                    ControllerForPC.ProjectileSpeed += 3;
                }
                Debug.Log(ControllerForPC.ProjectileSpeed);
                UpgradesApplied = false;
                break;
            case cardOptions.Damage:
                Debug.Log("red kart");
                Time.timeScale = 1f;
                GameManager.UpdateScore(100);
                Bullet.Damage += 8f;
                Debug.Log(Bullet.Damage);
                UpgradesApplied = false;
                break;
            case cardOptions.FireRate:
                Debug.Log("yelow kart");
                Time.timeScale = 1f;
                GameManager.UpdateScore(100);
                if (ControllerForPC.FireRate > 0.2f)
                {
                    ControllerForPhone.FireRate -= 0.02f;
                    ControllerForPC.FireRate -= 0.02f;
                }
                Debug.Log(ControllerForPC.FireRate);
                UpgradesApplied = false;
                break;
        }
    }
}