using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriangleColor : MonoBehaviour
{

    private GameObject _player;
    private List<GameObject> _triEdges = new List<GameObject>();


    public string tagToFind = "ColorSwitcherTre";
    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        FindTaggedChildren(transform, tagToFind, _triEdges);

        ColorSprite();
    }



    void FindTaggedChildren(Transform parent, string tag, List<GameObject> foundChildren)
    {
        foreach (Transform child in parent)
        {
            if (child.CompareTag(tag))
            {
                foundChildren.Add(child.gameObject);
            }
            // Recursively search for tagged children in the child's children
            if (child.childCount > 0)
            {
                FindTaggedChildren(child, tag, foundChildren);
            }
        }
    }


    void ColorSprite()
    {
        var _playerContRef = _player.GetComponent<PlayerController>();
        Color _playerColor = _player.GetComponent<SpriteRenderer>().color;
        List<Color> _colorList = new List<Color>(_playerContRef.playerColor);
        _colorList.Remove(_playerColor);
        for(int i =0;i<_triEdges.Count;i++)
        {
            if(i==0)
            {
                _triEdges[0].GetComponent<SpriteRenderer>().color = _playerColor;

            }
            else
            {
                Color _currentColor = _colorList[Random.Range(0, _colorList.Count)];
                _triEdges[i].GetComponent<SpriteRenderer>().color = _currentColor;

                _colorList.Remove(_currentColor);

            }


        }
    
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
