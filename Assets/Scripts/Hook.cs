using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hook : MonoBehaviour
{
   [SerializeField] float hookForce = 25f;
   public float playerDrag = 0f;

   Grapple grapple;
   Rigidbody rigid;
   public Rigidbody playerRigid;

   public GameObject player; 

   void awake()
   {
       player = GameObject.Find("Player");
       playerRigid = player.GetComponent<Rigidbody>();

       //string namecheck = player.name;
       //Debug.Log("Player object is = " + namecheck);

    }

   void start()
   {
       //GameObject player = new GameObject();
       //player = GameObject.FindWithTag("Player");

   }

   public void Initialize(Grapple grapple, Transform shootTransform)
   {
       transform.forward = shootTransform.forward;
       this.grapple = grapple;
       rigid = GetComponent<Rigidbody>();

       rigid.AddForce(transform.forward * hookForce, ForceMode.Impulse);
   }

   void Update()
   {
       LineRenderer lineRenderer = GetComponent<LineRenderer>();
       Vector3[] positions = new Vector3[]
            {
                transform.position,
                grapple.transform.position
            };

       lineRenderer.SetPositions(positions);
   }

   private void OnTriggerEnter(Collider other)
   {
       if((LayerMask.GetMask("Gemstone") & 1 << other.gameObject.layer) > 0)
       {
           rigid.useGravity = false;
           rigid.isKinematic = true;

           grapple.StartPull();
       }

       if((LayerMask.GetMask("Carrot") & 1 << other.gameObject.layer) > 0)
       {
           rigid.useGravity = false;
           rigid.isKinematic = true;
           playerRigid.drag = 10;

           grapple.StartPull();
       }


    
   }

        
}
