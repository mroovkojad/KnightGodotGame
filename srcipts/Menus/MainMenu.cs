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
		VBoxContainer vbox = GetNode<VBoxContainer>("VBoxContainer2/CenterContainer/VBoxContainer");
		startButton = vbox.GetNode<Button>("Start");
		optionsButton = vbox.GetNode<Button>("Options");
		exitButton = vbox.GetNode<Button>("ExitGame");

		ConnectButtonSignals();
	}

	private void ConnectButtonSignals()
	{
		if (!startButton.IsConnected("pressed", new Callable(this, nameof(OnStartPressed))))
		{
			startButton.Connect("pressed", new Callable(this, nameof(OnStartPressed)));
			GD.Print("Connected start button");
		}
		if (!optionsButton.IsConnected("pressed", new Callable(this, nameof(OnOptionsPressed))))
		{
			optionsButton.Connect("pressed", new Callable(this, nameof(OnOptionsPressed)));
			GD.Print("Connected options button");
		}
		if (!exitButton.IsConnected("pressed", new Callable(this, nameof(OnExitGamePressed))))
		{
			exitButton.Connect("pressed", new Callable(this, nameof(OnExitGamePressed)));
			GD.Print("Connected exit button");
		}
	}
	private void OnStartPressed()
	{
		sceneManager.ChangeScene(MainScenes.Game);
	}

	private void OnOptionsPressed()
	{
		sceneManager.ChangeScene(MainScenes.Options);
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
