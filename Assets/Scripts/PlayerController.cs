using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using UnityEngine;
public enum PlayerState
{
    Alive, Dead
}
public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update

    public float forceY = 300.0f;
 
    public Camera camMain;
    public List<Color> playerColor; 
    public ParticleSystem starParticle;
    [HideInInspector]
    public int starCount;

    public AudioClip colorSwitchClip;
    public AudioClip clickSound;
    public AudioSource audioSource;
    [HideInInspector]
    public PlayerState playerState;
    private Vector2 _forceY;
    private Rigidbody2D _rbPlayer;
    private SpriteRenderer _spriteRenderer;


   

    void Start()
    {
        _rbPlayer = this.GetComponent<Rigidbody2D>();
        _forceY = new Vector2(0.0f, forceY);
       
        Debug.Log("Width"+camMain.pixelWidth +"Height:"+camMain.pixelHeight);
        _spriteRenderer = GetComponent<SpriteRenderer>();

        _spriteRenderer.color = colorSelector();
        playerState = PlayerState.Alive;
        FindObjectOfType<EventManage>().TriggerInstantiatorEvent();


    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            _rbPlayer.AddForce(_forceY);
            audioSource.clip = clickSound;
            audioSource.Play();
        } 
        if(camMain.WorldToScreenPoint(this.transform.position).y <= 0)
        {
            FindAnyObjectByType<EventManage>().OnPlayerDieEvent();


        }
    }

  
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.gameObject.tag);
        if(collision.gameObject.CompareTag("ColorSwitcher"))
        {
            switchColor();
            Destroy(collision.gameObject);
            FindObjectOfType<EventManage>().TriggerInstantiatorEvent();
            audioSource.clip = colorSwitchClip;
            audioSource.Play();

        }

        if (collision.gameObject.CompareTag("Arc") || collision.gameObject.CompareTag("ColorSwitcherTre"))
        {
             Color _collColor = collision.gameObject.GetComponent<SpriteRenderer>().color;
            if(_spriteRenderer.color.Equals(_collColor))
            {
                Debug.Log("Pass");

            }
            else
            {
                Debug.Log("EndGame");
                FindAnyObjectByType<EventManage>().OnPlayerDieEvent();
            }
        }



        if ( collision.gameObject.CompareTag("Blade"))
        {
            Color _collColor = collision.gameObject.GetComponent<SpriteRenderer>().color;
            if (_spriteRenderer.color.Equals(_collColor))
            {
                Debug.Log("Pass");

            }
            
            else
            {
                Debug.Log("EndGame");
                FindAnyObjectByType<EventManage>().OnPlayerDieEvent();
            }
        }

        if (collision.gameObject.CompareTag("Star"))
        {
            Destroy(collision.gameObject);

            starParticle.transform.position = collision.contacts[0].point;
            starParticle.Play();
            FindObjectOfType<EventManage>().TriggerInstantiatorEvent();
            FindObjectOfType<EventManage>().TriggerStarCollectorEvent();

        }


    }

    Color colorSelector()
    {


        if (_spriteRenderer.color != Color.white)
        {
            int _randomNum = Random.Range(0, playerColor.Count);
            if(playerColor[_randomNum] != _spriteRenderer.color)
            {
                return playerColor[_randomNum];
            }

            else
            {
                List<Color> _newColorList = playerColor;
                _newColorList.Remove(playerColor[_randomNum]);
                _randomNum = Random.Range(0, _newColorList.Count);

                return _newColorList[_randomNum];

            }
           

        }
        else
        {
            int _randomNum = Random.Range(0, playerColor.Count);
            return playerColor[_randomNum];
        }
      
    }

    void switchColor()
    {
        _spriteRenderer.color = colorSelector();

    }


}
