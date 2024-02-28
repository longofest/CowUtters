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
 * Postconditions: utterences.json file produced in current directory.  Errors 
 *  will be printed to screen.
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
 * 
 */

//Using directives
using System.Text.Json;

namespace CowUtters
{

    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Goodbye cruel world");

        }

    }

}