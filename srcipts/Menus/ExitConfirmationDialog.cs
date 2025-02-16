using System;
using Godot;

public partial class ExitConfirmationDialog : ConfirmationDialog
{
    CheckBox doNotAskAgainCheckBox;

    public override void _Ready()
    {
        doNotAskAgainCheckBox = new CheckBox();
      //  doNotAskAgainCheckBox.Theme = new ThemeManager().GetTheme("MinorTextTheme");
        Theme theme = new Theme();
        theme.SetFontSize("font_size", "CheckBox", 8);
        doNotAskAgainCheckBox.Theme = theme;
        doNotAskAgainCheckBox.Text = "Do not ask again?";
        doNotAskAgainCheckBox.Pressed += OnDoNotAskAgainCheckBoxPressed;
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
    public ExitConfirmationDialog()
    {
        this.SetTitle("Exit Game Confirmation");
        this.SetTitle("Exit Game Confirmation");
		this.SetSize(new Vector2I(300, 150));
		this.DialogText = "Are you sure you want to exit the game?";
		this.GetCancelButton().Pressed += OnCancelExitGame;
		this.GetOkButton().Pressed += OnExitGameConfirmed;
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