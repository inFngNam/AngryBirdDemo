using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    private static int _nextLevelIndex = 1;
    private Enemy[] _enemies;

    private void OnEnable()
    {
        _enemies = FindObjectsOfType<Enemy>();
    }

    private void Update()
    {
        foreach(Enemy enemy in _enemies)
        {
            if (enemy != null)
            {
                return;
            }
        }

        Debug.Log("You kill all enemies");

        if (_nextLevelIndex >= 2)
        {
            return;
        }
        else
        {
            _nextLevelIndex++;
            string nextLevelName = "Level" + _nextLevelIndex;
            SceneManager.LoadScene(nextLevelName);
        }

    }
}
