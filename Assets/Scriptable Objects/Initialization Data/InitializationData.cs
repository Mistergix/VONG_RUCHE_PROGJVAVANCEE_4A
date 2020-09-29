using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Initialization Data", menuName = "Initialization Data", order = 51)]
public class InitializationData : ScriptableObject
{
    [SerializeField]
    private GameObject inputPlayerPrefab, randomPlayerPrefab, iaPlayerPrefab;

    [SerializeField]
    private PlayerData leftPlayerData, rightPlayerData;

    public GameObject LeftPlayerPrefab { get => GetPrefab(leftAgentType); }
    public GameObject RightPlayerPrefab { get => GetPrefab(rightAgentType); }
    public PlayerData LeftPlayerData { get => leftPlayerData; }
    public PlayerData RightPlayerData { get => rightPlayerData; }

    private GameObject GetPrefab(AgentType type)
    {
        switch (type)
        {
            case AgentType.PLAYER:
                return inputPlayerPrefab;
            case AgentType.RANDOM:
                return randomPlayerPrefab;
            case AgentType.IA:
                return iaPlayerPrefab;
            default:
                throw new UnityException("Le type n'existe pas");
        }
    }

    public enum AgentType { PLAYER, RANDOM, IA }

    private AgentType leftAgentType, rightAgentType;

    public void SetLeftAgentType(int index)
    {
        leftAgentType = (AgentType)index;
    }

    public void SetRightAgentType(int index)
    {
        rightAgentType = (AgentType)index;
    }
}
