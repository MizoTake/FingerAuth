using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using FingerAuth;

public class ManagerResultText : MonoBehaviour {

	[SerializeField]
	private FingerManager _finger;

	private Text _text;

	// Use this for initialization
	void Start () {
		_text = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
		_text.text = FingerStateString(_finger.State);
	}

	private string FingerStateString(FingerAuthState state) {
		switch(state) {
			case FingerAuthState.INIT:
				return "初期化状態";
			case FingerAuthState.WAIT:
				return "指紋認証待ち状態";
			case FingerAuthState.SUCCESS:
				return "指紋認証成功";
			case FingerAuthState.FAILD:
				return "指紋認証失敗";
		}
		return "";
	}
}
