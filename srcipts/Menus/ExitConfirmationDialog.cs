using System;
using Godot;

public partial class ExitConfirmationDialog : ConfirmationDialog
{
    CheckBox doNotAskAgainCheckBox;

    public override void _Ready()
    {
        doNotAskAgainCheckBox = new CheckBox();
        Theme theme = new Theme();
        theme.SetFontSize("font_size", "CheckBox", 16);
        theme.SetFontSize("font_size", "Label", 24);
        theme.SetFontSize("font_size", "Button", 24);
        doNotAskAgainCheckBox.SetTheme(theme);
        doNotAskAgainCheckBox.Text = "Do not ask again?";
        doNotAskAgainCheckBox.Pressed += OnDoNotAskAgainCheckBoxPressed;
        this.SetTheme(theme);
        this.AddChild(doNotAskAgainCheckBox);
        this.SetTitle("Exit Game Confirmation");
		this.SetSize(new Vector2I(300, 150));
		this.DialogText = "Are you sure you want to exit the game?";
		this.GetCancelButton().Pressed += OnCancelExitGame;
		this.GetOkButton().Pressed += OnExitGameConfirmed;
    }

    private void OnDoNotAskAgainCheckBoxPressed()
    {
        // Save the state of the checkbox
    }
    private void OnExitGameConfirmed()
    {
        GetTree().Quit();
    }

    private void OnCancelExitGame()
    {
        this.Hide();
    }
}