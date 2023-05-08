using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Target : MonoBehaviour
{
    [SerializeField] private Sprite activeTarget;
    [SerializeField] private Sprite inactiveTarget;

    void SendRay()
    {
        Debug.Log(Camera.main.transform.forward);

        RaycastHit raycastHit;
        
        bool hasHitObject = Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out raycastHit);
        Debug.Log(raycastHit.transform.tag);

        if (hasHitObject)
        {
            var image = GetComponent<Image>();
            
            if (raycastHit.transform.CompareTag("Enemy"))
            {
                image.sprite = activeTarget;
            }
            else
            {
                image.sprite = inactiveTarget;
            }
        }
    }
        
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        SendRay();
    }
}
