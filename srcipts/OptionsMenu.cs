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
		music = GetNode<AudioStreamPlayer2D>("/root/Music");
		musicCheckBox = GetNode<CheckBox>("MusicCheckBox");
		musicCheckBox.Connect("toggled", new Callable(this, nameof(OnMusicCheckBoxToggled)));

		exitButton = GetNode<Button>("ExitButton");
		exitButton.Connect("pressed", new Callable(this, nameof(OnExitButtonPressed)));
	}

	private void OnMusicCheckBoxToggled(bool buttonPressed)
	{
		switch (buttonPressed)
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
