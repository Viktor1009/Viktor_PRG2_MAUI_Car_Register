namespace PRG_MAUI_Car_Register.view;

public partial class CarPage : ContentPage
{
	public CarPage()
	{
		InitializeComponent();
		BindingContext = new CarViewModel();
	}
}