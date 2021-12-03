 using UnityEngine;
 using UnityEngine.UI;
 using System.Collections;
 
 public class SliderVolume : MonoBehaviour {

    [SerializeField]
    CanvasGroup Canvas01;

    void Update()
    {
        if (Input.GetKey("i"))
        {
            Canvas01.alpha = 0f; //this makes everything transparent
            Canvas01.blocksRaycasts = false; //this prevents the UI element to receive input events
        }
        if (Input.GetKey("o"))
        {
            Canvas01.alpha = 1f;
            Canvas01.blocksRaycasts = true;
        }
    }


 }
