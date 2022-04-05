using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaSpellController : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Spell;
    [SerializeField] private Camera mainCamera;
    [SerializeField] private LayerMask layerMask;
    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(1)){
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(ray,out RaycastHit raycastHit)){
                
                Instantiate(Spell, raycastHit.point,Quaternion.identity);
                            Debug.Log(raycastHit.point.z);

            }
            Vector3 cursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            
            Debug.Log("true");
        }
    }
}
