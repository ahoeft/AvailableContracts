module Search

open System

type Usage = 
    | Youtube
    | ITunes

type MusicContract = 
    {
        Artist : string
        Title : string
        Usages : Usage list
        StartDate : string
        EndDate : string
    }

let convertData lines =
    let getUsagesFromString str =
            match str with
            | "digital download, streaming" -> [ITunes;Youtube]
            | "streaming" -> [Youtube]
            | "digital download" -> [ITunes]
            | _ -> []

    let convertToMusicContract (line: string) =
        let lineArray = line.Split '|'
        {
            Artist = lineArray[0]
            Title = lineArray[1]
            Usages = getUsagesFromString (lineArray[2])
            StartDate = lineArray[3]
            EndDate = lineArray[4]
        }

    lines |> Seq.map (fun line -> convertToMusicContract line)


let convertUsagesToString usages =
    match usages with
    | [ITunes;Youtube] -> "digital download, streaming" 
    | [Youtube]-> "streaming" 
    | [ITunes]-> "digital download" 
    | _ -> ""

let convertContractToOutputString contract =
    let usages = convertUsagesToString contract.Usages
    $"{contract.Artist}|{contract.Title}|{usages}|{contract.StartDate}|{contract.EndDate}"

let searchITunes date lines =
    lines 
    |> Seq.tail 
    |> convertData 
    |> Seq.filter(fun contract -> List.contains ITunes contract.Usages)
    |> Seq.filter(fun contract -> contract.StartDate <= date)
    |> Seq.map(fun contract -> convertContractToOutputString contract)

let searchYoutube date lines =
    lines 
    |> Seq.tail 
    |> convertData 
    |> Seq.filter(fun contract -> List.contains Youtube contract.Usages)
    |> Seq.filter(fun contract -> contract.StartDate <= date)
    |> Seq.map(fun contract -> convertContractToOutputString contract)
