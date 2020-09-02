using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(EasySuspension))]
public class Mistakes : MonoBehaviour
{
   
    public bool touched,exist, passed, depassementInterdit = false;
    private float speed;
    float timer = 10f;
    private EasySuspension wd;
    private DetectionCarScript dc;
    // Use this for initialization
    void Start()
    {
     wd = GetComponent<EasySuspension>();
     dc = GetComponent<DetectionCarScript>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("la vitesse " + wd.inf);
        Debug.Log("exist " + exist);
        
      // print("t3adet ? " + passed);
       /* if (exist2 )
        {
            Debug.Log("How dare you ?!");
        }*/
        if (touched )
        {
            timer -= Time.deltaTime;
          //  Debug.Log("timer "+timer);
            if (timer < 0) {
                Debug.Log("enfiiiiiiiiiiiiiin");
            }
        }
      
       /*  if (exist == true && passed ==true)
        {
            Debug.Log("Forbidden !");
        }*/
        Debug.Log("touched " + touched);
        Debug.Log("aaaa");
    }

    public void OnTriggerEnter(Collider other)
    {
        Debug.Log("touched " + touched);
        if ((other.gameObject.name == "car2"))
        { 
         touched = true;
            Debug.Log("touched !!!");
        }
     /*  if ((other.gameObject.name == "forbidden"))
        {
            Debug.Log("tdoubel aal ymin !!!");
        }*/
       /* if ((other.gameObject.name == "car3"))
        {
            exist = true;
            Debug.Log("exist !!!");
        }*/
       /* if ((other.gameObject.name == "pass"))
        {
            passed = true;
            Debug.Log("passed !!!");
            DetectionCarScript.passed2 = true;
        }*/
      /*  if ((other.gameObject.name == "car4")&& passed)
        {
            exist2 = true;
        }*/
        if ((other.gameObject.name == "depassementcube")&&passed)
        {
            depassementInterdit = true;
            Debug.Log("Depassement Interdit");
        }
       
    }
    public void OnTriggerExit(Collider col)
    {
         touched = false;
         timer = 10f;
        
    }
}
