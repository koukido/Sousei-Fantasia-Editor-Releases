using System.Numerics;
using SouseiFantasia;

public sealed class HelloScene : MonoBehaviour
{
    public string Message = "Scene Lab is running";

    private void Start()
    {
        var canvas = scene.Create_UI(SYSTEM_UI_Control_Kind.Canvas, "DemoCanvas");
        canvas.UI!.Reference_Size = new Vector2(1280, 720);

        var panel = scene.Create_UI(SYSTEM_UI_Control_Kind.Panel, "DemoPanel", canvas);
        panel.Object_2D.Size = new Vector2(640, 140);
        panel.UI!.Style.Normal = new Vector4(.03f, .05f, .08f, 1);
        panel.Material_2D.Color = Vector4.One;
        panel.UI.Raycast_Target = false;

        var label = scene.Create_UI(SYSTEM_UI_Control_Kind.Text, "DemoLabel", panel);
        label.Object_2D.Size = new Vector2(600, 100);
        var text = label.UI_Text!;
        text.Text = Message;
        text.Font_Size = 28;
        text.Color = Vector4.One;
        label.UI!.Raycast_Target = false;
    }
}
