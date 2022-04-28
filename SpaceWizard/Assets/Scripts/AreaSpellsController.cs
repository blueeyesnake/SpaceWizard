using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaSpellsController : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Spell;
    [SerializeField] private Camera mainCamera;
    [SerializeField] private LayerMask layerMask;
    [SerializeField] private GameObject sphere;
    public AudioSource areaSound;
    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(1)){
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
                    // RaycastHit hit;
            if(Physics.Raycast(ray,out RaycastHit raycastHit)){
                Debug.DrawRay(ray.origin, raycastHit.point);
                 ray.origin = ray.GetPoint(100);
                ray.direction = -ray.direction;
                if(raycastHit.collider == sphere.GetComponent<Collider>()){
                    areaSound.Play();
                    Instantiate(Spell, raycastHit.point,Quaternion.identity);
                }
                
                            

            }
            Vector3 cursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            
            // Debug.Log("true");
        }
    }
}
