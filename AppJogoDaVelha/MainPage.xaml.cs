using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;

namespace AppJogoDaVelha
{
    public partial class MainPage : ContentPage
    {
        string vez = "X";

        public MainPage()
        {
            InitializeComponent();
        }

        private void Check_Win()
        {
            if (n_jogadas >= 9)
            {
                DisplayAlert("Que pena", "Deu velha!", "Ok");
                Reset_Buttons();
            }
            string[] linha_1 = {button_10.Text, button_11.Text, button_12.Text};
            string[] linha_2 = {button_20.Text, button_21.Text, button_22.Text };
            string[] linha_3 = {button_30.Text, button_31.Text, button_32.Text };

            string[] coluna_1 = { button_10.Text, button_20.Text, button_30.Text };
            string[] coluna_2 = { button_11.Text, button_21.Text, button_31.Text };
            string[] coluna_3 = { button_12.Text, button_22.Text, button_32.Text };

            string[] diagonal_1 = { button_10.Text, button_21.Text, button_32.Text };
            string[] diagonal_2 = { button_30.Text, button_21.Text, button_12.Text };

            string[][] condicoes_vitoria = { linha_1, linha_2, linha_3, coluna_1, coluna_2, coluna_3, diagonal_1, diagonal_2 };

            foreach (string[] condicao in condicoes_vitoria)
            {
                if (condicao[0] == "X" && condicao[1] == "X" && condicao[2] == "X")
                {
                    DisplayAlert("Parabéns", "O X ganhou!", "Ok");
                    Reset_Buttons();

                } 
                else if (condicao[0] == "O" && condicao[1] == "O" && condicao[2] == "O")
                {
                    DisplayAlert("Parabéns", "O O ganhou!", "Ok");
                    Reset_Buttons();
                }

            }




        }

        private void Reset_Buttons()
        {
            Button[] all_buttons = {button_10,button_11,button_12,button_20,button_21,button_22,button_30,button_31,button_32};
            foreach (Button button in all_buttons)
            {
                button.Text= "";
                button.IsEnabled = true;
            }
        }





        private async void Button_Clicked(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            btn.IsEnabled = false;

            btn.Text = vez;
            if (vez == "X")
            {
                vez = "O";
            }
            else
            {
                vez = "X";
            }

            Check_Win();
        }


    }
}
