using Godot;
using System;

public partial class MainMenu : Control
{
	// Called when the node enters the scene tree for the first time.
	private Button startButton;
	private Button optionsButton;
	private Button exitButton;
	SceneManager sceneManager; public override void _Ready()
	{
		sceneManager = (SceneManager)GetNode<SceneManager>("/root/SceneManager");
		startButton = GetNode<Button>("Start");
		optionsButton = GetNode<Button>("Options");
		exitButton = GetNode<Button>("ExitGame");
		startButton.Connect("pressed", new Callable(this, nameof(OnStartPressed)));
		optionsButton.Connect("pressed", new Callable(this, nameof(OnOptionsPressed)));
		exitButton.Connect("pressed", new Callable(this, nameof(OnExitGamePressed)));
	}
	private void OnStartPressed()
	{
		sceneManager.ChangeScene(MainScenes.Game);
	}

	private void OnOptionsPressed()
	{
		SceneManager.instance.ChangeScene(MainScenes.Options);
	}

	private void ShowExitConfirmationDialog()
	{
		GD.Print("Exit confirmation dialog shown");
		ExitConfirmationDialog exitConfirmationDialog = new ExitConfirmationDialog();
		this.AddChild(exitConfirmationDialog);
		exitConfirmationDialog.PopupCentered();
		exitConfirmationDialog.Show();

	}

	private void OnExitGamePressed()
	{
		ShowExitConfirmationDialog();
	}
}
