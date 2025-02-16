using Godot;
using System;
using System.Collections.Generic;
public partial class MainMenuView : Control
{
    [Signal] public delegate void OptionSelectedEventHandler(int index);

    private PackedScene _menuButtonScene;
    private List<MenuButton> _menuButtons = new List<MenuButton>();

    private MainMenuView _view;

    private MainMenuModel _model;

    private Container _mainButtonsContainer;

    public override void _Ready()
    {
        _menuButtonScene = GD.Load<PackedScene>("res://scripts/Menus/MenuButton.tscn");
        _view = GetNode<MainMenuView>("MainMenu");
        _mainButtonsContainer = _view.GetNode<VBoxContainer>("MainButtonsContainer");
        _model = new MainMenuModel();
        var children = _mainButtonsContainer.GetChildren();
        var buttonList = new List<Button>();

        foreach (var child in children)
        {
            if (child is Button button)
                buttonList.Add(button);
        }

        string[] menuOptions = _model.Options;

        for (int i = 0; i < menuOptions.Length; i++)
        {
            MenuButton menuButton = (MenuButton)_menuButtonScene.Instantiate();
            menuButton.SetLabel(menuOptions[i]);
            AddChild(menuButton);
            _menuButtons.Add(menuButton);

            int index = i; // Capture index for lambda
            menuButton.Pressed += () => EmitSignal(nameof(OptionSelectedEventHandler), index);
        }
    }
}
