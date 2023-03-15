namespace Andreichuk_153505_lab1;

public partial class ProgressDemo : ContentPage
{
    private bool flag = true;
    public ProgressDemo()
    {
        InitializeComponent();
        progressBar.Progress = 0;
    }

    private async void OnStart(object sender, EventArgs e)
    {
        flag = true;
        StatusLabel.Text = "processing...";
        await Task.Run(() => CentralRectangle());
        StatusLabel.Text = "finished";
    }

    private void OnCancel(object sender, EventArgs e)
    {
        progressBar.Progress = 0;
        PercentLabel.Text = "0%";
        flag = false;
    }
    private void CentralRectangle()
    {
        var h = 0.00000001;
        var lastPercent = 1;
        var currentPercent = 0;
        double sum = 0;
        for (double i = 0; i < 1 + h; i += h)
        {
            sum += Math.Sin(i) * h;
            currentPercent = (int)(i * 100);
            if (currentPercent != lastPercent)
            {
                
                MainThread.BeginInvokeOnMainThread(() =>
                {
                    progressBar.Progress = currentPercent / 100.0;
                    PercentLabel.Text = currentPercent + "%";
                });
                lastPercent = currentPercent;
            }
            if (!flag) return;
        }
        MainThread.BeginInvokeOnMainThread(() =>
        {
            DisplayAlert("Result", $"{sum}", "OK");
        });
    }

}