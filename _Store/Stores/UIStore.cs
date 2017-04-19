using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIStore : MonoBehaviour {

	public U3D.KVO.ReadOnlyValueObserving<bool> vuforiaTracked { get { return __vuforiaTracked; } } 
	U3D.KVO.ValueObserving<bool> __vuforiaTracked = new U3D.KVO.ValueObserving<bool>();


	void Start () {
		__vuforiaTracked.set = false;
	}

	public void SET_VUPHORIA_TRACKED(bool status){
		__vuforiaTracked.set = status;
	}
}
