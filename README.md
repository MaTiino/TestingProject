# Aplikacja Kalkulator i Operacje na Tekście

Aplikacja Windows Forms zawierająca dwie główne funkcjonalności: kalkulator z podstawowymi operacjami matematycznymi oraz zestaw operacji na tekście.

## Funkcjonalności

### Kalkulator
- Wykonywanie podstawowych operacji matematycznych:
  - Dodawanie
  - Odejmowanie
  - Mnożenie
  - Dzielenie
- Obsługa liczb dziesiętnych (z użyciem przecinka lub kropki)
- Walidacja danych wejściowych
- Wyświetlanie wyników w czasie rzeczywistym
- Obsługa błędów (np. dzielenie przez zero)

### Operacje na Tekście
- Liczenie samogłosek w tekście (włącznie z polskimi znakami: ą, ę, ó, y; wielkość liter nie ma znaczenia)
- Odwracanie tekstu (z automatycznym skróceniem długich wyników do 100 znaków i dodaniem „...”, jeśli wynik jest dłuższy)
- Liczenie słów w tekście
- Liczenie znaków w tekście
- Sprawdzanie czy tekst jest palindromem
- Ograniczenie długości wprowadzanego tekstu do 1000 znaków
- Automatyczne skracanie długich wyników (powyżej 100 znaków, z dodaniem „...”)

## Interfejs Użytkownika

### Wspólne cechy
- Nowoczesny, spójny wygląd z wykorzystaniem czcionki Segoe UI
- Responsywny układ dostosowujący się do rozmiaru okna
- Tooltips z opisami funkcji
- Wyraźne oznaczenie wyników
- Intuicyjna nawigacja między zakładkami

### Kalkulator
- Dwa pola tekstowe do wprowadzania liczb
- Cztery przyciski operacji matematycznych
- Przyciski równomiernie rozłożone i skalowane
- Pola tekstowe wyrównane i o równej szerokości

### Operacje na Tekście
- Pole tekstowe wieloliniowe do wprowadzania tekstu
- Pięć przycisków z różnymi operacjami
- Automatyczne zawijanie długich tekstów
- Wyświetlanie wyników w czytelnej formie

## Technologie

- C# .NET
- Windows Forms
- NUnit (dla testów jednostkowych)

## Struktura Projektu

```
TestingDemo/
├── TestingDemo.Core/           # Logika biznesowa
│   ├── Kalkulator.cs          # Implementacja kalkulatora
│   └── StringUtils.cs         # Operacje na tekście
├── TestingDemo.WinForms/      # Interfejs użytkownika
│   └── Form1.cs               # Główny formularz aplikacji
└── TestingDemo.Tests/         # Testy jednostkowe
    └── UnitTest1.cs           # Implementacja testów
```

## Testy

Aplikacja zawiera testy jednostkowe sprawdzające:
- Poprawność operacji matematycznych
- Działanie operacji na tekście
- Poprawność obsługi polskich znaków diakrytycznych (w tym samogłoski „ó”)
- Walidację danych wejściowych
- Ograniczenia długości tekstu

## Wymagania Systemowe

- Windows 10 lub nowszy
- .NET Framework 4.7.2 lub nowszy
- Minimalna rozdzielczość ekranu: 650x500 pikseli

## Uruchomienie

1. Sklonuj repozytorium
2. Otwórz rozwiązanie w Visual Studio
3. Skompiluj projekt
4. Uruchom aplikację

## Autor

Mateusz Toporek i Bartosz Tałanda
