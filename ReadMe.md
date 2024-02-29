# ReadMe for an Amazing Udderance, er, Utterance parser-fixer-thing

This project is [Jeffrey Longo]'s' homework to be the 8th employee of the company that is reinventing the way sales is performed and will signglehandedly prevent the next economic recession (company name deliberately witheld).

For convenience, the application is provided not only as source but container form so you don't need to download .net... you just need to install docker and pull the container from [docker hub] as specified below.

## Assumptions

There are a couple of assumptions that the application makes about the input that was not specified in the instructions.  If this was more complicated of a thing I would probably not make these assumptions and get more clarity before diving in, but as it is these assumptions are probably "safe" (famous last words).

- The input json files will be UTF-8 encoded
- The input json files will all be of the form "{timestampMs}.utterance.json"
-- As such, processing the files in ascending file name order would yield the order in which the utterances were provided by the speech-to-text processor during the conversation
- The text under inspection, for the purposes of this exercise, will be limited to English and is interpreted Left-To-Right

> You know what happens when you Assume things...
> You make an ASS out of YOU and ME...
> ~Some genius I'm clearly ignoring

## Quick Start Instructions (Arm64)

1. Install [Docker Desktop] if you have not done so already.  For this use it qualifies for use under the free license.  If you use docker cli (without the desktop portion), then that's just fine too, but docker desktop wraps qemu emulation (or utilizes Rosetta on Mac if you enable it) so you can pull and run images that don't match your platform.  You can still set that up with docker cli, but its more steps and I don't cover it here, as the Full Instructions below will make that unnecessary.
2. docker pull longofest/cowutters
3. docker run -v [path-to-utterances]:/infiles -v [path-where-you-want-output]:/out longofest/cowutters

## Full Instructions

Even the full instructions include using docker because I'm sadistic, but with these instructions you can ensure you are running the code committed here.  This also helps if you are running on an architecture other than
Arm64 so you don't have to deal with QEMU.

1. git clone https://github.com/longofest/CowUtters.git or git clone git@github.com:longofest/CowUtters.git
2. cd CowUtters
3. docker buildx built -t longofest/cowutters .
4. Step 3 from Quick Start

## Notes

1. The output file is proper Json.  What that means is that single quotes will be encoded as \u0027, because a solitary single quote is illegal json (the input files aren't legal), but the c# parser handles them.
2. There is no spoon.

## Author

[Jeffrey Longo] (LinkedIn Link)

[//]: # (These are reference links used in the body of this note and get stripped out when the markdown processor does its job. There is no need to format nicely because it shouldn't be seen. Thanks SO - http://stackoverflow.com/questions/4823468/store-comments-in-markdown-syntax)

[Jeffrey Longo]: <https://www.linkedin.com/in/jeffreylongo/>
[Docker Desktop]: <https://www.docker.com/products/docker-desktop/>
[docker hub]: <https://hub.docker.com/repository/docker/longofest/cowutters/general>

