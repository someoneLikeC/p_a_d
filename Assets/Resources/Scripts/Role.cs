using Unity.VisualScripting;
using UnityEngine;

public class Role
{
    public bool isOnBoat;
    public bool isLeft;
    public GameObject character;
    public Vector3 posRight;
    public Vector3 posLeft;
    public Role(string name, Vector3 v)
    {
        character = Object.Instantiate(Resources.Load("Prefabs/" + name, typeof(GameObject)), Vector3.zero, Quaternion.identity, null) as GameObject;
        isOnBoat = false;
        isLeft = false;
        posRight = v;
        posLeft = new Vector3(v.x, v.y, -v.z);
    }

    public void SetName(string name)
    {
        character.name = name;
    }

    public void SetPosition(Vector3 pos)
    {
        character.transform.position = pos;
    }

   public void MoveTo(Boat boat, Bank[] banks)
    {
        if (isOnBoat)
        {
            if (!isLeft)
            {
                if(character.transform.position == boat.pos1)
                {
                    boat.pos1Full = false;
                }else if(character.transform.position == boat.pos2)
                {
                    boat.pos2Full = false;
                }
                character.transform.position = posRight;
                character.transform.SetParent(null);
                isOnBoat = false;
                boat.peopleOnboat--;
                if (character.name == "priest0" || character.name == "priest1" || character.name == "priest2")
                {
                    boat.P--;
                    banks[0].Pnum++;
                }
                else
                {
                    boat.D--;
                    banks[0].Dnum++;
                }
            }
            else
            {
                if (character.transform.position == boat.pos1)
                {
                    boat.pos1Full = false;
                }
                else if (character.transform.position == boat.pos2)
                {
                    boat.pos2Full = false;
                }
                character.transform.position = posLeft;
                character.transform.SetParent(null);
                isOnBoat = false;
                boat.peopleOnboat--;
                if (character.name == "priest0" || character.name == "priest1" || character.name == "priest2")
                {
                    boat.P--;
                    banks[1].Pnum++;
                }
                else
                {
                    boat.D--;
                    banks[1].Dnum++;
                }
            }
        }
        else
        {
            if(boat.isLeft == isLeft)
            {
                if (!boat.pos1Full)
                {
                    character.transform.position = boat.pos1;
                    boat.pos1Full = true;
                    character.transform.SetParent(boat.thisboat.transform);
                    isOnBoat = true;
                    boat.peopleOnboat++;
                    if (character.name == "priest0" || character.name == "priest1" || character.name == "priest2")
                    {
                        boat.P++;
                        if (!isLeft)
                        {
                            banks[0].Pnum--;
                        }
                        else
                        {
                            banks[1].Pnum--;
                        }
                    }
                    else
                    {
                        boat.D++;
                        if (!isLeft)
                        {
                            banks[0].Dnum--;
                        }
                        else
                        {
                            banks[1].Dnum--;
                        }
                    }
                }
                else if (!boat.pos2Full)
                {
                    character.transform.position = boat.pos2;
                    boat.pos2Full = true;
                    character.transform.SetParent(boat.thisboat.transform);
                    isOnBoat = true;
                    boat.peopleOnboat++;
                    if (character.name == "priest0" || character.name == "priest1" || character.name == "priest2")
                    {
                        boat.P++;
                        if (!isLeft)
                        {
                            banks[0].Pnum--;
                        }
                        else
                        {
                            banks[1].Pnum--;
                        }
                    }
                    else
                    {
                        boat.D++;
                        if (!isLeft)
                        {
                            banks[0].Dnum--;
                        }
                        else
                        {
                            banks[1].Dnum--;
                        }
                    }
                }
            }
        }
    }
}
