# Dokumentacja techniczna — GraPuzzle

## Spis treści

1. [Przegląd projektu](#1-przegląd-projektu)
2. [Struktura projektu](#2-struktura-projektu)
3. [Architektura i przepływ nawigacji](#3-architektura-i-przepływ-nawigacji)
4. [Klasy i moduły](#4-klasy-i-moduły)
   - [Inventory](#41-inventory)
   - [MauiProgram](#42-mauiprogram)
   - [MainPage](#43-mainpage)
   - [Puzzle1](#44-puzzle1)
   - [Sypialnia](#45-sypialnia)
   - [dzieckopokoj](#46-dzieckopokoj)
   - [piwnica_wejscie](#47-piwnica_wejscie)
   - [piwnicaziemia](#48-piwnicaziemia)
   - [piwnicaza](#49-piwnicaza)
   - [InventoryPage](#410-inventorypage)
   - [end](#411-end)
   - [SettingsPage](#412-settingspage)
5. [System ekwipunku](#5-system-ekwipunku)
6. [Przedmioty i klucze](#6-przedmioty-i-klucze)
7. [Zagadki](#7-zagadki)
8. [Znane błędy i ograniczenia](#8-znane-błędy-i-ograniczenia)
9. [Zależności](#9-zależności)

---

## 1. Przegląd projektu

**GraPuzzle** to gra przygodowa z zagadkami, zbudowana w technologii **.NET MAUI**. Gracz eksploruje kolejne pomieszczenia nawiedzającego się domu, rozwiązuje zagadki logiczne, zbiera przedmioty i korzysta z nich, by odblokować nowe obszary. Celem jest dotarcie do ekranu końcowego poprzez wprowadzenie poprawnego kodu w zamku szyfrowym.

**Technologia:** .NET MAUI (C#, XAML)  
**Platforma docelowa:** Android / iOS / Windows  
**Wzorzec nawigacji:** NavigationPage (push/pop) + NavigationPage modalna dla ekwipunku i piwnicy

---

## 2. Struktura projektu

```
GraPuzzle/
├── MauiProgram.cs          # Punkt wejścia aplikacji, konfiguracja DI
├── MainPage.xaml/.cs       # Ekran głównego menu
├── SettingsPage.xaml/.cs   # Strona ustawień (szkielet)
├── Inventory.cs            # Statyczna klasa zarządzania ekwipunkiem
├── InventoryPage.xaml/.cs  # Modal wyświetlający ekwipunek
│
├── Puzzle1.xaml/.cs        # Pokój z zamkiem szyfrowym (główna zagadka)
├── Sypialnia.xaml/.cs      # Sypialnia — zagadka sekwencji obrazów
├── dzieckopokoj.xaml/.cs   # Pokój dziecięcy — zagadka liczby kliknięć
│
├── piwnica_wejscie.xaml/.cs   # Wejście do piwnicy
├── piwnicaziemia.xaml/.cs     # Podziemia (rozkopana piwnica)
├── piwnicaza.xaml/.cs         # Dalsza część piwnicy — trumna z kluczem
│
└── end.xaml/.cs            # Ekran końcowy gry
```

---

## 3. Architektura i przepływ nawigacji

Nawigacja między pokojami odbywa się za pomocą stosu nawigacyjnego (`Navigation.PushAsync`). Ekwipunek i niektóre sceny piwnicy otwierane są jako okna modalne (`Navigation.PushModalAsync`).

```
MainPage
    └── Puzzle1  ←──────────────────────────────────────────┐
         ├── [strzałka prawa] → dzieckopokoj                 │
         │        └── [strzałka prawa] → piwnica_wejscie     │
         │                  └── [klik obiektu] → piwnicaziemia (modal)
         │                              └── [klik] → piwnicaza (modal)
         │                                          └── [powrót] → Puzzle1 (modal) ─┘
         │
         └── [strzałka lewa] → Sypialnia
                   └── [strzałka lewa] → piwnica_wejscie

InventoryPage  ← dostępny jako modal z każdego pokoju
end            ← osiągany po wpisaniu poprawnego kodu w Puzzle1
```

---

## 4. Klasy i moduły

### 4.1 Inventory

**Plik:** `Inventory.cs`

Statyczna klasa odpowiedzialna za przechowywanie przedmiotów zebranych przez gracza. Używa prostej listy stringów.

| Składowa | Typ | Opis |
|---|---|---|
| `Items` | `static List<string>` | Lista nazw przedmiotów w ekwipunku |
| `Add(string item)` | `static void` | Dodaje przedmiot do listy |
| `Has(string item)` | `static bool` | Zwraca `true` jeśli przedmiot jest w liście |


---

### 4.2 MauiProgram

**Plik:** `MauiProgram.cs`

Punkt wejścia aplikacji. Konfiguruje framework MAUI, rejestruje czcionki, rejestruje `AudioManager` (Plugin.Maui.Audio) jako singleton oraz `MainPage` w kontenerze DI.

---

### 4.3 MainPage

**Plik:** `MainPage.xaml / MainPage.xaml.cs`

Ekran startowy z tłem graficznym (`menuzdj.png`) i przyciskiem Start.

| Metoda | Opis |
|---|---|
| `OnPlayClicked` | Przechodzi do `Puzzle1` |
| `OnSettingsClicked` | Przechodzi do `SettingsPage` (przycisk niezaimplementowany w XAML) |


---

### 4.4 Puzzle1

**Plik:** `Puzzle1.xaml / Puzzle1.xaml.cs`

Centralny pokój z zamkiem szyfrowym i trzema obiektami interaktywnymi.

**Pola:**

| Pole | Wartość | Opis |
|---|---|---|
| `enteredCode` | `""` | Aktualnie wpisany kod przez gracza |
| `correctCode` | `"6767"` | Poprawny kod odblokowania |

**Metody:**

| Metoda | Opis |
|---|---|
| `AddKeypadHotspots()` | Tworzy transparentne `BoxView` na klawiaturze cyfrowej (0–9 + OK) pozycjonowane absolutnie |
| `AddObjectHotspots()` | Tworzy obszary klikalne na trzech obiektach: serce, czaszka, lalka |
| `AddKey(value, x, y, w, h)` | Buduje pojedynczy klawisz klawiatury jako `BoxView` z `TapGestureRecognizer` |
| `OnKeyPressed(key)` | Obsługuje wpisywanie cyfr i zatwierdzanie kodu przyciskiem OK |
| `UpdateDisplay()` | Aktualizuje `Label` wyświetlający wpisywany kod (uzupełnia `_` do 4 znaków) |
| `AddHotspot(id, x, y, w, h)` | Buduje interaktywny obszar na obiekcie |
| `SetBoxBounds(box, x, y, w, h)` | Ustawia pozycję i rozmiar `BoxView` proporcjonalnie do rozmiaru layoutu |
| `OnHotspotTapped(id)` | Reaguje na kliknięcie obiektu — sprawdza ekwipunek |

**Logika klawiatury:** Hotspoty klawiatury nakładają się na grafikę klawiatury w tle. Pozycje są proporcjonalne — obliczane na podstawie rzeczywistego rozmiaru `MainLayout` po załadowaniu strony (`Loaded` event).

---

### 4.5 Sypialnia

**Plik:** `Sypialnia.xaml / Sypialnia.xaml.cs`

Pokój z zagadką sekwencji — gracz klika trzy obrazy zwierząt w określonej kolejności.

**Pola:**

| Pole | Wartość | Opis |
|---|---|---|
| `_correctSequence` | `["Raven", "Deer", "Goat"]` | Wymagana kolejność kliknięć |
| `_playerSequence` | `List<string>` | Sekwencja wpisana przez gracza |
| `_puzzleSolved` | `bool` | Flaga ukończenia zagadki |

**Metody:**

| Metoda | Opis |
|---|---|
| `OnRavenClicked / OnDeerClicked / OnGoatClicked` | Delegują do `RegisterClick` z odpowiednimi parametrami |
| `RegisterClick(animal, highlight, title, desc)` | Wspólna logika rejestracji kliknięcia: wyświetla opis, sprawdza duplikat, podświetla, waliduje krok sekwencji |
| `SolveAsync()` | Wyświetla alert sukcesu i dodaje `"Heart Key"` do ekwipunku |
| `ResetSequence()` | Czyści sekwencję gracza, ukrywa podświetlenia |
| `UpdateSequenceLabel()` | Aktualizuje debug label z aktualną sekwencją (domyślnie niewidoczny) |

**Walidacja:** Sprawdzanie odbywa się krok po kroku — jeśli bieżący krok nie pasuje do `_correctSequence[step]`, sekwencja jest resetowana. Kliknięcie tego samego zwierzęcia dwa razy również resetuje.

**Nagroda:** `"Heart Key"` — klucz używany w Puzzle1 przy obiekcie serce.

---

### 4.6 dzieckopokoj

**Plik:** `dzieckopokoj.xaml / dzieckopokoj.xaml.cs`

Pokój dziecięcy z zagadką liczby kliknięć na czterech obiektach.

**Pola:**

| Pole | Wymagana wartość | Opis |
|---|---|---|
| `blocksClicks` | `1` | Liczba kliknięć w klocki |
| `bearClicks` | `3` | Liczba kliknięć w misia |
| `tableClicks` | `4` | Liczba kliknięć w stół |
| `chestClicks` | `5` | Liczba kliknięć w skrzynię |
| `puzzleSolved` | `bool` | Flaga ukończenia zagadki |

**Walidacja:** Po każdym kliknięciu wywoływane jest `CheckPuzzle()`. Liczniki są ograniczane do maksymalnej wartości — po jej przekroczeniu gracz widzi komunikat `"Już nic się nie dzieje"`.

**Nagroda:** `"Baby Key"` — klucz używany w Puzzle1 przy obiekcie lalka.

---

### 4.7 piwnica_wejscie

**Plik:** `piwnica_wejscie.xaml / piwnica_wejscie.xaml.cs`

Scena przejściowa — wejście do piwnicy. Zawiera przycisk wejścia do podziemi (kliknięcie obszaru `Button_Clicked`), który otwiera `piwnicaziemia` jako modal.

---

### 4.8 piwnicaziemia

**Plik:** `piwnicaziemia.xaml / piwnicaziemia.xaml.cs`

Scena rozkopanych podziemi. Kliknięcie obszaru prowadzi do `piwnicaza`. Przycisk powrotu wraca do `piwnica_wejscie`.

---

### 4.9 piwnicaza

**Plik:** `piwnicaza.xaml / piwnicaza.xaml.cs`

Dalsza część piwnicy — scena z trumną.

| Zdarzenie | Opis |
|---|---|
| `Button_Clicked` | Powrót do `Puzzle1` (modal) |
| `Button_Clicked_1` | Otwiera trumnę — wyświetla alert z kodem `6767` i dodaje `"Skool Key"` do ekwipunku |

**Nagroda:** `"Skool Key"` — klucz używany w Puzzle1 przy obiekcie czaszka oraz kod `6767` do zamku szyfrowego.

---

### 4.10 InventoryPage

**Plik:** `InventoryPage.xaml / InventoryPage.xaml.cs`

Modal wyświetlający zawartość ekwipunku gracza.

**Słownik ikon:**

| Przedmiot | Ikona |
|---|---|
| Heart Key | 🗝 |
| Note | 📜 |
| Baby Key | 🗝 |
| Map | 🗺 |
| (inne) | 📦 |

**Metody:**

| Metoda | Opis |
|---|---|
| `LoadItems()` | Iteruje po `Inventory.Items`, buduje karty, lub pokazuje `EmptyLabel` |
| `BuildItemCard(icon, name)` | Tworzy `Frame` z ikoną i nazwą przedmiotu |
| `OnCloseClicked` | Zamyka modal przez `Navigation.PopModalAsync()` |

---

### 4.11 end

**Plik:** `end.xaml / end.xaml.cs`

Ekran końcowy wyświetlający napis `"The End?"` na graficznym tle. Brak dodatkowej logiki.

---

### 4.12 SettingsPage

**Plik:** `SettingsPage.xaml / SettingsPage.xaml.cs`

Strona ustawień w fazie szkicu. Wyświetla placeholder `"Coś tu będzie frfr"`. Brak implementacji faktycznych ustawień.

---

## 5. System ekwipunku

Ekwipunek jest zaimplementowany jako **statyczna lista stringów** w klasie `Inventory`. Oznacza to:

- Stan ekwipunku jest współdzielony przez całą aplikację (brak izolacji między instancjami stron).
- Ekwipunek **nie jest resetowany** po ponownym uruchomieniu gry w tej samej sesji aplikacji.
- Nie ma mechanizmu usuwania przedmiotów z ekwipunku.
- Wielokrotne ukończenie tej samej zagadki doda duplikaty przedmiotu.

Dostęp do ekwipunku z poziomu UI zapewniony jest przez przycisk `inventory_button.png` dostępny na każdej scenie gry (poza ekranem tytułowym i końcowym).

---

## 6. Przedmioty i klucze

| Przedmiot | Zdobywany w | Używany w |
|---|---|---|
| `Heart Key` | Sypialnia (zagadka sekwencji) | Puzzle1 — obiekt serce |
| `Baby Key` | Pokój dziecięcy (zagadka kliknięć) | Puzzle1 — obiekt lalka |
| `Skool Key` | Piwnicaza — trumna | Puzzle1 — obiekt czaszka |


---

## 7. Zagadki

### Zagadka 1 — Zamek szyfrowy (Puzzle1)
- **Pokój:** Puzzle1
- **Mechanika:** Gracz wprowadza 4-cyfrowy kod na klawiaturze numerycznej.
- **Poprawny kod:** `6767`
- **Skąd wziąć kod:** Z piwnicy — po otwarciu trumny w `piwnicaza`.
- **Sukces:** Przejście do ekranu końcowego (`end`).

### Zagadka 2 — Sekwencja obrazów (Sypialnia)
- **Pokój:** Sypialnia
- **Mechanika:** Gracz klika trzy obrazy zwierząt w określonej kolejności.
- **Poprawna kolejność:** Kruk → Jeleń → Koza
- **Wskazówka:** Brak wbudowanej wskazówki w grze.
- **Nagroda:** `Heart Key`

### Zagadka 3 — Liczba kliknięć (Pokój dziecięcy)
- **Pokój:** dzieckopokoj
- **Mechanika:** Gracz klika każdy obiekt określoną liczbę razy.
- **Poprawne wartości:** Klocki ×1, Miś ×3, Stół ×4, Skrzynia ×5
- **Wskazówka:** Brak wbudowanej wskazówki.
- **Nagroda:** `Baby Key`

### Zagadka 4 — Trumna (Piwnica)
- **Pokój:** piwnicaza
- **Mechanika:** Kliknięcie obszaru trumny.
- **Nagroda:** `Skool Key` + kod `6767`

---

---

## 8. Zależności

| Paczka | Wersja | Zastosowanie |
|---|---|---|
| .NET MAUI | — | Framework aplikacji |
| Plugin.Maui.Audio | — | Obsługa dźwięku (obecnie nieaktywna) |

**Zasoby graficzne wymagane w projekcie:**

- `menuzdj.png` — tło menu
- `przycisk_play.png` — przycisk Start
- `drzwi1.png` — tło Puzzle1
- `sypialnia.png` — tło sypialni
- `dziecko.png` — tło pokoju dziecięcego
- `piwnica2.png`, `piwnica3.png`, `piwnicarozkopanie.png` — tła piwnicy
- `zadrzwiamiend.png` — tło ekranu końcowego
- `strzalka.png` — ikona strzałki nawigacyjnej
- `back_button.png` — przycisk powrotu
- `inventory_button.png` — przycisk ekwipunku
