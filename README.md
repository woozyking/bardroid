# Bardroid

Cross-firing an Arduino with web technologies, a bold take on defining the future of beverage serving experience. Directed and designed the project, implemented the user interface with jQuery Mobile. Featured on CTV morning live show, and made presence to a number of media.

# History

This project began as the final project of 4 friends' and mine back in 2010~2011 school year at McMaster University. We ran through a lot of ideas and none of them could reach our standard of coolness, until one of them raised this project idea... Since I really miss this project, I decided to continue on it as my side/hobby project seeing people I know have done much more impressive things. So here it is, I really hope that I can do it.

# Links

Here are some links that are relevant:

* [Original Google Code repo](http://code.google.com/p/mac-oi6-bardroid/)
* [An Youtube Channel with a bunch of footages and fun times (for me at least)](http://www.youtube.com/user/MacBarDroid)
* ["Official Site"](http://bardroid.ca) (we did actually go to CTV, but unfortunately we don't have that footage now)

# Some More History (technical wise)

The project started as just an Arduino + Touch screen solution. However, seeing how ridiculously expensive those touch screens were, I came up with this bold idea - why not somehow combine the web to this project? So after a few discussions, we somehow came up with this solution, basically with 3 major components:

* The Arduino interfacing with any hardware we needed. At the end it was connected to a breathalyzer, 3 (fish tank) pumps. It also was supposed to interface with the magnetic strip reader, but we cheated a bit on that, see below.
* An Nook Color tablet served as the main user interface. It was used to load the web UI we created based on jQuery-Mobile (at that time it was just released at alpha quality, but we were lucky to actually use it).
* (Biggest cheating unit) A laptop served as the *middleware* between the Arduino board and the tablet. It was used to enable a localhost that serves the web UI, the lower level logics to interact with the Arduino (thanks to C# it was reasonably easy). And also, we hooked up the magnetic strip reader with this beast instead of intended Arduino, biggest cheat move (shame on us, especially me).

# Current Goal

So given the technical history as aforementioned, there are a few immediate tasks that I'd like to accomplish:

1. Properly redesign the whole architecture of the project, largely based on our original intention. So all hardware should be interfaced with Arduino only.
2. Get rid of the computer, and therefore all the code base ran on it. Instead, use Arduino as the REST server, as I feel it's the thinnest and most proper way of communicating with Aruidno over the net with a device that's capable of browsing the web - in short, exactly what I needed. I feel very lucky to find this project: [Webduino](https://github.com/sirleech/Webduino)
3. Build an even better web UI with the now stable version of jQuery Mobile.