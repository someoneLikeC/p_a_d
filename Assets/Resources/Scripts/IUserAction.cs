using System;


public interface IUserAction
{
    void MoveRole(Role role, Boat boat, Bank[] banks);
    void CrossRiver(Boat boat, Bank[] banks);
    void Lose();
    void Win();
    void Reset();
}


