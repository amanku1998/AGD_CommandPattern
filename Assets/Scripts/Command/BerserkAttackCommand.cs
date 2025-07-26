using Command.Main;
using UnityEngine;
using Command.Actions;

public class BerserkAttackCommand : UnitCommand
{
    private bool willHitTarget;
    private const float hitChance = 0.66f;

    public BerserkAttackCommand(CommandData commandData)
    {
        this.commandData = commandData;
        willHitTarget = WillHitTarget();
    }

    public override bool WillHitTarget() => Random.Range(0f, 1f) < hitChance;

    public override void Execute() => GameService.Instance.ActionService.GetActionByType(CommandType.BerserkAttack).PerformAction(actorUnit, targetUnit, willHitTarget);


}
