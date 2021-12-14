 using UnityEngine;
 using UnityEngine.UI;
 using System.Collections;
 
 public class SliderVolume : MonoBehaviour {

    [SerializeField]
    CanvasGroup Canvas01;

    private void Start()
    {
        Canvas01.alpha = 1f;
        Canvas01.blocksRaycasts = true;
    }
    void Update()
    {
    }


 }
