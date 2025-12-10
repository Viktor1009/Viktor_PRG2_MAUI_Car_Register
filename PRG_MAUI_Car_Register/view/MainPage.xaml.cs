using PRG_MAUI_Car_Register.viewmodel;
using PRG_MAUI_Car_Register.model;

namespace PRG_MAUI_Car_Register.view;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
        BindingContext = new MainPageModelView();
    }
}