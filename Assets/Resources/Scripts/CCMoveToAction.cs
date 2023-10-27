using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CCMoveToAction : SSAction
{
    Boat boat;
    Bank[] banks;
    UserGUI userGUI;
	public float speed;

	public static CCMoveToAction GetSSAction(Boat boat, Bank[] banks, UserGUI userGUI)
    {
		CCMoveToAction action = ScriptableObject.CreateInstance<CCMoveToAction> ();
		action.boat = boat;
        action.banks = banks;
        action.userGUI = userGUI;
		return action;
	}

    public override void Update ()
	{
        if (boat.isLeft)
        {
            boat.thisboat.transform.position = boat.posRight;
            boat.pos1 = boat.thisboat.transform.position + new Vector3(0, 0, 0.3f);
            boat.pos2 = boat.thisboat.transform.position + new Vector3(0, 0, -0.3f);
            boat.isLeft = !boat.isLeft;
            foreach (Transform child in boat.thisboat.transform)
            {
                Role[] roles = SSDirector.getInstance().currentSceneController.getRole();
                for (int i = 0; i < roles.Length; i++)
                {
                    if (roles[i].character.transform == child)
                    {
                        roles[i].isLeft = !roles[i].isLeft;
                    }
                }
            }
            if (banks[1].Pnum + boat.P == 3 && banks[1].Dnum + boat.D == 3)
            {
                userGUI.Win();
            }
            else if ((banks[0].Dnum + boat.D > banks[0].Pnum + boat.P && banks[0].Pnum != 0) || (banks[1].Dnum + boat.D > banks[1].Pnum + boat.P && banks[1].Pnum != 0))
            {
                userGUI.Lose();
            }
        }
        else
        {
            boat.thisboat.transform.position = boat.posLeft;
            boat.pos1 = boat.thisboat.transform.position + new Vector3(0, 0, 0.3f);
            boat.pos2 = boat.thisboat.transform.position + new Vector3(0, 0, -0.3f);
            boat.isLeft = !boat.isLeft;
            foreach (Transform child in boat.thisboat.transform)
            {
                Role[] roles = SSDirector.getInstance().currentSceneController.getRole();
                for (int i = 0; i < roles.Length; i++)
                {
                    if (roles[i].character.transform == child)
                    {
                        roles[i].isLeft = !roles[i].isLeft;
                    }
                }
            }
            if (banks[1].Pnum + boat.P == 3 && banks[1].Dnum + boat.D == 3)
            {
                userGUI.Win();
            }
            else if ((banks[0].Dnum > banks[0].Pnum && banks[0].Pnum != 0) || (banks[1].Dnum > banks[1].Pnum && banks[1].Pnum != 0))
            {
                userGUI.Lose();
            }
        }
        //waiting for destroy
        this.destory = true;
        this.callback.SSActionEvent(this);
	}

	public override void Start () {
	}
}

