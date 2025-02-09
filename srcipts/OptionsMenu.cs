using Godot;
using System;

public partial class OptionsMenu : Control
{
	CheckBox musicCheckBox;

	Button exitButton;
	AudioStreamPlayer2D music;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{

		try
		{
			GD.Print("Getting music node...");
			music = GetNode<AudioStreamPlayer2D>("/root/Music");

			GD.Print("Getting music checkbox...");
			musicCheckBox = (CheckBox) GetNode<CheckBox>("%MusicCheckBox");

			GD.Print("Connecting music checkbox toggled signal...");
			musicCheckBox.Connect("toggled", new Callable(this, nameof(OnMusicCheckBoxToggled)));

			GD.Print("Getting exit button...");
			exitButton = GetNode<Button>("%ExitButton");

			GD.Print("Connecting exit button pressed signal...");
			exitButton.Connect("pressed", new Callable(this, nameof(OnExitButtonPressed)));

			GD.Print("Setting music checkbox state...");
			musicCheckBox.ButtonPressed = music.Playing;
		}
		catch (Exception ex)
		{
			GD.PrintErr("An error occurred: " + ex.Message);
		}
	}

	private void OnMusicCheckBoxToggled(bool toggled_on)
	{
		switch (toggled_on)
		{
			case true:
				music.Play();
				break;
			case false:
				music.Stop();
				break;
		}
	}

	private void OnExitButtonPressed()
	{
		SceneManager.instance.ChangeScene(MainScenes.MainMenu);
	}
}
