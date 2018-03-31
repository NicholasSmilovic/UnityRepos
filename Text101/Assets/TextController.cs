using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TextController : MonoBehaviour {

	public Text text;
	private enum States {	cell, mirror, sheets_0, lock_0, mirror_0,
												corridor_0,
												die};
	private States myState;
	private bool foundKey;

	// Use this for initialization
	void Start () {
		text = GetComponent<Text>();
		foundKey = false;
		myState = States.cell;
	}

	// Update is called once per frame
	void Update () {
		print (myState);
		if 			(myState == States.cell) 				{cell();}
		else if (myState == States.die) 				{die();}
		else if (myState == States.sheets_0)		{sheets_0();}
		else if (myState == States.mirror_0)		{mirror_0();}
		else if (myState == States.lock_0) 			{lock_0();}
		else if (myState == States.corridor_0) 	{corridor_0();
		}
	}

	void cell () {
		text.text = "You are in a prison cell, and you want to escape. There are " +
		"some dirty sheets on the bed,  mirror on the wall, and " +
		"a locked door. \n\n" +
		"Press S to view Sheets. \n" +
		"Press M to view Mirror. \n" +
		"Press L to view Lock. \n";
		if(Input.GetKeyDown(KeyCode.S)) {
			myState = States.sheets_0;
		} else if(Input.GetKeyDown(KeyCode.M)) {
			myState = States.mirror_0;
		} else if(Input.GetKeyDown(KeyCode.L)) {
			myState = States.lock_0;
		} else if(Input.GetKeyDown(KeyCode.D)) {
			myState = States.die;
		}
	}

	void sheets_0 () {
		text.text = "disgusting, Someone should change these! \n" +
		"Press R to continue roaming. \n";
		if(Input.GetKeyDown(KeyCode.R)) {
			myState = States.cell;
		}
	}

	void mirror_0 () {
		if(foundKey == true) {
			text.text = "You are so ugly eww! \n";
		} else {
			text.text = "You found a key! \n";
		}
		text.text = text.text + "Press R to continue roaming. \n";
		if(Input.GetKeyDown(KeyCode.R)) {
			foundKey = true;
			myState = States.cell;
		}
	}

	void lock_0 () {
		if( foundKey) {
			text.text = "You unlock the door. \n";
			myState = States.corridor_0;
		} else {
			text.text = "the door is locked. \n"+
			"Press R to continue roaming. \n";
			if(Input.GetKeyDown(KeyCode.R)) {
				myState = States.cell;
			}
		}
	}

	void die () {
		text.text = "you try to die but lose your nerve! \n" +
		"Press R to continue roaming. \n";
		if(Input.GetKeyDown(KeyCode.R)) {
			myState = States.cell;
		}
	}

	void corridor_0 () {
		text.text = "you are in a corridor. \n" +
		"Press C to leave to Corridor. \n";

		if(Input.GetKeyDown(KeyCode.C)) {
			myState = States.corridor_0;
		}
	}
}
