using UnityEngine;

public class JumpState : IState
{
    public void Enter(PlayerController player)
    {
        Debug.Log("Entering Jumping State");
    }
    
    public void Exit(PlayerController player)
    {
        Debug.Log("Exiting Jumping State");
    }

    public void Update(PlayerController player)
    {
        if (player.isGrounded)
        {
            player.ChangeState(new Idle_State());   // Idle durumuna geçiş yap.
        }
        else if (player.isGrounded && player.isWalking)
        {
            player.ChangeState(new WalkingState()); // Walking durumuna geçiş yap
        }
    }
      
}
