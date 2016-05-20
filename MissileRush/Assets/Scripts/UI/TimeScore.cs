using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class TimeScore : MonoBehaviour
{

    [SerializeField]
    private Text scoreBoardText;

    private List<string> scoreboardStrings;

    void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }
}
