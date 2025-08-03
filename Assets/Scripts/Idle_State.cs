using UnityEngine;

public class Idle_State : IState
{
    public void Enter(PlayerController player)
    {
        Debug.Log("Entering Idle State");
    }
    
    public void Exit(PlayerController player)
    {
        Debug.Log("Exiting Idle State");
    }

    public void Update(PlayerController player)
    {
        if (player.isWalking && player.isGrounded)
        {
            player.ChangeState(new WalkingState());   // Walk durumuna geçiş yap.
        }
        else if (!player.isGrounded)
        {
            player.ChangeState(new JumpState());   // Jump durumuna geçiş yap.
        }
    }
}
