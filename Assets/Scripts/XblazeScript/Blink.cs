using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blink : MonoBehaviour
{

    public Texture2D F1;
    public Texture2D F2;
    public Texture2D F3;
    public Texture2D F4;
    public Texture2D F5;
    public Texture2D F6;

    public float TimeWithoutBlinkCooldown = 5f;
    private int count = 0;
    private float TimeWithoutBlink = 0f;
    public bool blink = false; 
    

    // Update is called once per frame
    void Update()
    {
    TimeWithoutBlink += Time.deltaTime;
        if(TimeWithoutBlink > TimeWithoutBlinkCooldown)
        {
            TimeWithoutBlink = 0;
            blink = true;
        }

if(blink == true){

            switch ( count )
    {
    
    
    case 0 :
        gameObject.GetComponent<Renderer>().materials[1].mainTexture = F1;
        break;
    case 1 :
        gameObject.GetComponent<Renderer>().materials[1].mainTexture = F2;
        break;
    case 2 :
        gameObject.GetComponent<Renderer>().materials[1].mainTexture = F3;
        break;
    case 3 :
        gameObject.GetComponent<Renderer>().materials[1].mainTexture = F4;
        break;
    case 4 :
        gameObject.GetComponent<Renderer>().materials[1].mainTexture = F5;
        break;
    case 5 :
        gameObject.GetComponent<Renderer>().materials[1].mainTexture = F6;
        break;
    case 6 :
        gameObject.GetComponent<Renderer>().materials[1].mainTexture = F6;
        break;
    case 7 :
        gameObject.GetComponent<Renderer>().materials[1].mainTexture = F6;
        break;
    case 8 :
        gameObject.GetComponent<Renderer>().materials[1].mainTexture = F6;
        break;
    case 9 :
        gameObject.GetComponent<Renderer>().materials[1].mainTexture = F5;
        break;
    case 10 :
        gameObject.GetComponent<Renderer>().materials[1].mainTexture = F4;
        break;
    case 11 :
        gameObject.GetComponent<Renderer>().materials[1].mainTexture = F3;
        break;
    case 12 :
        gameObject.GetComponent<Renderer>().materials[1].mainTexture = F2;
        break;
    case 13 :
        gameObject.GetComponent<Renderer>().materials[1].mainTexture = F1;
        blink = false;
        count = 0;
        break;
    }
            count++;

    }
    }


}
