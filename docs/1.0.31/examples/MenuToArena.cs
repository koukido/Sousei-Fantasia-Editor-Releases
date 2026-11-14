using System;
using SouseiFantasia;

public sealed class MenuToArena : MonoBehaviour
{
    public string TargetScene = "Scenes/Arena.sfscene";
    private Guid ticket;
    private bool activationQueued;
    private bool failed;

    private void SystemUpdate()
    {
        if (failed || activationQueued) return;
        if (ticket == Guid.Empty)
        {
            try { ticket = SYSTEM_Game_Scene_Preloading.Begin(TargetScene); }
            catch (Exception error)
            {
                failed = true;
                Console.Error.WriteLine(error.Message);
            }
            return;
        }

        var status = SYSTEM_Game_Scene_Preloading.Get_Status(ticket);
        if (status == null || status.Is_Terminal)
        {
            failed = true;
            Console.Error.WriteLine(status == null ? "Preload ticket is unavailable."
                : "Preload ended: " + status.State + " " + status.Error);
            return;
        }

        var input = SYSTEM_Game_Input.Current;
        if (status.Can_Activate && input != null && input.Has_Focus && input.Key_Pressed(13))
            activationQueued = SYSTEM_Game_Scene_Preloading.Activate(
                ticket, SYSTEM_Scene_Activation_Mode.Replace);
    }

    private void End()
    {
        if (!activationQueued && ticket != Guid.Empty)
            SYSTEM_Game_Scene_Preloading.Cancel(ticket);
    }
}
