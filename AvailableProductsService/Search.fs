module Search

open System

type MusicContract = 
    {
        Artist : string
        Title : string
        Usages : string
        StartDate : string
        EndDate : string
    }

let convertData lines =
    let convertToMusicContract (line: string) =
        let lineArray = line.Split '|'
        {
            Artist = lineArray[0]
            Title = lineArray[1]
            Usages = lineArray[2]
            StartDate = lineArray[3]
            EndDate = lineArray[4]
        }

    lines |> Seq.map (fun line -> convertToMusicContract line)

let searchITunes date lines =
    lines 
    |> Seq.tail 
    |> convertData 
    |> Seq.filter(fun contract -> contract.Usages.Contains("digital download"))
    |> Seq.filter(fun contract -> contract.StartDate <= date)
    |> Seq.map (fun contract -> {contract with Usages = "digital download"})

let searchYoutube date lines =
    lines 
    |> Seq.tail 
    |> convertData 
    |> Seq.filter(fun contract -> contract.Usages.Contains("streaming"))
    |> Seq.filter(fun contract -> contract.StartDate <= date)
    |> Seq.map (fun contract -> {contract with Usages = "streaming"})
