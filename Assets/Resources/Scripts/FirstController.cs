using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstController : MonoBehaviour, ISceneController{

	public CCActionManager actionManager { get; set;}
    public River river;
    public Boat boat;
    public Bank[] banks = new Bank[2];
    public Role[] devilsAndpriests = new Role[6];

    // the first scripts
    void Awake () {
		SSDirector director = SSDirector.getInstance ();
		director.setFPS (60);
		director.currentSceneController = this;
		director.currentSceneController.LoadResources ();
		Debug.Log ("awake FirstController!");
	}
	 
	// loading resources for first scence
	public void LoadResources () {
        river = new River();
        boat = new Boat();
        for (int i = 0; i < 2; i++)
        {
            banks[i] = new Bank(i);
            banks[i].SetName("bank" + i);
        }
        for (int i = 0; i < 3; i++)
        {
            devilsAndpriests[i] = new Role("Priest", new Vector3(2 + i, 0.5f, -3.5f));
            devilsAndpriests[i].SetName("priest" + i);
            devilsAndpriests[i].SetPosition(devilsAndpriests[i].posRight);
        }
        for (int i = 0; i < 3; i++)
        {
            devilsAndpriests[i + 3] = new Role("Devil", new Vector3(-4 + i, 0.5f, -3.5f));
            devilsAndpriests[i + 3].SetName("devil" + i);
            devilsAndpriests[i + 3].SetPosition(devilsAndpriests[i + 3].posRight);
        }
    }

	public void Pause ()
	{
		throw new System.NotImplementedException ();
	}

	public void Resume ()
	{
        foreach (Role role in devilsAndpriests)
        {
            Destroy(role.character);
        }
        foreach (Bank bank in banks)
        {
            Destroy(bank.bank);
        }
        Destroy(boat.thisboat);
        Destroy(river.river);
        LoadResources();
    }

    public Role[] getRole()
    {
        return devilsAndpriests;
    }

    #region IUserAction implementation
    public void GameOver ()
	{
		SSDirector.getInstance ().NextScene ();
	}
	#endregion


	// Use this for initialization
	void Start () {
		//give advice first
	}
	
	// Update is called once per frame
	void Update () {
		//give advice first
	}

}
