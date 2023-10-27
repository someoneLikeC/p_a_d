using UnityEngine;

public class Bank
{
    public int Pnum;
    public int Dnum;
    public bool isLeft;
    public GameObject bank;
    public Bank(int id)
    {
        bank = Object.Instantiate(Resources.Load("Prefabs/Bank", typeof(GameObject)), new Vector3(0, 0, 4.0f * (id - 0.5f) * 2), Quaternion.identity, null) as GameObject;
        if (id == 0)
        {
            Pnum = 3; 
            Dnum = 3;
            isLeft = false;
        }
        else
        {
            Pnum = 0;
            Dnum = 0;
            isLeft = true;
        }
    }

    public void SetName(string name)
    {
        bank.name = name;
    }

}
