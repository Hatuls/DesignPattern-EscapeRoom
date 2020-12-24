using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Quests
{
    
    public abstract class QuestAbstSO : ScriptableObject
    {


    }

    [CreateAssetMenu(fileName = "New Quest", menuName = "Quest")]
    public class UnlockDoorQuest : QuestAbstSO
    {

    }
}
