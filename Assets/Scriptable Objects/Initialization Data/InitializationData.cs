using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Initialization Data", menuName = "Initialization Data", order = 51)]
public class InitializationData : ScriptableObject
{
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
