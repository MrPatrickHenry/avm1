using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CustomButton : Button
{
    public delegate void ButtonEvent();
    public event ButtonEvent OnButtonPointerDown;
    public event ButtonEvent OnButtonPointerUp;

    public override void OnPointerDown(PointerEventData eventData)
    {
        base.OnPointerDown(eventData);
        OnButtonPointerDown?.Invoke();
    }

    public override void OnPointerUp(PointerEventData eventData)
    {
        base.OnPointerUp(eventData);
        OnButtonPointerUp?.Invoke();
    }
}