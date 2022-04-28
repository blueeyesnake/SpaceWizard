using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaSpellController : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Spell;
    [SerializeField] private Camera mainCamera;
    [SerializeField] private LayerMask layerMask;
    [SerializeField] private GameObject sphere;
    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(1)){
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
                    // RaycastHit hit;
            if(Physics.Raycast(ray,out RaycastHit raycastHit,100.0f)){
                Debug.DrawRay(ray.origin, raycastHit.point);
                if(raycastHit.collider == sphere.GetComponent<Collider>()){
                    Debug.Log("true");
                    Instantiate(Spell, raycastHit.point,Quaternion.identity);
                }
                
                            

            }
            Vector3 cursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            
            // Debug.Log("true");
        }
    }
}
