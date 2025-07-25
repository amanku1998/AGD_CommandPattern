using Command.Main;
using Command.Actions;
public class HealCommand : UnitCommand
{
    private bool willHitTarget;
    public HealCommand(CommandData commandData)
    {
        this.commandData = commandData;
        willHitTarget = WillHitTarget();
    }

    public override void Execute() => GameService.Instance.ActionService.GetActionByType(CommandType.Heal).PerformAction(actorUnit, targetUnit, willHitTarget);
    public override bool WillHitTarget() => true;
}
