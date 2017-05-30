using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FingerAuth {

	public class FingerManager : MonoBehaviour {

		private const string JAVA_CLASS_NAME = "com.example.fingerauthunity.lib.FingerAuth";
		//Androidプラグインからコールバックを受け取るため
		private const string OBJECT_NAME = "FingerManager"; 

		private FingerAuthState _state;

		public FingerAuthState State { get { return _state; } }

		// Use this for initialization
		void Start () {
			_state = FingerAuthState.INIT;
			gameObject.name = OBJECT_NAME;
			FingerAuthStart();
		}
		
		// Update is called once per frame
		void Update () {
			
		}
		public void FingerAuthStart() {
			using (AndroidJavaClass plugin = new AndroidJavaClass(JAVA_CLASS_NAME)) {
				plugin.CallStatic("AuthStart");
			}
		}

		//CallBackで処理結果が返ってくる
		public void FingerAuthResult(string message) {
			_state = (FingerAuthState)int.Parse(message);
		}
	}


public enum FingerAuthState {
	INIT = -1,
	WAIT = 0,
	SUCCESS = 1,
	FAILD = 2
}

}