open System
open System.Windows
open System.Windows.Controls
open System.Windows.Markup
open ViewModel

// props to https://putridparrot.com/blog/creating-a-wpf-application-in-f/
// no props https://learn.microsoft.com/en-us/archive/msdn-magazine/2011/september/fsharp-programming-build-mvvm-applications-in-fsharp
// https://bizmonger.wordpress.com/2015/11/25/mvvm-with-f-tutorial/
[<STAThread>]
[<EntryPoint>]
let main argv = 
    let mainWindow = Application.LoadComponent(System.Uri("/RockPaperScissors;component/MainWindow.xaml", UriKind.Relative)) :?> Window
    
    // no way to do this in XAML
    mainWindow.DataContext <- new MainWindowViewModel()

    let application = new Application()
    application.Run(mainWindow)