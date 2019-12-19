namespace TypedPersistence.FSharp

open LiteDB.FSharp
open System
open System.Security.Cryptography
open System.Text

[<AutoOpen>]
module Types =
    type FSharpBsonMapperWithGenerics() as this =
        inherit FSharpBsonMapper()
        let resolveCollectionName = this.ResolveCollectionName

        do this.ResolveCollectionName <- Func<Type,string>(
            fun t ->
                if t.IsGenericType then
                    t.FullName |> hash |> string
                else
                    resolveCollectionName.Invoke(t)
        )

    type GenericEntry<'T> =
        {
            id: string
            entry: 'T
        }

    type LoadError =
    | DocumentNotExisting