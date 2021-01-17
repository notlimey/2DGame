using UnityEngine;
using UnityEngine.EventSystems;

public class Onhover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject button;
    
    public void OnPointerEnter(PointerEventData eventData)
    {
        button.transform.localScale = new Vector3(1.1f, 1.1f, 1.1f);
    }
    
    public void OnPointerExit(PointerEventData eventData)
    {
        button.transform.localScale = new Vector3(1f, 1f, 1f);
    }
}
