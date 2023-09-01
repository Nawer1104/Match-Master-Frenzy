using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public ListTargets ListTargets;

    public List<Level> levels;

    private int startIndex = 0;

    private int currentIndex;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }

        currentIndex = startIndex;

        levels[currentIndex].gameObject.SetActive(true);
    }

    public int GetCurrentIndex()
    {
        return currentIndex;
    }

    private void Update()
    {
        if (levels[currentIndex].allBlocks.Count == 0)
        {
            currentIndex += 1;

            if (currentIndex == 3)
            {
                ReSetGame();

                currentIndex = 0;
            }

            levels[currentIndex].gameObject.SetActive(true);
        }
    }

    public void ReSetGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
