public class MainMenuModel{
    public string[] Options = {"Start", "Options", "ExitGame"};
    public int SelectedIndex { get; private set; } = 0;

    public void SelectOption(int index){
        SelectedIndex = index;
    }

}
