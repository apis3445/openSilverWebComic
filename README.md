# ComicOpenSilver

A comic-strip creator built with [OpenSilver](https://opensilver.net/) (Silverlight on WebAssembly). Drop images into the six comic panels, add speech bubbles or thought clouds, type text, and print or save your comic.

## Prerequisites

| Tool             | Version                 | Install                               |
| ---------------- | ----------------------- | ------------------------------------- |
| .NET SDK         | 10.0+                   | https://dotnet.microsoft.com/download |
| A modern browser | Chrome / Edge / Firefox | —                                     |

Check your .NET version:

```bash
dotnet --version
```

## Running the app

The app is served from the **Browser** project (Blazor WebAssembly host). Run from the repo root:

```bash
dotnet run --project ComicOpenSilver.Browser
```

Then open the URL shown in the terminal (usually `http://localhost:55592`).

> **Tip:** Add `--launch-profile` if you want to use a specific profile from `launchSettings.json`.

### Hot reload

```bash
dotnet watch --project ComicOpenSilver.Browser
```

## Building without running

```bash
# Core library only
dotnet build ComicOpenSilver/ComicOpenSilver.csproj

# Both projects
dotnet build ComicOpenSilver.sln
```

## Publishing (static files for deployment)

```bash
dotnet publish ComicOpenSilver.Browser -c Release -o ./publish
```

The `publish/wwwroot` folder contains the fully self-contained static site. Drop it on any static host (GitHub Pages, Azure Static Web Apps, Netlify, etc.).

## Project structure

```
ComicOpenSilver/           # OpenSilver class library (XAML + C#)
  MainPage.xaml            # Main UI layout (6 comic panels + toolbar)
  MainPage.xaml.cs         # Code-behind: event handlers, figure management
  cFigura.cs               # Speech-bubble / figure model and rendering

ComicOpenSilver.Browser/   # Blazor WebAssembly host
  wwwroot/
    Images/                # Balloon / speech-bubble images served statically
      nube_izquierda.png
      nube_derecha1.png
      ovalo_derecha1.png
      ovalo_izquierda1.png
      rectangulo_derecha1.png
      rectangulo_izquierdo1.png
      rectangulo1.png
    index.html             # App entry point
```

## Using the app

### Adding speech bubbles to your comic

1. Type the bubble text in the **"Texto a insertar"** box (top-left toolbar).
2. Click one of the shape buttons to place it on the canvas:
   - **Nube Izq / Nube Der** — left/right cloud bubble
   - **Óvalo Izq / Óvalo Der** — left/right oval bubble
   - **Cuadro Izq / Cuadro Der** — left/right rectangle bubble
   - **Cuadro** — plain rectangle
3. The new figure appears in the main canvas. Select it in the **ComboBox** and drag it to the desired position.

### Adding panel background images

Drag an image file (`.jpg`, `.png`, or `.gif`) from your computer and **drop it onto one of the six coloured comic panels**. The image fills the panel.

### Managing figures

| Button   | Action                                                     |
| -------- | ---------------------------------------------------------- |
| Borrar   | Remove the currently selected figure                       |
| Nuevo    | Clear the entire comic                                     |
| Guardar  | Save the comic layout to isolated storage (`WebComic.xml`) |
| Abrir    | Load a previously saved comic                              |
| Imprimir | Print the comic                                            |

### Selecting a figure to move

Use the **ComboBox** (labelled list of figures) to select which figure is active. Then click and drag it on the main canvas.
