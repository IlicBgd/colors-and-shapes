using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class RestartButton : BaseButton
{
    public override void OnPointerClick(PointerEventData eventData)
    {
        SceneManager.LoadScene(0);
    }
}
