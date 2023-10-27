using UnityEngine;

public class River
{
    public GameObject river;
    public River()
    {
        river = Object.Instantiate(Resources.Load("Prefabs/River", typeof(GameObject)), Vector3.zero, Quaternion.identity, null) as GameObject;
        river.name = "river";
    }
}
