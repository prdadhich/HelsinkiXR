using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaInstantiator : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> _obsPrefab;

    private GameObject _prevInsObj;
    private void OnEnable()
    {
        EventManage.OnInstantiator += InstantiateObj;


    }

    private void OnDisable()
    {
        EventManage.OnInstantiator -= InstantiateObj;


    }
    private void Update()
    {
         if (_prevInsObj.CompareTag("Blade")&&_prevInsObj.transform.position.y < GameObject.FindGameObjectWithTag("Player").transform.position.y)
        {

            FindObjectOfType<EventManage>().TriggerInstantiatorEvent();

        }
    }
    void InstantiateObj()
    {
        Vector3 _pos = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width / 2, Screen.height*.9f, Camera.main.nearClipPlane));
        List<GameObject> _copyObjectList = new List<GameObject>(_obsPrefab);
        Debug.Log("insta" + _copyObjectList.Count);
        if (_prevInsObj!=null)
        {

            Debug.Log("MethdCalled"+_prevInsObj.tag);
            Debug.Log("previousobj" + _copyObjectList.Count);
            foreach (GameObject toRemove in _obsPrefab)
            {
                

                if(toRemove.CompareTag(_prevInsObj.tag))
                {
                    _copyObjectList.Remove(toRemove);
                    Debug.Log("removetag" + toRemove.tag);
                    
                }
             
               
            }

            _prevInsObj = Instantiate(_copyObjectList[Random.Range(0, _copyObjectList.Count)], _pos, Quaternion.identity);



        }
        else
        {
            Debug.Log("newobj"+_copyObjectList.Count);

            _prevInsObj = Instantiate(_copyObjectList[Random.Range(0, _copyObjectList.Count)], Vector3.zero, Quaternion.identity);

        }
        Debug.Log("Event triggered obj instant");
    }





    

}
