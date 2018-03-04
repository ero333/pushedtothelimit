using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using CatPot.Framework.Messaging;

public class PlayersTargetGroupManager : MonoBehaviour
{
    private CinemachineTargetGroup _group;

    private void Awake()
    {
        _group = GetComponent<CinemachineTargetGroup>();
        _group.m_Targets = new CinemachineTargetGroup.Target[GameManager.instance.jugadoreEnPartida];
    }

    private void OnEnable()
    {
        EventDispatcher.Instance.AddListener<PlayerSpawnedEvent>(OnPlayerSpawned);
        EventDispatcher.Instance.AddListener<PlayerDiedEvent>(OnPlayerDied);
    }

    private void OnDisable()
    {
        EventDispatcher.Instance.RemoveListener<PlayerSpawnedEvent>(OnPlayerSpawned);
        EventDispatcher.Instance.RemoveListener<PlayerDiedEvent>(OnPlayerDied);
    }

    private void OnPlayerSpawned(PlayerSpawnedEvent e)
    {
        CinemachineTargetGroup.Target t = new CinemachineTargetGroup.Target();
        t.target = e.Player.transform;
        t.weight = 1;

        _group.m_Targets[e.Player.GetComponent<PlayerController>().PlayerName - 1] = t;
    }

    private void OnPlayerDied(PlayerDiedEvent e)
    {
        int totalTargets = _group.m_Targets.Length;
        int addedPlayers = 0;
        CinemachineTargetGroup.Target[] newTargets = new CinemachineTargetGroup.Target[totalTargets - 1];

        for (int i = 0; i < totalTargets; i++)
        {
            if (_group.m_Targets[i].target != e.Player.transform)
            {
                newTargets[addedPlayers] = _group.m_Targets[i];
                addedPlayers++;
            }
        }

        _group.m_Targets = newTargets;
    }
}
