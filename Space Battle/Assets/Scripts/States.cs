using System.Collections;
using System.Collections.Generic;
using UnityEngine;


class PursueState : State
{
    public override void Enter()
    {
        owner.GetComponent<OffsetPursue>().enabled = true;
    }

    public override void Think()
    {
        if (Vector3.Distance( owner.GetComponent<StateMachine>().pointA.transform.position,
            
            owner.transform.position) < 25)
        {
            owner.ChangeState(new MoveAheadState());
        }
       
    }

    public override void Exit()
    {
        owner.GetComponent<OffsetPursue>().enabled = false;
    }
}
class MoveAheadState : State
{
    public override void Enter()
    {
        owner.GetComponent<Seek>().enabled = true;
    }

    public override void Think()
    {
        if (Vector3.Distance(owner.GetComponent<MotherShipControl>().Enemy.transform.position,

            owner.transform.position)<30)
        {
            owner.ChangeState(new PreAttackState());
        }

    }

    public override void Exit()
    {
        owner.GetComponent<Seek>().enabled = false;
    }
}
class PreAttackState : State
{
    public override void Enter()
    {
        owner.GetComponent<Boid>().enabled = false;
    }

    public override void Think()
    {
        Vector3 toEnemy = owner.GetComponent<MotherShipControl>().Enemy.transform.position - owner.transform.position;
        if (Vector3.Angle(owner.transform.forward, toEnemy) < 45 && toEnemy.magnitude < 30)
        {
            GameObject bullet = GameObject.Instantiate(owner.GetComponent<MotherShipControl>().Bullet, owner.transform.position + owner.transform.forward * 2, owner.transform.rotation);
    
        }
        if(owner.GetComponent<Bullet>().enemyCountdown<=0)
        {
            owner.ChangeState(new SaveStarState());
        }
    }

    public override void Exit()
    {
       
    }
}
class SaveStarState : State
{
    public override void Enter()
    {
        
    }

    public override void Think()
    {
        owner.transform.LookAt(owner.GetComponent<MotherShipControl>().Star);
        Vector3 toStar = owner.GetComponent<MotherShipControl>().Star.transform.position - owner.transform.position;
        if (Vector3.Angle(owner.transform.forward, toStar) < 5 )
        {
            GameObject laser = GameObject.Instantiate(owner.GetComponent<MotherShipControl>().Laser, owner.transform.position + owner.transform.forward * 2, owner.transform.rotation);

        }
    }

    public override void Exit()
    {

    }
}



































class PatrolState : State
{
    public override void Enter()
    {
        owner.GetComponent<FollowPath>().enabled = true;
    }

    public override void Think()
    {
        if (Vector3.Distance(owner.GetComponent<StateMachine>().pointA.transform.position,

            owner.transform.position) < 35)
        {
            owner.ChangeState(new ArriveState());
        }

    }

    public override void Exit()
    {
        owner.GetComponent<FollowPath>().enabled = false;
    }
}
class ArriveState : State
{
    public override void Enter()
    {
        owner.GetComponent<Arrive>().enabled = true;
    }

    public override void Think()
    {
        if (Vector3.Distance(owner.GetComponent<StateMachine>().pointA.transform.position,

            owner.transform.position) < 5)
        {
            owner.ChangeState(new StopState());
        }

    }

    public override void Exit()
    {
        owner.GetComponent<Arrive>().enabled = false;
    }
}
class StopState : State
{
    public override void Enter()
    {
        owner.GetComponent<Boid>().enabled = false;
    }

    
}

