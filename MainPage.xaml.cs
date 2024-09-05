using CommunityToolkit.Maui.Alerts;
using System.Diagnostics;

namespace maui_color_maker
{
  public partial class MainPage : ContentPage
  {
    bool isRandom;
    string hexValue;

    public MainPage()
    {
      InitializeComponent();
      isRandom = false;
      hexValue = "#000000";
    }

    private void Slider_ValueChanged(object sender, ValueChangedEventArgs e)
    {
      if (isRandom)
      {
        return;
      }

      var red = sliderRed.Value;
      var green = sliderGreen.Value;
      var blue = sliderBlue.Value;

      Color color = Color.FromRgb(red, green, blue);
      SetColor(color);
    }

    private void SetColor(Color color)
    {
      Debug.WriteLine(color.ToString());
      buttonRandom.BackgroundColor = color;
      Container.BackgroundColor = color;
      hexValue = color.ToHex();
      labelHex.Text = hexValue;
    }

    private void ButtonRandom_Clicked(object sender, EventArgs e)
    {
      isRandom = true;

      var random = new Random();
      var color = Color.FromRgb(
        random.Next(0, 256),
        random.Next(0, 256),
        random.Next(0, 256)
      );
      SetColor(color);

      sliderRed.Value = color.Red;
      sliderGreen.Value = color.Green;
      sliderBlue.Value = color.Blue;

      isRandom = false;
    }

    private async void ImageButton_Clicked(object sender, EventArgs e)
    {
      await Clipboard.SetTextAsync(hexValue);

      var toast = Toast.Make("Color Copied", CommunityToolkit.Maui.Core.ToastDuration.Short, 12);
      await toast.Show();
    }
  }
}
