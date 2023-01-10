namespace ViewModel

open System.ComponentModel
open Microsoft.FSharp.Quotations.Patterns

type ViewModelBase () =
    let mutable loading = false;
    let propertyChanged = Event<PropertyChangedEventHandler,PropertyChangedEventArgs>()
    
    let getPropertyName = function
        | PropertyGet(_,pi,_) -> pi.Name
        | _ -> invalidOp "Expecting property getter expression"
    
    interface INotifyPropertyChanged with
        [<CLIEvent>]
        member this.PropertyChanged = propertyChanged.Publish
    
    member private this.NotifyPropertyChanged propertyName = 
        propertyChanged.Trigger(this,PropertyChangedEventArgs(propertyName))
    
    member this.NotifyPropertyChanged quotation = 
        quotation |> getPropertyName |> this.NotifyPropertyChanged
        

    member this.Loading
        with get() = loading 
        and set(value) =
            loading <- value
            this.NotifyPropertyChanged(<@ this.Loading @>)

    member this.WindowTitle
        with get() = "Schere Stein Papier by Robert Stickler & Dominik Pilz"