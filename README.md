#  GraPuzzle

Przygodowa gra logiczna zbudowana w **.NET MAUI**. Gracz eksploruje nawiedzony dom, rozwiązuje zagadki, zbiera klucze i stara się wydostać — wpisując odkryty kod w zamku szyfrowym.

---

##  Opis gry

Gracz porusza się między pokojami domu za pomocą strzałek nawigacyjnych. Każdy pokój kryje zagadkę lub sekret:

- **Sypialnia** — kliknij obrazy zwierząt w odpowiedniej kolejności, zdobądź klucz serca
- **Pokój dziecięcy** — kliknij przedmioty odpowiednią liczbę razy, zdobądź klucz lalki
- **Piwnica** — znajdź trumnę, zdobądź klucz czaszki i kod do zamka
- **Główny pokój** — wpisz 4-cyfrowy kod, otwórz drzwi i wyjdź

Zebrane przedmioty trafiają do ekwipunku dostępnego w każdej chwili z poziomu przycisku w rogu ekranu.

---

##  Wymagania

- [.NET 8 SDK](https://dotnet.microsoft.com/download)
- [Visual Studio 2022](https://visualstudio.microsoft.com/) z workloadem **.NET MAUI**
- Android SDK (do uruchomienia na emulatorze / urządzeniu Android)

---

##  Uruchomienie

```bash
# Klonuj repozytorium
git clone https://github.com/twoj-login/GraPuzzle.git
cd GraPuzzle

# Przywróć paczki NuGet
dotnet restore

# Uruchom na emulatorze Android
dotnet build -t:Run -f net8.0-android
```

Możesz też otworzyć solucję w **Visual Studio** i uruchomić projekt przez `F5` na wybranym urządzeniu / emulatorze.

---

##  Struktura projektu

```
GraPuzzle/
├── MauiProgram.cs          # Konfiguracja aplikacji i DI
├── Inventory.cs            # Globalny ekwipunek gracza
├── InventoryPage.xaml/.cs  # Modal ekwipunku
│
├── MainPage.xaml/.cs       # Menu główne
├── SettingsPage.xaml/.cs   # Ustawienia (WIP)
│
├── Puzzle1.xaml/.cs        # Pokój z zamkiem szyfrowym
├── Sypialnia.xaml/.cs      # Zagadka sekwencji obrazów
├── dzieckopokoj.xaml/.cs   # Zagadka kliknięć
│
├── piwnica_wejscie.xaml/.cs
├── piwnicaziemia.xaml/.cs
├── piwnicaza.xaml/.cs
│
└── end.xaml/.cs            # Ekran końcowy
```

---

##  Zagadki — wskazówki

<details>
<summary>Sypialnia — zagadka trzech obrazów</summary>

Na ścianie wiszą trzy obrazy zwierząt. Kliknij je w odpowiedniej kolejności — zacznij od tego, który kojarzy się z nocą. Za jednym z nich kryje się wnęka z kluczem w kształcie serca.

</details>

<details>
<summary>Pokój dziecięcy — zagadka kliknięć</summary>

W pokoju są cztery przedmioty: klocki, miś, stół i skrzynia. Każdy z nich należy kliknąć określoną liczbę razy — od najmniejszej do największej. Skrzynia wymaga najwięcej uwagi. Gdy trafisz w odpowiednią kombinację, skrzynia się otworzy.

</details>

<details>
<summary>Piwnica — zejdź głębiej</summary>

Z wejścia do piwnicy prowadzi ukryte przejście. Po drodze mijasz rozkopany korytarz — idź dalej. Na końcu stoi trumna, a w środku czeka klucz i liczba, której szukasz.

</details>

---

##  Zależności

| Paczka | Zastosowanie |
|---|---|
| [Plugin.Maui.Audio](https://github.com/jfversluis/Plugin.Maui.Audio) | Obsługa dźwięku (gotowe, nieaktywne) |

---

##  Status projektu

| Funkcja | Status |
|---|---|
| Nawigacja między pokojami | ✅ Gotowe |
| Zagadka szyfrowa (Puzzle1) | ✅ Gotowe |
| Zagadka sekwencji (Sypialnia) | ✅ Gotowe |
| Zagadka kliknięć (Pokój dziecięcy) | ✅ Gotowe |
| System ekwipunku | ✅ Gotowe |
| Muzyka / dźwięk | ✅ Gotowe |


---

##  Licencja

[MIT](LICENSE)
