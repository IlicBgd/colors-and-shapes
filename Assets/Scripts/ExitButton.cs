using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ExitButton : BaseButton
{
    public override void OnPointerClick(PointerEventData eventData)
    {
        Application.Quit();
    }
}

