# 🧩 SudokuSolverForms

Dies ist ein Sudoku-Löser mit grafischer Benutzeroberfläche (Windows Forms) in **C#**.  
Ursprünglich wurde der Lösungsalgorithmus in einer **Konsolenanwendung** entwickelt und getestet. Anschließend wurde das Projekt zu einer **Windows Forms App** weiterentwickelt.

---

## 🔧 Features

- Sudoku-Rätsel eingeben und automatisch lösen
- Manuelles Zurücksetzen des Gitters
- 9×9 Gitteranzeige über `DataGridView`
- Visualisierung der 3×3 Blöcke durch zusätzliche Zelllinien
- Eingetragene Zahlen können visuell unterschieden werden
- Fehlerbehandlung und Hilfsklassen strukturiert gekapselt

---

## 📁 Projektstruktur

```
SudokuSolverForms
├── Enums
│   └── ErrorCode.cs            // Fehler-Codes für Rückgaben
├── Forms
│   ├── Form1.cs                // Hauptformular mit UI
│   └── SudokuGUI.cs            // Steuerung und UI-Logik
├── Helpers
│   ├── GridHelper.cs           // Hilfsmethoden (z. B. Reset)
│   └── SudokuTestData.cs       // Beispiel-Daten für Testzwecke
├── Logic
│   ├── SudokuSolver.cs         // Der Algorithmus zum Lösen
│   └── SudokuGrid.cs           // Datenmodell für das Sudoku-Raster
├── Resources
│   └── SudokuSolverIcon.ico    // App-Icon
```

---

## ▶️ Verwendung

1. Projekt in Visual Studio öffnen
2. Build-Konfiguration auf `Release` setzen
3. Erstellen mit `Strg + Umschalt + B`
4. Starten mit `F5` oder `Start`-Button

---

## 📦 Veröffentlichung

Wenn du eine `.exe` erstellen möchtest:
- Im Menü: `Build > Projektmappe veröffentlichen`
- Oder über `dotnet publish` für eine self-contained Version

---

## 💡 Beispiel-Screenshots oder GIFs (optional)

*(Hier kannst du später Bilder deiner App einfügen)*

---

## 📃 Lizenz

*(Falls du eine Lizenz hinzufügen willst – z. B. MIT)*

---

## ✍️ Autor

> Erstellt von [Dein Name oder Nickname]  
> Fragen oder Ideen? Gerne via GitHub-Issues.