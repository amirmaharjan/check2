using UnityEngine;
using UnityEngine.EventSystems;

public class ClickHandler : MonoBehaviour, IPointerClickHandler
{
    [SerializeField]
    private CardPrefabScript cardPrefabScript;

    public void OnPointerClick(PointerEventData pointerEventData)
    {
        Debug.Log(name + " Game Object Clicked!");
        cardPrefabScript.FlipCard();
    }
}
