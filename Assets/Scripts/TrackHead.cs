using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Windows.Kinect;

public class TrackHead : MonoBehaviour {

public GameObject BodySrcManager;
public JointType Trackhead;
private BodySourceManager bodyManager;
private Body[] bodies;
	// Use this for initialization
	void Start () {
		if(BodySrcManager ==  null)
		{
			Debug.Log("assign");
		}
		else
		{
			bodyManager = BodySrcManager.GetComponent<BodySourceManager>();
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (bodyManager== null )
		{
			return;
		}
		bodies=bodyManager.GetData();
		if(bodies==null)
		{
			return;
		}
		foreach ( var body in bodies)
		{
			if(body==null)
			{
				continue;
			}
			if(body.IsTracked)
			{
				var pos = body.Joints[Trackhead].Position;
				gameObject.transform.position =  new Vector3(pos.X*10f,pos.Y*10f);
			}
		}
	}
}
