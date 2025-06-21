using NUnit.Framework;
using NUnit.Framework.Internal;
using TestingDemo.Core;
using System.Threading.Tasks;
using System.Collections.Generic;
using System;

namespace TestingDemo.Tests;

[TestFixture]
[Category("Kalkulator")]
public class KalkulatorTests
{
    private Kalkulator _kalkulator;

    [OneTimeSetUp]
    public void OneTimeSetUp()
    {
        // Inicjalizacja testów kalkulatora
    }

    [SetUp]
    public void SetUp() => _kalkulator = new Kalkulator();

    [Test]
    public void Dodaj_ZwracaPoprawnyWynik()
    {
        Assert.That(_kalkulator.Dodaj(2.5, 3.7), Is.EqualTo(6.2).Within(0.0001));
    }

    [TestCase(0.9, 3.2, 2.3)]
    [TestCase(0.0, 0.0, 0.0)]
    [TestCase(0.1, -1.2, -1.3)]
    [TestCase(0.1, 0.2, 0.1)]
    public void Odejmij_RozneWartosci_ZwracaPoprawnyWynik(double oczekiwany, double a, double b)
    {
        var wynik = _kalkulator.Odejmij(a, b);
        Assert.That(wynik, Is.EqualTo(oczekiwany).Within(0.0001), 
            $"Odejmowanie {a} - {b} powinno dać {oczekiwany}, ale dało {wynik}");
    }

    [TestCase(7.5, 2.5, 3.0)]
    [TestCase(-6.0, -2.0, 3.0)]
    [TestCase(0.0, 0.0, 5.0)]
    [TestCase(0.25, 0.5, 0.5)]
    public void Pomnoz_RozneWartosci_ZwracaPoprawnyWynik(double oczekiwany, double a, double b)
    {
        Assert.That(_kalkulator.Pomnoz(a, b), Is.EqualTo(oczekiwany).Within(0.0001));
    }

    [TestCase(2.5, 5.0, 2.0)]
    [TestCase(-2.0, -6.0, 3.0)]
    [TestCase(0.0, 0.0, 5.0)]
    [TestCase(0.5, 0.25, 0.5)]
    public void Podziel_RozneWartosci_ZwracaPoprawnyWynik(double oczekiwany, double a, double b)
    {
        Assert.That(_kalkulator.Podziel(a, b), Is.EqualTo(oczekiwany).Within(0.0001));
    }

    [Test]
    public void Podziel_DzieleniePrzezZero_RzucaWyjatek()
    {
        Assert.Throws<DivideByZeroException>(() => _kalkulator.Podziel(5.0, 0.0));
    }

    [Test, Ignore("Przykład testu ignorowanego")]
    public void IgnorowanyTest()
    {
        Assert.Fail("Ten test jest ignorowany");
    }

    [TearDown]
    public void TearDown() => _kalkulator = null;

    [OneTimeTearDown]
    public void OneTimeTearDown()
    {
        // Czyszczenie po testach kalkulatora
    }
}

[TestFixture]
[Category("Tekst")]
public class StringUtilsTests
{
    [TestCase("kajak", true)]
    [TestCase("Ala", false)]
    [TestCase("", true)]
    public void CzyPalindrom_Test(string tekst, bool oczekiwany)
    {
        Assert.That(StringUtils.CzyPalindrom(tekst), Is.EqualTo(oczekiwany));
    }

    [Test]
    public void CzyPalindrom_Null_ZwracaFalse()
    {
        Assert.That(StringUtils.CzyPalindrom(null), Is.False);
    }

    [Test]
    public void PoliczSamogloski_ZliczaPoprawnie()
    {
        Assert.Multiple(() => {
            Assert.That(StringUtils.PoliczSamogloski("Ala ma kota"), Is.EqualTo(5));
            Assert.That(StringUtils.PoliczSamogloski("xyz"), Is.EqualTo(1));
            Assert.That(StringUtils.PoliczSamogloski("mój stół"), Is.EqualTo(2)); // 'ó' i 'ó'
            Assert.That(StringUtils.PoliczSamogloski("Ósmy"), Is.EqualTo(2)); // 'Ó' i 'y'
        });
    }

    [Test]
    public void OdwrocTekst_SkracaDlugiTekst()
    {
        // Arrange
        string dlugiTekst = new string('a', 200);
        
        // Act
        string wynik = StringUtils.OdwrocTekst(dlugiTekst);
        
        // Assert
        Assert.That(wynik.Length, Is.EqualTo(StringUtils.MaxOutputLength));
        Assert.That(wynik.EndsWith("..."), Is.True);
    }

    [Test]
    public void OdwrocTekst_ZbytDlugiTekst_RzucaWyjatek()
    {
        // Arrange
        string zbytDlugiTekst = new string('a', StringUtils.MaxInputLength + 1);
        
        // Act & Assert
        var ex = Assert.Throws<ArgumentException>(() => StringUtils.OdwrocTekst(zbytDlugiTekst));
        Assert.That(ex.Message, Does.Contain(StringUtils.MaxInputLength.ToString()));
    }

    [Test]
    public void PoliczSlowa_ZbytDlugiTekst_RzucaWyjatek()
    {
        // Arrange
        string zbytDlugiTekst = new string('a', StringUtils.MaxInputLength + 1);
        
        // Act & Assert
        var ex = Assert.Throws<ArgumentException>(() => StringUtils.PoliczSlowa(zbytDlugiTekst));
        Assert.That(ex.Message, Does.Contain(StringUtils.MaxInputLength.ToString()));
    }

    [Test]
    public void PoliczZnaki_ZbytDlugiTekst_RzucaWyjatek()
    {
        // Arrange
        string zbytDlugiTekst = new string('a', StringUtils.MaxInputLength + 1);
        
        // Act & Assert
        var ex = Assert.Throws<ArgumentException>(() => StringUtils.PoliczZnaki(zbytDlugiTekst));
        Assert.That(ex.Message, Does.Contain(StringUtils.MaxInputLength.ToString()));
    }

    [Test]
    public void OdwrocTekst_MaksymalnaDlugoscTekstu_ZwracaPoprawnyWynik()
    {
        // Arrange
        string maksymalnyTekst = new string('a', StringUtils.MaxInputLength);
        
        // Act
        string wynik = StringUtils.OdwrocTekst(maksymalnyTekst);
        
        // Assert
        Assert.That(wynik.Length, Is.EqualTo(StringUtils.MaxOutputLength));
        Assert.That(wynik.EndsWith("..."), Is.True);
    }
}

[TestFixture]
[Category("Async")]
public class AsyncUtilsTests
{
    [Test]
    public async Task PobierzLiczbePoCzasieAsync_ZwracaLiczbe()
    {
        var wynik = await AsyncUtils.PobierzLiczbePoCzasieAsync(7, 10);
        Assert.That(wynik, Is.EqualTo(7));
    }
}

[TestFixture]
[Category("Wyjątki")]
public class ExceptionUtilsTests
{
    [Test]
    public void RzucCustomException_RzucaCustomException()
    {
        var ex = Assert.Throws<CustomException>(() => ExceptionUtils.RzucCustomException("Błąd!"));
        Assert.That(ex.Message, Is.EqualTo("Błąd!"));
    }
}

[TestFixture]
[Category("Kolekcje i typy")]
public class KolekcjeTypyTests
{
    [Test]
    public void TestKolekcji()
    {
        var lista = new List<int> { 1, 2, 3 };
        Assert.That(lista, Has.Exactly(3).Items);
        Assert.That(lista, Does.Contain(2));
    }

    [Test]
    public void TestTypu()
    {
        object liczba = 5;
        Assert.That(liczba, Is.TypeOf<int>());
    }

    [Test]
    public void TestNull()
    {
        string tekst = null;
        Assert.That(tekst, Is.Null);
    }
}