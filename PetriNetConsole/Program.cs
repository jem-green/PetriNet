using System;
using System.Collections.Generic;
using System.Threading;
using PetriNetLibrary;


namespace PetriNetConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            //Linear();
            //Cycle();
            //Fork();
            Merge();

            ManualResetEvent manualResetEvent = new ManualResetEvent(false);

            manualResetEvent.WaitOne();

        }

        static void Linear()
        {
            Token marking = new Token(true);
            Place place1 = new Place("Place1", new List<Token> { marking });
            Transition transition = new Transition("Transition1");
            Place place2 = new Place("Place2");
            Arc arc1 = new Arc("Arc1");
            Arc arc2 = new Arc("Arc2");
            Node n1 = new Node(arc1);
            Node n2 = new Node(arc1);
            Node n3 = new Node(arc2);
            Node n4 = new Node(arc2);
            place1.AddThrow(n1);
            transition.AddCatch(n2);
            transition.AddThrow(n3);
            place2.AddCatch(n4);

            // This should cause a token to be generated in place2

            Thread placeThread = new Thread(new ThreadStart(place1.Start));
            placeThread.Start();
            Thread transitionThread = new Thread(new ThreadStart(transition.Start));
            transitionThread.Start();
            placeThread = new Thread(new ThreadStart(place2.Start));
            placeThread.Start();
        }

        static void Cycle()
        {
            Token marking = new Token(true);
            Place place1 = new Place("Place1", new List<Token> { marking });
            Transition transition1 = new Transition("Transition1");
            Place place2 = new Place("Place2");
            Transition transition2 = new Transition("Transition2");
            Place place3 = new Place("Place3");
            Transition transition3 = new Transition("Transition3");

            Arc arc1 = new Arc("Arc1");
            Arc arc2 = new Arc("Arc2");
            Arc arc3 = new Arc("Arc3");
            Arc arc4 = new Arc("Arc4");
            Arc arc5 = new Arc("Arc5");
            Arc arc6 = new Arc("Arc6");

            Node n1 = new Node(arc1);
            Node n2 = new Node(arc1);
            Node n3 = new Node(arc2);
            Node n4 = new Node(arc2);
            Node n5 = new Node(arc3);
            Node n6 = new Node(arc3);
            Node n7 = new Node(arc4);
            Node n8 = new Node(arc4);
            Node n9 = new Node(arc5);
            Node n10 = new Node(arc5);
            Node n11= new Node(arc6);
            Node n12 = new Node(arc6);

            place1.AddCatch(n12);
            place1.AddThrow(n1);
            transition1.AddCatch(n2);
            transition1.AddThrow(n3);
            place2.AddCatch(n4);
            place2.AddThrow(n5);
            transition2.AddCatch(n6);
            transition2.AddThrow(n7);
            place3.AddCatch(n8);
            place3.AddThrow(n9);
            transition3.AddCatch(n10);
            transition3.AddThrow(n11);

            // This should cause a token to be generated in place1, place2, place3, etc

            Thread placeThread = new Thread(new ThreadStart(place1.Start));
            placeThread.Start();
            Thread transitionThread = new Thread(new ThreadStart(transition1.Start));
            transitionThread.Start();
            placeThread = new Thread(new ThreadStart(place2.Start));
            placeThread.Start();
            transitionThread = new Thread(new ThreadStart(transition2.Start));
            transitionThread.Start();
            placeThread = new Thread(new ThreadStart(place3.Start));
            placeThread.Start();
            transitionThread = new Thread(new ThreadStart(transition3.Start));
            transitionThread.Start();

        }

        static void Fork()
        {
            Token marking = new Token(true);
            Place place1 = new Place("Place1", new List<Token> { marking });
            Transition transition1 = new Transition("Transition1");
            Place place2 = new Place("Place2");
            Place place3 = new Place("Place3");

            Arc arc1 = new Arc("Arc1");
            Arc arc2 = new Arc("Arc2");
            Arc arc3 = new Arc("Arc3");

            Node n1 = new Node(arc1);
            Node n2 = new Node(arc1);

            Node n3 = new Node(arc2);
            Node n4 = new Node(arc2);

            Node n5 = new Node(arc3);
            Node n6 = new Node(arc3);

            place1.AddThrow(n1);
            transition1.AddCatch(n2);
            transition1.AddThrow(n3);
            transition1.AddThrow(n5);
            place2.AddCatch(n4);
            place3.AddCatch(n6);

            // This should cause a token to be generated in place2 and place3

            Thread placeThread = new Thread(new ThreadStart(place1.Start));
            placeThread.Start();
            Thread transitionThread = new Thread(new ThreadStart(transition1.Start));
            transitionThread.Start();
            placeThread = new Thread(new ThreadStart(place2.Start));
            placeThread.Start();
            placeThread = new Thread(new ThreadStart(place3.Start));
            placeThread.Start();
        }

        static void Merge()
        {
            Token marking = new Token(true);
            Place place1 = new Place("Place1", new List<Token> { marking });
            Place place2 = new Place("Place2", new List<Token> { marking });
            Transition transition1 = new Transition("Transition1");
            Place place3 = new Place("Place3");

            Arc arc1 = new Arc("Arc1");
            Arc arc2 = new Arc("Arc2");
            Arc arc3 = new Arc("Arc3");

            Node n1 = new Node(arc1);
            Node n2 = new Node(arc1);

            Node n3 = new Node(arc2);
            Node n4 = new Node(arc2);

            Node n5 = new Node(arc3);
            Node n6 = new Node(arc3);

            place1.AddThrow(n1);
            place2.AddThrow(n3);
            transition1.AddCatch(n2);
            transition1.AddCatch(n4);
            transition1.AddThrow(n5);
            place3.AddCatch(n6);

            // This should cause a token to be generated in place3

            Thread placeThread = new Thread(new ThreadStart(place1.Start));
            placeThread.Start();
            placeThread = new Thread(new ThreadStart(place2.Start));
            placeThread.Start();
            Thread transitionThread = new Thread(new ThreadStart(transition1.Start));
            transitionThread.Start();
            placeThread = new Thread(new ThreadStart(place3.Start));
            placeThread.Start();
        }
    }
}
