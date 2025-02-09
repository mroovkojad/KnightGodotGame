using Godot;

public partial class ExportExample : Node3D
{
    [Export]
    public int Number { get; set; } = 5;
}