using PRG_MAUI_Car_Register.viewmodel;

namespace PRG_MAUI_Car_Register.view;

public partial class TruckPage : ContentPage
{
	public TruckPage()
	{
		InitializeComponent();
		BindingContext = new TruckViewModel();

    }
}