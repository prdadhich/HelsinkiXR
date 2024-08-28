using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class PlayerDied : MonoBehaviour
{
    [SerializeField]
    private ParticleSystem _deadParticle;

    public GameObject canvasRestart;
    public AudioClip dieClip;
    public AudioSource audioSource;
    private void Start()
    {
        canvasRestart.SetActive(false);
    }

    private void OnEnable()
    {
        EventManage.OnPlayerDie += PlayerDie;
    }

    private void OnDisable()
    {
        EventManage.OnPlayerDie -= PlayerDie;

    }

    void PlayerDie()
    {
        Vector3 _posParticle = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width / 2, Screen.height/2, Camera.main.nearClipPlane));
        _deadParticle.transform.position = _posParticle;
        _deadParticle.Play();
        Destroy(GameObject.FindGameObjectWithTag("Player"));
        //Time.timeScale = 0 ;
        canvasRestart.SetActive(true);
        audioSource.clip = dieClip;
        audioSource.Play();
    }
}
