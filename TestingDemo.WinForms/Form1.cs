using System;
using System.Windows.Forms;
using TestingDemo.Core;
using System.Drawing;

namespace TestingDemo.WinForms;

public partial class Form1 : Form
{
    private readonly Kalkulator _kalkulator;
    private TextBox txtLiczba1;
    private TextBox txtLiczba2;
    private Label lblWynik;
    private TextBox txtTekst;
    private Label lblWynikTekst;
    private Button btnSprawdzPalindrom;
    private Button btnPoliczSamogloski;
    private Button btnDodaj;
    private Button btnOdejmij;
    private Button btnPomnoz;
    private Button btnPodziel;
    private TextBox _textInput;

    public Form1()
    {
        InitializeComponent();
        _kalkulator = new Kalkulator();
        InitializeKalkulator();
        InitializeTekst();

        // Ustawienie minimalnego rozmiaru okna
        this.MinimumSize = new Size(650, 500);
        this.StartPosition = FormStartPosition.CenterScreen;
    }

    private void InitializeKalkulator()
    {
        var tabKalkulator = new TabPage("Kalkulator");
        var panel = new TableLayoutPanel
        {
            Dock = DockStyle.Fill,
            ColumnCount = 1,
            RowCount = 2,
            Padding = new Padding(20),
            BackColor = Color.WhiteSmoke,
            RowStyles = {
                new RowStyle(SizeType.Percent, 85),
                new RowStyle(SizeType.Percent, 15)
            }
        };

        // Grupa kalkulatora
        var calcGroup = new GroupBox
        {
            Text = "Kalkulator",
            Dock = DockStyle.Fill,
            Font = new Font("Segoe UI", 10, FontStyle.Regular),
            ForeColor = Color.DarkSlateGray,
            Padding = new Padding(10)
        };

        var innerPanel = new TableLayoutPanel
        {
            Dock = DockStyle.Fill,
            ColumnCount = 2,
            RowCount = 4,
            Padding = new Padding(10),
            ColumnStyles = {
                new ColumnStyle(SizeType.Absolute, 120),
                new ColumnStyle(SizeType.Percent, 100)
            },
            RowStyles = {
                new RowStyle(SizeType.Absolute, 40),
                new RowStyle(SizeType.Absolute, 40),
                new RowStyle(SizeType.Absolute, 60),
                new RowStyle(SizeType.Percent, 100)
            }
        };

        // Etykiety i pola tekstowe
        var lblLiczba1 = new Label
        {
            Text = "Pierwsza liczba:",
            Font = new Font("Segoe UI", 10, FontStyle.Regular),
            ForeColor = Color.DarkSlateGray,
            AutoSize = true,
            Anchor = AnchorStyles.Left | AnchorStyles.Right,
            TextAlign = ContentAlignment.MiddleLeft
        };

        txtLiczba1 = new TextBox
        {
            Font = new Font("Segoe UI", 10, FontStyle.Regular),
            BorderStyle = BorderStyle.FixedSingle,
            Height = 30,
            Anchor = AnchorStyles.Left | AnchorStyles.Right,
            Margin = new Padding(0, 5, 0, 5)
        };

        var lblLiczba2 = new Label
        {
            Text = "Druga liczba:",
            Font = new Font("Segoe UI", 10, FontStyle.Regular),
            ForeColor = Color.DarkSlateGray,
            AutoSize = true,
            Anchor = AnchorStyles.Left | AnchorStyles.Right,
            TextAlign = ContentAlignment.MiddleLeft
        };

        txtLiczba2 = new TextBox
        {
            Font = new Font("Segoe UI", 10, FontStyle.Regular),
            BorderStyle = BorderStyle.FixedSingle,
            Height = 30,
            Anchor = AnchorStyles.Left | AnchorStyles.Right,
            Margin = new Padding(0, 5, 0, 5)
        };

        // Przyciski operacji
        var buttonPanel = new TableLayoutPanel
        {
            Dock = DockStyle.Fill,
            ColumnCount = 4,
            RowCount = 1,
            Margin = new Padding(0, 10, 0, 0),
            ColumnStyles = {
                new ColumnStyle(SizeType.Percent, 25),
                new ColumnStyle(SizeType.Percent, 25),
                new ColumnStyle(SizeType.Percent, 25),
                new ColumnStyle(SizeType.Percent, 25)
            }
        };

        btnDodaj = new Button
        {
            Text = "Dodaj",
            Font = new Font("Segoe UI", 10, FontStyle.Regular),
            BackColor = Color.SteelBlue,
            ForeColor = Color.White,
            FlatStyle = FlatStyle.Flat,
            Height = 35,
            Cursor = Cursors.Hand,
            Dock = DockStyle.Fill,
            Margin = new Padding(5)
        };
        btnDodaj.Click += (s, e) => WykonajOperacje(_kalkulator.Dodaj);

        btnOdejmij = new Button
        {
            Text = "Odejmij",
            Font = new Font("Segoe UI", 10, FontStyle.Regular),
            BackColor = Color.SteelBlue,
            ForeColor = Color.White,
            FlatStyle = FlatStyle.Flat,
            Height = 35,
            Cursor = Cursors.Hand,
            Dock = DockStyle.Fill,
            Margin = new Padding(5)
        };
        btnOdejmij.Click += (s, e) => WykonajOperacje(_kalkulator.Odejmij);

        btnPomnoz = new Button
        {
            Text = "Pomnóż",
            Font = new Font("Segoe UI", 10, FontStyle.Regular),
            BackColor = Color.SteelBlue,
            ForeColor = Color.White,
            FlatStyle = FlatStyle.Flat,
            Height = 35,
            Cursor = Cursors.Hand,
            Dock = DockStyle.Fill,
            Margin = new Padding(5)
        };
        btnPomnoz.Click += (s, e) => WykonajOperacje(_kalkulator.Pomnoz);

        btnPodziel = new Button
        {
            Text = "Podziel",
            Font = new Font("Segoe UI", 10, FontStyle.Regular),
            BackColor = Color.SteelBlue,
            ForeColor = Color.White,
            FlatStyle = FlatStyle.Flat,
            Height = 35,
            Cursor = Cursors.Hand,
            Dock = DockStyle.Fill,
            Margin = new Padding(5)
        };
        btnPodziel.Click += (s, e) => WykonajOperacje(_kalkulator.Podziel);

        buttonPanel.Controls.AddRange(new Control[] { btnDodaj, btnOdejmij, btnPomnoz, btnPodziel });

        // Dodanie elementów do wewnętrznego panelu
        innerPanel.Controls.Add(lblLiczba1, 0, 0);
        innerPanel.Controls.Add(txtLiczba1, 1, 0);
        innerPanel.Controls.Add(lblLiczba2, 0, 1);
        innerPanel.Controls.Add(txtLiczba2, 1, 1);
        innerPanel.Controls.Add(buttonPanel, 0, 2);
        innerPanel.SetColumnSpan(buttonPanel, 2);

        calcGroup.Controls.Add(innerPanel);

        // Kontener wyniku
        var resultContainer = new Panel
        {
            Dock = DockStyle.Fill,
            Padding = new Padding(0, 5, 0, 0)
        };

        // Etykieta wyniku
        lblWynik = new Label
        {
            Text = "Wynik: ",
            Font = new Font("Segoe UI", 12, FontStyle.Bold),
            ForeColor = Color.DarkSlateGray,
            AutoSize = true,
            Dock = DockStyle.Fill,
            TextAlign = ContentAlignment.MiddleLeft
        };

        resultContainer.Controls.Add(lblWynik);

        // Dodanie elementów do głównego panelu
        panel.Controls.Add(calcGroup);
        panel.Controls.Add(resultContainer);

        // Dodanie tooltipów
        var tooltip = new ToolTip();
        tooltip.SetToolTip(txtLiczba1, "Wprowadź pierwszą liczbę (możesz użyć przecinka lub kropki jako separatora dziesiętnego)");
        tooltip.SetToolTip(txtLiczba2, "Wprowadź drugą liczbę (możesz użyć przecinka lub kropki jako separatora dziesiętnego)");
        tooltip.SetToolTip(btnDodaj, "Dodaje dwie liczby");
        tooltip.SetToolTip(btnOdejmij, "Odejmuje drugą liczbę od pierwszej");
        tooltip.SetToolTip(btnPomnoz, "Mnoży dwie liczby");
        tooltip.SetToolTip(btnPodziel, "Dzieli pierwszą liczbę przez drugą");

        tabKalkulator.Controls.Add(panel);
        tabControl1.TabPages.Add(tabKalkulator);
    }

    private void InitializeTekst()
    {
        var tabTekst = new TabPage("Operacje na tekście");
        var panel = new TableLayoutPanel
        {
            Dock = DockStyle.Fill,
            ColumnCount = 1,
            RowCount = 3,
            Padding = new Padding(20),
            BackColor = Color.WhiteSmoke,
            RowStyles = {
                new RowStyle(SizeType.Percent, 100),
                new RowStyle(SizeType.Absolute, 60)
            }
        };
        
        // Grupa operacji na tekście
        var textGroup = new GroupBox
        {
            Text = "Operacje na tekście",
            Dock = DockStyle.Fill,
            Font = new Font("Segoe UI", 10, FontStyle.Regular),
            ForeColor = Color.DarkSlateGray,
            Padding = new Padding(10)
        };

        var innerPanel = new TableLayoutPanel
        {
            Dock = DockStyle.Fill,
            ColumnCount = 2,
            RowCount = 5,
            Padding = new Padding(10),
            ColumnStyles = {
                new ColumnStyle(SizeType.Percent, 50),
                new ColumnStyle(SizeType.Percent, 50)
            },
            RowStyles = {
                new RowStyle(SizeType.Absolute, 30),
                new RowStyle(SizeType.Percent, 100),
                new RowStyle(SizeType.Absolute, 45),
                new RowStyle(SizeType.Absolute, 45),
                new RowStyle(SizeType.Absolute, 45)
            }
        };

        // Pole wejściowe z etykietą
        var inputLabel = new Label
        {
            Text = "Wprowadź tekst:",
            Font = new Font("Segoe UI", 10, FontStyle.Regular),
            ForeColor = Color.DarkSlateGray,
            AutoSize = true,
            Anchor = AnchorStyles.Left | AnchorStyles.Right,
            TextAlign = ContentAlignment.MiddleLeft
        };

        _textInput = new TextBox
        {
            Multiline = true,
            Font = new Font("Segoe UI", 10, FontStyle.Regular),
            BorderStyle = BorderStyle.FixedSingle,
            Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom,
            MaxLength = 1000
        };

        // Przyciski operacji z opisami
        var countVowelsButton = new Button
        {
            Text = "Policz samogłoski",
            Font = new Font("Segoe UI", 10, FontStyle.Regular),
            BackColor = Color.SteelBlue,
            ForeColor = Color.White,
            FlatStyle = FlatStyle.Flat,
            Height = 35,
            Cursor = Cursors.Hand,
            Anchor = AnchorStyles.Left | AnchorStyles.Right,
            Margin = new Padding(0, 5, 5, 5)
        };
        countVowelsButton.Click += (s, e) =>
        {
            var result = StringUtils.PoliczSamogloski(_textInput.Text);
            lblWynikTekst.Text = $"Liczba samogłosek: {result}";
        };

        var reverseButton = new Button
        {
            Text = "Odwróć tekst",
            Font = new Font("Segoe UI", 10, FontStyle.Regular),
            BackColor = Color.SteelBlue,
            ForeColor = Color.White,
            FlatStyle = FlatStyle.Flat,
            Height = 35,
            Cursor = Cursors.Hand,
            Anchor = AnchorStyles.Left | AnchorStyles.Right,
            Margin = new Padding(5, 5, 0, 5)
        };
        reverseButton.Click += (s, e) =>
        {
            var result = StringUtils.OdwrocTekst(_textInput.Text);
            if (result.Length > 100)
            {
                result = result.Substring(0, 97) + "...";
            }
            lblWynikTekst.Text = $"Odwrócony tekst: {result}";
        };

        var countWordsButton = new Button
        {
            Text = "Policz słowa",
            Font = new Font("Segoe UI", 10, FontStyle.Regular),
            BackColor = Color.SteelBlue,
            ForeColor = Color.White,
            FlatStyle = FlatStyle.Flat,
            Height = 35,
            Cursor = Cursors.Hand,
            Anchor = AnchorStyles.Left | AnchorStyles.Right,
            Margin = new Padding(0, 5, 5, 5)
        };
        countWordsButton.Click += (s, e) =>
        {
            var result = StringUtils.PoliczSlowa(_textInput.Text);
            lblWynikTekst.Text = $"Liczba słów: {result}";
        };

        var countCharsButton = new Button
        {
            Text = "Policz znaki",
            Font = new Font("Segoe UI", 10, FontStyle.Regular),
            BackColor = Color.SteelBlue,
            ForeColor = Color.White,
            FlatStyle = FlatStyle.Flat,
            Height = 35,
            Cursor = Cursors.Hand,
            Anchor = AnchorStyles.Left | AnchorStyles.Right,
            Margin = new Padding(5, 5, 0, 5)
        };
        countCharsButton.Click += (s, e) =>
        {
            var result = StringUtils.PoliczZnaki(_textInput.Text);
            lblWynikTekst.Text = $"Liczba znaków: {result}";
        };

        var checkPalindromButton = new Button
        {
            Text = "Sprawdź palindrom",
            Font = new Font("Segoe UI", 10, FontStyle.Regular),
            BackColor = Color.SteelBlue,
            ForeColor = Color.White,
            FlatStyle = FlatStyle.Flat,
            Height = 35,
            Cursor = Cursors.Hand,
            Anchor = AnchorStyles.Left | AnchorStyles.Right,
            Margin = new Padding(0, 5, 0, 5)
        };
        checkPalindromButton.Click += (s, e) =>
        {
            var result = StringUtils.CzyPalindrom(_textInput.Text);
            lblWynikTekst.Text = $"Czy palindrom: {(result ? "Tak" : "Nie")}";
        };

        // Dodanie elementów do wewnętrznego panelu
        innerPanel.Controls.Add(inputLabel, 0, 0);
        innerPanel.SetColumnSpan(inputLabel, 2);
        innerPanel.Controls.Add(_textInput, 0, 1);
        innerPanel.SetColumnSpan(_textInput, 2);
        innerPanel.Controls.Add(countVowelsButton, 0, 2);
        innerPanel.Controls.Add(reverseButton, 1, 2);
        innerPanel.Controls.Add(countWordsButton, 0, 3);
        innerPanel.Controls.Add(countCharsButton, 1, 3);
        innerPanel.Controls.Add(checkPalindromButton, 0, 4);
        innerPanel.SetColumnSpan(checkPalindromButton, 2);

        // Dodanie podpowiedzi (tooltip) do przycisków
        var tooltip = new ToolTip();
        tooltip.SetToolTip(_textInput, "Wprowadź tekst do analizy (maksymalnie 1000 znaków)");
        tooltip.SetToolTip(countVowelsButton, "Zlicza liczbę samogłosek (a, e, i, o, u, y, ą, ę) w tekście");
        tooltip.SetToolTip(reverseButton, "Odwraca kolejność znaków w tekście (wynik zostanie skrócony jeśli przekroczy 100 znaków)");
        tooltip.SetToolTip(countWordsButton, "Zlicza liczbę słów w tekście (słowa oddzielone spacjami)");
        tooltip.SetToolTip(countCharsButton, "Zlicza liczbę wszystkich znaków w tekście");
        tooltip.SetToolTip(checkPalindromButton, "Sprawdza czy tekst jest palindromem (czytany od lewej do prawej i od prawej do lewej jest taki sam)");

        textGroup.Controls.Add(innerPanel);

        // Kontener wyniku
        var resultContainer = new Panel
        {
            Dock = DockStyle.Fill,
            Padding = new Padding(0, 10, 0, 10)
        };

        // Etykieta wyniku
        lblWynikTekst = new Label
        {
            Text = "Wynik: ",
            Font = new Font("Segoe UI", 12, FontStyle.Bold),
            ForeColor = Color.DarkSlateGray,
            AutoSize = false,
            Dock = DockStyle.Fill,
            TextAlign = ContentAlignment.MiddleLeft,
            AutoEllipsis = true
        };

        resultContainer.Controls.Add(lblWynikTekst);

        panel.Controls.Add(textGroup);
        panel.Controls.Add(resultContainer);
        tabTekst.Controls.Add(panel);
        tabControl1.TabPages.Add(tabTekst);
    }

    private void WykonajOperacje(Func<double, double, double> operacja)
    {
        try
        {
            // Konwertuj przecinki na kropki i usuń spacje
            string liczba1 = txtLiczba1.Text.Trim().Replace(',', '.');
            string liczba2 = txtLiczba2.Text.Trim().Replace(',', '.');

            if (!double.TryParse(liczba1, System.Globalization.NumberStyles.Any, 
                System.Globalization.CultureInfo.InvariantCulture, out double a) || 
                !double.TryParse(liczba2, System.Globalization.NumberStyles.Any, 
                System.Globalization.CultureInfo.InvariantCulture, out double b))
            {
                MessageBox.Show("Wprowadź poprawne liczby! Możesz używać przecinka lub kropki jako separatora dziesiętnego.", 
                    "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var wynik = operacja(a, b);
            lblWynik.Text = $"Wynik: {wynik:F4}";
        }
        catch (DivideByZeroException)
        {
            MessageBox.Show("Nie można dzielić przez zero!", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Wystąpił błąd: {ex.Message}", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
