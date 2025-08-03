using UnityEngine;

public class WalkingState : IState
{
    public void Enter(PlayerController player)
    {
        Debug.Log("Entering Walking State");
    }
    
    public void Exit(PlayerController player)
    {
        Debug.Log("Exiting Walking State");
    }

    public void Update(PlayerController player)
    {
        if (!player.isWalking && player.isGrounded)
        {
            player.ChangeState(new Idle_State());   // Idle durumuna geçiş yap.
        }
        else if (!player.isGrounded)
        {
            player.ChangeState(new JumpState());    // Jump durumuna geçiş yap.
        }
    }
      
}
