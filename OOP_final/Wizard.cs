using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_final
{
    public class Wizard
    {
        int _delay = 200;
        string pName;
        //public Wizard(string name) { pName = name; }
        private List<string> _frames = new List<string>();

        public Wizard(string name)
        {
            pName = name;
            InitializeFrames();
        }

        private void InitializeFrames()
        {
            _frames.Add($@"
                  .

                   .
         /^\     .
    /\   ""V""
   /__\   I      O  o
  //..\\  I     .
  \].`[/  I
  /l\/j\  (]    .  O
 /. ~~ ,\/I          .
 \\L__j^\/I       o
  \/--v|  I     o   .
  |    |  I   _________
  |    |  I c(`       ')o
  |    l  I   \.     ,/
_/j  L l\_!  _//^---^\\_

Welcome {pName}

Press U to speak with the Wizard");

            _frames.Add($@"
                  
                   .
                 .  
         /^\     
    /\   ""V""   O  o
   /__\   I     .   
  //..\\  I     
  \].`[/  I     .  O
  /l\/j\  (]         .
 /. ~~ ,\/I       o   
 \\L__j^\/I     o   .
  \/--v|  I       .  
  |    |  I   _________
  |    |  I c(`       ')o
  |    l  I   \.     ,/
_/j  L l\_!  _//^---^\\_

Welcome {pName}

Press U to speak with the Wizard");

            _frames.Add($@"
                   .
                 .  
                   
         /^\     O  o
    /\   ""V""  .  
   /__\   I        
  //..\\  I     .  O
  \].`[/  I          .
  /l\/j\  (]      o  
 /. ~~ ,\/I     o   .     
 \\L__j^\/I       .
  \/--v|  I         
  |    |  I   _________
  |    |  I c(`       ')o
  |    l  I   \.     ,/
_/j  L l\_!  _//^---^\\_

Welcome {pName}

Press U to speak with the Wizard");

            _frames.Add($@"
                 .  
                   
                 O  o
         /^\    .
    /\   ""V""    
   /__\   I     .  O   
  //..\\  I          .
  \].`[/  I       o   
  /l\/j\  (]    o   .  
 /. ~~ ,\/I       .      
 \\L__j^\/I       
  \/--v|  I        .
  |    |  I   _________
  |    |  I c(`       ')o
  |    l  I   \.     ,/
_/j  L l\_!  _//^---^\\_

Welcome {pName}

Press U to speak with the Wizard");

            _frames.Add($@"
                   
                 O  o
                .
         /^\    
    /\   ""V""  .  O  
   /__\   I          .    
  //..\\  I       o   
  \].`[/  I     o   .  
  /l\/j\  (]      .  
 /. ~~ ,\/I             
 \\L__j^\/I        .
  \/--v|  I      . 
  |    |  I   _________
  |    |  I c(`       ')o
  |    l  I   \.     ,/
_/j  L l\_!  _//^---^\\_

Welcome {pName}

Press U to speak with the Wizard");
        }
        bool _isRunning;
        public void Start()
        {
            _isRunning = true;
            Console.OutputEncoding = Encoding.UTF8;
            Console.CursorVisible = false;

            int frameIndex = 0;

            while (_isRunning)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Blue; // Main flame color
                Console.WriteLine(_frames[frameIndex]); // Output the current frame

                frameIndex = (frameIndex + 1) % _frames.Count; // Adjusted for List<string>
                Thread.Sleep(_delay); // Delay for the animation
            }

            Console.ResetColor();
            Console.Clear();
        }

        public void Stop()
        {
            _isRunning = false;
        }
    }
}
