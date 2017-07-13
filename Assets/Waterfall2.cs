using UnityEngine;
using System.Collections;

public class Waterfall2 : MonoBehaviour 
{
    public int materialIndex = 0;
    public Vector2 uvAnimationRate = new Vector2( 0.75f, -1.0f );
    public string textureName = "_MainTex";
	public bool remix = false;
	public float remixtimer = 0;
	public float remixreset = 1;
    Vector2 uvOffset = Vector2.zero;

    void LateUpdate() 
    {
		if (remix == false) uvOffset -= ( uvAnimationRate * Time.deltaTime / 3 );
		else{
			remixtimer += Time.deltaTime;
			if (remixtimer > remixreset){
				uvOffset -= ( uvAnimationRate );
				remixtimer = 0;
			}
		}
			
        if( GetComponent<Renderer>().enabled )
        {
            GetComponent<Renderer>().materials[ materialIndex ].SetTextureOffset( textureName, uvOffset );
        }
    }
}