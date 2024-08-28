using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using TMPro;
using UnityEngine;

public class StarCollectCount : MonoBehaviour
{
    // Start is called before the first frame update

    
    public TMP_Text starCount;
    private static int _starCount = 0;
    public AudioClip starClip;
    public AudioSource audioSource;
    private void OnEnable()
    {
        EventManage.OnStarCollect += CountStar;
    }

  
    private void OnDisable()
    {
        EventManage.OnStarCollect -= CountStar;

    }
    private void Start()
    {
        _starCount = 0;
        starCount.text = _starCount.ToString();


    }
    void CountStar()
    {
        _starCount++;
        starCount.text = _starCount.ToString();
        Debug.Log("starCOunt"+_starCount);
        audioSource.clip = starClip;
        audioSource.Play();
    }
}
