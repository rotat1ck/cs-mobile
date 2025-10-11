using System.ComponentModel;

namespace tictactoe{ 
    public partial class MainPage : ContentPage {
        private string CurrentChar = "X";
        private Button[][] buttons;

        public MainPage(){
            InitializeComponent();
            buttons = new Button[][] {
                new[] { r1c1, r1c2, r1c3 },
                new[] { r2c1, r2c2, r2c3 },
                new[] { r3c1, r3c2, r3c3 },
            };
        }

        private void Button_Clicked(object sender, EventArgs e) {
            Button? button = sender as Button;
            if (button != null && button.Text == null) {
                button.Text = CurrentChar;
                button.IsEnabled = false;
                
                CurrentChar = CurrentChar == "X" ? "O" : "X";
                Info.Text = $"Ходит: {CurrentChar}";

                Button[]? winnerButtons = CheckWinner();
                if (winnerButtons != null) {
                    Info.Text = $"Победил: {winnerButtons[0].Text}";
                    foreach (var winnerButton in winnerButtons) {
                        winnerButton.BackgroundColor = Color.FromRgb(243, 80, 80);
                    }
                    BlockFields();
                } else if (buttons.All(r => r.All(b => b.Text != null))) {
                    Info.Text = $"Ничья";
                }
            }
        }

        private Button[]? CheckWinner() {
            // Проверка горизонталей
            foreach (Button[] buttons in buttons) {
                var check = !string.IsNullOrEmpty(buttons[0].Text) && 
                    buttons[0].Text == buttons[1].Text && 
                    buttons[0].Text == buttons[2].Text;

                if (check) {
                    return buttons;
                }
            }

            // Проверка вертикалей
            for (int i = 0; i < buttons.Length; ++i) {
                var check = !string.IsNullOrEmpty(buttons[0][i].Text) &&
                    buttons[0][i].Text == buttons[1][i].Text &&
                    buttons[0][i].Text == buttons[2][i].Text;

                if (check) {
                    return new[] { buttons[0][i], buttons[1][i], buttons[2][i] };
                }
            }

            // Проверка диагоналей
            var check1 = !string.IsNullOrEmpty(buttons[0][0].Text) &&
                buttons[0][0].Text == buttons[1][1].Text &&
                buttons[0][0].Text == buttons[2][2].Text;

            if (check1) {
                return new[] { buttons[0][0], buttons[1][1], buttons[2][2] };
            }

            var check2 = !string.IsNullOrEmpty(buttons[0][2].Text) &&
                buttons[0][2].Text == buttons[1][1].Text &&
                buttons[0][2].Text == buttons[2][0].Text;

            if (check2) {
                return new[] { buttons[0][2], buttons[1][1], buttons[2][0] };
            }

            return null;
        }

        private void BlockFields() {
            foreach (var row in buttons) {
                foreach (var button in row) {
                    button.IsEnabled = false;
                }
            }
        }

        private void Reset_Clicked(object sender, EventArgs e) {
            foreach (var row in buttons) {
                foreach (var button in row) {
                    button.Text = null;
                    button.IsEnabled = true;
                    button.BackgroundColor = Color.FromRgb(180, 235, 230);
                }
            }

            CurrentChar = "X";
            Info.Text = $"Ходит: {CurrentChar}";
        }
    }
}
