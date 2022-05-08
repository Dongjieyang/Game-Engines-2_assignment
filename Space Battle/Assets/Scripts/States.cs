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

            owner.transform.position)<50)
        {
            owner.ChangeState(new AttackState());
        }

    }

    public override void Exit()
    {
        owner.GetComponent<Seek>().enabled = false;
    }
}
class AttackState : State
{
    public override void Enter()
    {
        owner.GetComponent<Arrive>().enabled = true;
    }

    public override void Think()
    {

        owner.GetComponent<MotherShipControl>().Bullet .gameObject.SetActive(true);

        if (Vector3.Distance(owner.GetComponent<MotherShipControl>().Enemy.transform.position,

           owner.transform.position) <30)
        {
            owner.ChangeState(new SaveStarState());
        }
    }

    public override void Exit()
    {
        owner.GetComponent<Arrive>().enabled = false;
    }
}
class SaveStarState : State
{
    public override void Enter()
    {
        owner.GetComponent<Seek2>().enabled = true;
    }
    public override void Think()
    {
        if (Vector3.Distance(owner.GetComponent<Seek2>().targetGameObject.transform.position,

           owner.transform.position) <280)
        {
            owner.GetComponent<MotherShipControl>().laser.gameObject.SetActive(true);
        }
        if (Vector3.Distance(owner.GetComponent<Seek2>().targetGameObject.transform.position,

          owner.transform.position) < 240)
        {
            owner.ChangeState(new StopState());
        }
    }
    public override void Exit()
    {
        owner.GetComponent<Seek2>().enabled = false;
    }
}







class EnemyDefenseState : State
{
    public override void Enter()
    {
        owner.GetComponent<Rotate1>().enabled = true;
        owner.GetComponent<Rotate2>().enabled = true;
    }
    public override void Think()
    {
        Vector3 toMotherShip = owner.GetComponent<EnemyControl>().ships.transform.position - owner.transform.position;
        if (toMotherShip.magnitude < 80)
        {
            owner.ChangeState(new EnemyAttactState());
        }
    }
    public override void Exit()
    {
        owner.GetComponent<Rotate1>().enabled = false;
        owner.GetComponent<Rotate2>().enabled = false;
    }

}
class EnemyAttactState : State
{
    public override void Enter()
    {
        owner.GetComponent<Seek>().enabled = true;

    }
    public override void Think()
    {
        Vector3 toShips = owner.GetComponent<EnemyControl>().ships.transform.position - owner.transform.position;
        if (toShips.magnitude <= 0.1f)
        {
            owner.GetComponent<Seek>().enabled = false;
        }
    }
}


class AbsorbState : State
{
    public override void Enter()
    {
        owner.GetComponent<Rotate1>().enabled = true;

    }
    public override void Think()
    {

        if (Vector3.Distance(owner.GetComponent<EnemyMotherShipControl>().bullet.transform.position,

          owner.transform.position) <= 2)
        {
            owner.GetComponent<Rotate1>().rotSpeed  -= 150;

        }
    }
    public override void Exit()
    {
       

    }
}








class FighterPursueState : State
{
    public override void Enter()
    {
        owner.GetComponent<OffsetPursue>().enabled = true;

    }
    public override void Think()
    {
        if (Vector3.Distance(owner.GetComponent<StateMachine>().pointA.transform.position,

            owner.transform.position) < 80)
        {
            owner.ChangeState(new FighterAttactState());
        }
    }
    public override void Exit()
    {
        owner.GetComponent<OffsetPursue>().enabled = false;

    }
}

    class FighterAttactState : State
    {
        public override void Enter()
        {
            owner.GetComponent<Seek>().enabled = true;

        }
    public override void Think()
    {
        owner.GetComponent<FighterShipControl>().Bullet.gameObject.SetActive(true);

        if  (Vector3.Distance(owner.GetComponent<StateMachine>().pointA.transform.position,

            owner.transform.position) < 20)
            {
                owner.ChangeState(new Arrive2State());
            }
    }

    public override void Exit()
    {
        owner.GetComponent<Seek>().enabled = false;
    }
}
class Arrive2State : State
{
    public override void Enter()
    {
        owner.GetComponent<Arrive>().enabled = true;
    }

    public override void Think()
    {
        if (Vector3.Distance(owner.GetComponent<StateMachine>().pointA.transform.position,

            owner.transform.position) < 50)
        {
            owner.ChangeState(new StopState());
        }

    }

    public override void Exit()
    {
        owner.GetComponent<Arrive>().enabled = false;
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

