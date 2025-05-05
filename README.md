# 🧩 SudokuSolverForms

Dies ist ein Sudoku-Löser mit grafischer Benutzeroberfläche (Windows Forms) in **C#**.  
Ursprünglich wurde der Lösungsalgorithmus in einer **Konsolenanwendung** entwickelt und getestet. Anschließend wurde das Projekt zu einer **Windows Forms App** weiterentwickelt.

---

## 🔧 Features

- Sudoku-Rätsel eingeben und automatisch lösen
- Laden von Beispielen zum Test
- 9×9 Gitteranzeige über `DataGridView`
- Eingetragene Zahlen können visuell unterschieden werden
- Fehlerbehandlung und Hilfsklassen strukturiert gekapselt
  
---

## ▶️ Verwendung

1. App herunterladen ➡️ [Download aktuelle Version (ZIP)](https://github.com/jako1o/SudokuSolver/releases/latest)
2. Zip entpacken - die App muss nicht installiert werden - lediglich das .NET Framework muss installiert sein
3. zu lösendes Sudoku eingeben - Lösen klicken - fertig!
4. optional kann über den Button "Besipiel laden" ein solches geladen werden, um die Funktion zu testen
   
⚠️ **Hinweis zur Windows-Sicherheitsmeldung**

Beim ersten Start blockiert Windows evtl. die Anwendung mit folgender Meldung:

> *„Der Computer wurde durch Windows geschützt“*

So kannst du die App trotzdem starten:
1. Klicke auf **"Weitere Informationen"**
2. Klicke auf **"Trotzdem ausführen"**

---

## 🧠 Wie funktioniert der Sudoku-Algorithmus?

Der Sudoku-Solver verwendet einen **rekursiven Backtracking-Algorithmus**, um das Rätsel zu lösen:

1. **Leere Zelle suchen:**  
   Der Algorithmus sucht die nächste freie Zelle im Gitter (also eine Zelle mit dem Wert 0).

2. **Mögliche Zahlen ausprobieren (1–9):**  
   Für jede leere Zelle wird geprüft, welche Zahlen dort erlaubt sind – das heißt:
   - Nicht in derselben Zeile
   - Nicht in derselben Spalte
   - Nicht im selben 3×3 Block

3. **Zahl einsetzen und rekursiv lösen:**  
   Eine gültige Zahl wird eingesetzt, und der Algorithmus ruft sich selbst auf, um die nächste Zelle zu füllen.

4. **Zurücksetzen bei Sackgasse (Backtracking):**  
   Wenn keine gültige Zahl mehr passt, wird die Zelle geleert (Backtracking) und die vorherige Zelle mit einer anderen Zahl versucht.

5. **Lösung gefunden:**  
   Wenn das gesamte Gitter ohne Widersprüche gefüllt ist, ist die Lösung gefunden.

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

## 📃 Lizenz

Dieses Projekt steht unter der [MIT-Lizenz](LICENSE).

---

## ✍️ Autor

Erstellt von jako1o und wasdiesename  
Fragen oder Ideen? Gerne via GitHub-Issues.
