using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_final
{
    public class Fire(int delay = 200)
    {      
        private readonly string[] _frames = new[]
            {
            @"
                       (       )
           )      (         )           (
               .    .  '  .    '
        ( ,   )   (   , )  ',   )   
         .' )   (  , (    )    ( .
      ). , (   (  ) , ') .'  ( ,    )
     (_,) .   ) _)_,')   (, ')  ,  (' )
      Press u to look up from the fire",
            @"
                       (  . )
           )         (      )           )
                ' .   '  .    '   . '
       (  , )     (  .  )   ',   )  (
         .' ) (     )  , (  ,     (  )
      ) , (   (  )   ,') .'   (  ,    )
     (_,) ) ) _) _ ,'   ( , ')  )  , (' )
      Press u to look up from the fire",
            @"
                       (    )
           )           (   )           (
               .  '  .   .    '   .  '
        (  , )    (   .  )   ',   (  )
         .' ) (   ( , (  , )    (  .
      ). , (   (  ) ,  ') .'  ( ,    )
     (_,) )  ) _) _,'   (, ')  ) , (' )
      Press u to look up from the fire",
            @"
                       (    .  )
           )        (      )         )
               ' .    '  .    '   . '
        (  , )    (   )  ,   ',   (
         .' ) (  .  ( , )   (   )
      ) , (   (   ,')   )  (  ,    )
     (_,) ) ) _) _ ,'   ( , ')  )  ,  (' )
      Press u to look up from the fire"
        };
        private bool _isRunning;
        private int _delay = delay;

        public void Start()
        {
            _isRunning = true;
            Console.OutputEncoding = Encoding.UTF8;
            Console.CursorVisible = false;

            int frameIndex = 0;

            while (_isRunning)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red; // Main flame color
                Console.WriteLine(_frames[frameIndex]);

                frameIndex = (frameIndex + 1) % _frames.Length; // Alternate frames
                Thread.Sleep(_delay);
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

