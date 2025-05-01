using UnityEngine;
using UnityEngine.EventSystems;

public class ClickHandler : MonoBehaviour, IPointerClickHandler
{
    [SerializeField]
    private CardPrefabScript cardPrefabScript;

    public void OnPointerClick(PointerEventData pointerEventData)
    {
        cardPrefabScript.FlipCard();
    }
}
