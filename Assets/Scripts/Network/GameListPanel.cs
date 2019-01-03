using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameListPanel : MonoBehaviour
{

    [SerializeField]
    private JoinButton joinButtonPrefab;

    private void Awake()
    {
        AvailableGamesList.OnAvailableMatchesChanged += AvailableGamesList_OnAvailableMatchesChanged;    
    }

    private void AvailableGamesList_OnAvailableMatchesChanged(List<LanConnnectionInfo> games)
    {
        ClearExistingButtons();
        CreateNewJoinGameButtons(games);
    }

    private void ClearExistingButtons()
    {
        var buttons = GetComponentsInChildren<JoinButton>();
        foreach (var button in buttons)
        {
            Destroy(button.gameObject);
        }
    }

    private void CreateNewJoinGameButtons(List<LanConnnectionInfo> games)
    {
        foreach(var game in games)
        {
            var button = Instantiate(joinButtonPrefab);
            button.Initialize(game, transform);
        }
    }
}
