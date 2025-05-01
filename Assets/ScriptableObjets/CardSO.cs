using UnityEngine;

[CreateAssetMenu(fileName = "CardSO", menuName = "ScriptableObjects/CardSO")]
public class CardSO : ScriptableObject
{
    public int cardId;
    public string cardName;
    public ImageType imageType;
}
