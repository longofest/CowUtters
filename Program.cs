/*
 * CowUtters. Its a play on Cow Udders... Because I'm funny like that
 * 
 * Author: Jeffrey Longo, a.k.a JLo
 * 
 * What It Does:
 * This program will take an input directory of json files that can be deserialized
 * into Utterance objects, analyze them to ensure they include complete sentences,
 * and merge text that trails from one speaker to the next that should be attributed
 * to the previous speaker.  The output is a single Utterances json file, which
 * is a json array of utterance objects that have been fixed.
 * 
 * For more information, please see the readme.md file included with the project.
 * 
 * Preconditions: Computer has enough memory to process the utterences
 * 
 * Postconditions: utterences.json file produced in current directory.  Errors and
 *  general run log will be printed to screen.
 *  
 *  
 * Areas for improvement (because this is what I can do in my free time and this
 *  is what I can do in my "free" time)
 *      - In this current implementation, this is more or less going to keep the
 *          directory of json objects in memory until it is done, at which time it
 *          will deserialize the Utterences object and exit.  Given a large enough
 *          working set, that could use an excessive amount of memory, potentially
 *          leading to program failure.  Given this is spoken text and we're trying
 *          to get results quickly for HW purposes, I'm accepting this outcome, but
 *          I'm documenting the potential need for refinement.  Likely refinement
 *          would come through saving to a file stream and then disposing the objects.
 *      - Don't just log errors to the screen. Use an logging facility.  This is
 *          the kind of thing that I would come across later and think "this sucks...
 *          who wrote it???" and then realize it was me...
 *      - The current implementation leaves some CaMeLcase. Considering the quality
 *          of the transcription, it doesn't seem that big of a deal, but room for
 *          improvement
 * 
 */

//Using directives
using System.Text.Json;
using System.IO;

namespace CowUtters
{

    public class Program
    {
        public static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            //Lets get to it.  Get my files
            Console.WriteLine("Examining files mapped to /infiles");
            int i = 0;

            Utterance? previous = null;
            Utterance? current = null;

            Utterances final = new Utterances();

            //for testing, i'm putting my personal directory here... todo: replace it with /infiles/ which will be what is used in docker
            foreach (string file in Directory.EnumerateFiles("/Users/jlongo/Library/Mobile Documents/com~apple~CloudDocs/aircoverHw/CowUtters/utterances/", "*.utterance.json")
                .OrderBy(filename => filename))
            {
                //get current file
                byte[] contents;
                try { 
                    contents = File.ReadAllBytes(file);
                }catch(IOException ioe) {
                    Console.WriteLine("IOException while processing file {0}: {1}", file, ioe.Message);

                    //this may not be the right decision, but for now let's just continue
                    continue;
                }

                var utf8Reader = new Utf8JsonReader(contents);
                current = JsonSerializer.Deserialize<Utterance>(ref utf8Reader);


                //temporary... just print it.
                if (current == null) {
                    Console.WriteLine("Utterance {0} is Null ???? (file {1})", i, file);
                }
                else
                {
                    Console.WriteLine("Utterance {0}: {1}", i, JsonSerializer.Serialize<Utterance>(current)); 
                }

                //speaker switch?
                if (current != null && !current.sameSpeaker(previous))
                {
                    Console.WriteLine("---Possible speaker switch: Check previous...");

                    if (previous != null && !previous.endsInPunctuation())//I shouldn't even be here if it is null, but better to check
                    {
                        Console.WriteLine("---Fragment Alert!!!  Fixing data...");

                        //TODO: take current up to first punctuation and append to previous
                        int fp = previous.indexOfLastPunctuation();
                        if (fp < 0 && !string.IsNullOrEmpty(current.text))
                        {
                            //No punctuation found... append entire thing
                            current.text = previous.text + " " + current.text;
                            previous = null;
                        }
                        else if(fp >= 0 && !string.IsNullOrEmpty(previous.text))
                        {
                            //append the portion we need
                            current.text = previous.text.Substring(fp+2, previous.text.Length - fp-2) + " " + current.text;
                            //trim previous down
                            previous.text = previous.text.Substring(0, fp);
                        }

                        if(previous != null)
                            Console.WriteLine("---New Previous: {0}", previous.text);
                        else
                            Console.WriteLine("---New Previous: blank");
                        if (current != null)
                            Console.WriteLine("---New Current: {0}", current.text);
                        else
                            Console.WriteLine("---New Current: blank");
                    }

                }

                //okay, previous should now be good to add to our final Utterances
                //but I'm only going to add it if it still has text
                if(previous != null && !string.IsNullOrWhiteSpace(previous.text)) { 
                    final.utterances.Add(previous);
                }

                //increment loop counter
                i++;

                //save for next round
                previous = current;
            }

            //add the last one
            if(current != null) { 
                final.utterances.Add(current);
            }



            var options = new JsonSerializerOptions { WriteIndented = true };

            //TODO: Write to /out/utterances.json the final object
            File.WriteAllBytes("/Users/jlongo/Desktop/final.json", JsonSerializer.SerializeToUtf8Bytes<Utterances>(final, options));

        }









    }

}