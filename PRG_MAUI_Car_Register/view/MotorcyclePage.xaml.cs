namespace PRG_MAUI_Car_Register.view;

public partial class MotorcyclePage : ContentPage
{
	public MotorcyclePage()
	{
		InitializeComponent();
		BindingContext = new MotorcycleViewModel();

    }
}