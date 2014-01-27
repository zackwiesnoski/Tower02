using UnityEngine;
using System.Collections;

public class DiskControls : MonoBehaviour
{

		public int size = 1;

		public int getSize ()
		{
				return size;
		}
		
		public void setSize(int newSize) {
			size = newSize;
			transform.localScale = new Vector3(newSize,transform.localScale.y,newSize);
		}
		// Use this for initialization
		void Start ()
		{
	
		}
	
		// Update is called once per frame
		void Update ()
		{
	
		}
}
