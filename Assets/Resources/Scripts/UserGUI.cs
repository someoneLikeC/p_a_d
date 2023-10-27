using UnityEngine;

public class UserGUI : MonoBehaviour,IUserAction
{
    private int state;

    public UserGUI()
    {
        state = -1;
    }

    public void Win()
    {
        state = 0;
    }

    public void Lose()
    {
        state = 1;
    }

    public void Reset()
    {
        state = -1;
    }

    public void MoveRole(Role role,Boat boat, Bank[] banks)
    {
        role.MoveTo(boat,banks);
    }

    public void CrossRiver(Boat boat, Bank[] banks)
    {
        boat.Move(banks,this);
    }

    private void OnGUI()
    {
        if (GUI.Button(new Rect(35, 25, 70, 30), "���¿�ʼ")) {
            SSDirector.getInstance().currentSceneController.Resume();
            Reset();
        } 
        if(state == -1)
        {
            for (int i = 0; i < GetComponent<FirstController>().devilsAndpriests.Length; i++)
            {
                if (i < 3)
                {
                    if (GUI.Button(new Rect(20, 60 + i * 35, 100, 30), "��ʦ" + i + "��/�´�"))
                    {
                        MoveRole(GetComponent<FirstController>().devilsAndpriests[i], GetComponent<FirstController>().boat, GetComponent<FirstController>().banks);
                    }
                }

                else
                {
                    if (GUI.Button(new Rect(20, 60 + i * 35, 100, 30), "��ħ" + (i - 3) + "��/�´�"))
                    {
                        MoveRole(GetComponent<FirstController>().devilsAndpriests[i], GetComponent<FirstController>().boat, GetComponent<FirstController>().banks);
                    }
                }              
            }
            if(GetComponent<FirstController>().boat.peopleOnboat > 0)
            {
                if (GUI.Button(new Rect(35, 270, 70, 30), "����")) CrossRiver(GetComponent<FirstController>().boat, GetComponent<FirstController>().banks);
            }
        }else if(state == 0)
        {
            GUI.Box(new Rect(375, 150, 100, 100), "��Ӯ��");
        }else if(state == 1)
        {
            GUI.Box(new Rect(375, 150, 100, 100), "������");
        }
    }

    void Awake()
    {
        SSDirector director = SSDirector.getInstance();
        director.setFPS(60);
        director.currentUserGUI = this;
    }
}
