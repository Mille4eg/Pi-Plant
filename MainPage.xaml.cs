namespace Pi_Plant;

public partial class MainPage : ContentPage
{
    string userName = "friend";
    string selectedSex = "";

    int dailyWaterGoal = 9;
    int cupsDrank = 0;

    double userWeight = 180;
    int dailyStepGoal = 8000;

    public MainPage()
    {
        InitializeComponent();
        UpdateScreen();
    }

    private async void Profile_Tapped(object sender, TappedEventArgs e)
    {
        string result = await DisplayPromptAsync(
            "Profile",
            "What should Pi-Plant call you?",
            "Save",
            "Cancel",
            "Enter your name");

        if (!string.IsNullOrWhiteSpace(result))
        {
            userName = result;
            UpdateScreen();
        }
    }

    private void FemaleButton_Clicked(object sender, EventArgs e)
    {
        selectedSex = "Female";
        dailyWaterGoal = 9;
        cupsDrank = 0;

        FemaleButton.BackgroundColor = Color.FromArgb("#46957D");
        FemaleButton.TextColor = Colors.White;

        MaleButton.BackgroundColor = Color.FromArgb("#DCECEC");
        MaleButton.TextColor = Color.FromArgb("#103B4D");

        UpdateScreen();
    }

    private void MaleButton_Clicked(object sender, EventArgs e)
    {
        selectedSex = "Male";
        dailyWaterGoal = 13;
        cupsDrank = 0;

        MaleButton.BackgroundColor = Color.FromArgb("#46957D");
        MaleButton.TextColor = Colors.White;

        FemaleButton.BackgroundColor = Color.FromArgb("#DCECEC");
        FemaleButton.TextColor = Color.FromArgb("#103B4D");

        UpdateScreen();
    }

    private void DrinkWater_Clicked(object sender, EventArgs e)
    {
        if (cupsDrank < dailyWaterGoal)
        {
            cupsDrank++;
        }

        UpdateScreen();
    }

    private void RemoveWater_Clicked(object sender, EventArgs e)
    {
        if (cupsDrank > 0)
        {
            cupsDrank--;
        }

        UpdateScreen();
    }

    private void WeightSlider_ValueChanged(object sender, ValueChangedEventArgs e)
    {
        userWeight = e.NewValue;

        if (userWeight < 100)
            dailyStepGoal = 6000;
        else if (userWeight < 150)
            dailyStepGoal = 7000;
        else if (userWeight < 200)
            dailyStepGoal = 8000;
        else
            dailyStepGoal = 9000;

        UpdateScreen();
    }

    private void UpdateScreen()
    {
        HelloLabel.Text = $"Hello, {userName}!";

        GoalLabel.Text = $"Daily Goal: {dailyWaterGoal} cups of water";
        WaterCountLabel.Text = $"{cupsDrank} / {dailyWaterGoal}";

        WaterProgressBar.Progress =
            (double)cupsDrank / dailyWaterGoal;

        WeightLabel.Text = $"{(int)userWeight} lbs";
        StepGoalLabel.Text = $"{dailyStepGoal:N0} steps";

        int cupsRemaining = dailyWaterGoal - cupsDrank;

        if (cupsDrank == 0)
        {
            PlantEmojiLabel.Text = "🟫";
            PlantStatusLabel.Text = "Add water to begin growing!";
        }
        else if (cupsDrank == 1)
        {
            PlantEmojiLabel.Text = "🌰";
            PlantStatusLabel.Text = $"{cupsRemaining} cups remaining!";
        }
        else if (cupsDrank <= 5)
        {
            PlantEmojiLabel.Text = "🌱";
            PlantStatusLabel.Text = $"{cupsRemaining} cups remaining!";
        }
        else if (cupsDrank <= 8)
        {
            PlantEmojiLabel.Text = "🌿";
            PlantStatusLabel.Text = $"{cupsRemaining} cups remaining!";
        }
        else
        {
            PlantEmojiLabel.Text = "🌸";

            if (cupsRemaining > 0)
                PlantStatusLabel.Text = $"{cupsRemaining} cups remaining!";
            else
                PlantStatusLabel.Text = "Water goal completed!";
        }
    }
}