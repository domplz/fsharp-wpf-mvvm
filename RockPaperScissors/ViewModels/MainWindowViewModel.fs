namespace ViewModel

open System.Windows.Input

type MainWindowViewModel() =
    inherit ViewModelBase()
    let mutable firstName = "Dominik"
    let mutable lastName = "Pilz"

    member this.FirstName
        with get() = firstName 
        and set(value) =
            firstName <- value
            base.NotifyPropertyChanged(<@ this.FirstName @>)
            base.NotifyPropertyChanged(<@ this.FullName @>)

    member this.LastName
        with get() = lastName 
        and set(value) =
            lastName <- value
            base.NotifyPropertyChanged(<@ this.LastName @>)
            base.NotifyPropertyChanged(<@ this.FullName @>)

    member this.FullName
        with get() = sprintf "%s %s" (this.FirstName) (this.LastName)
        
    member this.Command: ICommand = 
        Command.createCommand
            (fun arg -> (
                this.FirstName <- "working"
            ))
            (fun _ -> true)
