using UnityEngine;

public class Boat
{
    public int peopleOnboat;
    public int P;
    public int D;
    public Vector3 pos1;
    public Vector3 pos2;
    public bool pos1Full;
    public bool pos2Full;
    public GameObject thisboat;
    public bool isLeft;
    public Vector3 posLeft;
    public Vector3 posRight;

    public Boat()
    {
        peopleOnboat = 0;
        thisboat = Object.Instantiate(Resources.Load("Prefabs/Boat", typeof(GameObject)), new Vector3(0, 0.5f, -2.25f), Quaternion.identity, null) as GameObject;
        thisboat.name = "boat";
        pos1 = thisboat.transform.position + new Vector3(0, 0, 0.3f);
        pos2 = thisboat.transform.position + new Vector3(0, 0, -0.3f);
        pos1Full = false;
        pos2Full = false;
        isLeft = false;
        posLeft = new Vector3(0, 0.5f, 2.25f);
        posRight = new Vector3(0, 0.5f, -2.25f);
    }

    public void Move(Bank[] banks, UserGUI userGUI)
    {
        if (isLeft)
        {
            thisboat.transform.position = posRight;
            pos1 = thisboat.transform.position + new Vector3(0, 0, 0.3f);
            pos2 = thisboat.transform.position + new Vector3(0, 0, -0.3f);
            isLeft = !isLeft;
            foreach (Transform child in thisboat.transform)
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
            if (banks[1].Pnum + P == 3 && banks[1].Dnum + D == 3)
            {
                userGUI.Win();
            }
            else if ((banks[0].Dnum + D > banks[0].Pnum + P && banks[0].Pnum != 0) || (banks[1].Dnum + D > banks[1].Pnum + P && banks[1].Pnum != 0))
            {
                userGUI.Lose();
            }
        }
        else
        {
            thisboat.transform.position = posLeft;
            pos1 = thisboat.transform.position + new Vector3(0, 0, 0.3f);
            pos2 = thisboat.transform.position + new Vector3(0, 0, -0.3f);
            isLeft = !isLeft;
            foreach (Transform child in thisboat.transform)
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
            if (banks[1].Pnum + P == 3 && banks[1].Dnum + D == 3)
            {
                userGUI.Win();
            }
            else if ((banks[0].Dnum > banks[0].Pnum && banks[0].Pnum != 0) || (banks[1].Dnum > banks[1].Pnum && banks[1].Pnum != 0))
            {
                userGUI.Lose();
            }
        }
    }

}