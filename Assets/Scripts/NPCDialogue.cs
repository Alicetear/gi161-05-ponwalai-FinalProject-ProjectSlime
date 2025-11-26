using UnityEngine;

[CreateAssetMenu(fileName = "NewNPCDialogue" , menuName = "NPC Dialogue")]
public class NPCDialogue : ScriptableObject
{
    public string npcName;
    public Sprite portrait;
    [TextArea]
    public string[] sentences;

}
