using System;
using System.IO;
using System.Threading.Tasks;
using SouseiFantasia;

public static class CaptureExample
{
    // Call after a game output context is bound. The caller observes this task.
    public static Task<SYSTEM_Game_Recording_Status> StartAsync()
    {
        return SYSTEM_Game_Recording.Start_Async(new SYSTEM_Game_Recording_Options
        {
            Output_Directory = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.MyVideos), "SceneLab"),
            Frames_Per_Second = 30,
            Max_Duration_Seconds = 120,
            Max_Output_Megabytes = 250,
            First_Frame_Timeout_Seconds = 120,
            Record_Audio = true,
            Record_Inputs = true,
            Record_Cursor = false
        });
    }

    public static SYSTEM_Game_Recording_Status Stop() => SYSTEM_Game_Recording.Stop();
}
