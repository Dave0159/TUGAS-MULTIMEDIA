using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header ("Persistance Object")]
    public GameObject[] persistanceObjects;

    private void Awake()
    {
        if (Instance != null)
        {
            CleanUpAndDestroy();
            return;
        }

        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            MarkPersistanceObject();
        }
    }

    private void MarkPersistanceObject()
    {
        foreach (GameObject obj in persistanceObjects)
        {
            if (obj != null)
            {
                DontDestroyOnLoad(obj);
            }
        }
    }

    private void CleanUpAndDestroy()
    {
        foreach (GameObject obj in persistanceObjects)
        {
            Destroy(obj);
        }
        Destroy(gameObject);
    }
}
