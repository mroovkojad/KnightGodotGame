using Godot;

public partial class MenuController : Node
{
    private MainMenuModel _model;
    private MainMenuView _view;

    public override void _Ready()
    {
        _model = new MainMenuModel();
        _view = GetNode<MainMenuView>("MainMenuView");
    }

    private void OnOptionSelected(int index)
    {
        ExecuteOption(index);
    }

    private void ExecuteOption(int index)
    {
        switch (index)
        {
            case 0: GD.Print("Start Game"); break;
            case 1: GD.Print("Open Options"); break;
            case 2: GetTree().Quit(); break;
        }
    }
}
