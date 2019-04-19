using System;
using System.Text;


namespace doubleLinkedList
{
    class Program
    {
        static void Main()
        {//test area where we add and insert and delete items
            DoubleLinkedList List = new DoubleLinkedList();
            List.Insert("bannana");
            List.Insert("Apple");
            List.Insert("pear");

            DoubleLink link4 = List.Insert("Pineapple");
            List.Insert("16oranges");
            Console.WriteLine("List:" + List);

            List.InsertAfter(link4, "kiwi");
            Console.WriteLine("List:" + List);

            List.Delete();
            Console.WriteLine("List:" + List);
            Console.Read();
        }

        public class DoubleLink
        {// is the double link class that gets and sets the nodes 
            public String Names { get; set; }
            public DoubleLink PreviousLink { get; set; }
            public DoubleLink NextLink { get; set; }

            public DoubleLink(String name)
            {
                Names = name;

            }

            public override string ToString()
            {//calls ToString to make item into readable string
                return Names;

            }
        }


        public class DoubleLinkedList
        {
            private DoubleLink theFirst;

            public bool IsEmpty
            {//checks to see if the first node is empty or not
                get
                {//if it is return null
                    return theFirst == null;
                }

            }
            public DoubleLinkedList()
            {
                theFirst = null;
            }

            public DoubleLink Insert(string Names)
            {
                //creates a link, sets its link to the first item and then makes this the first item in the list
                DoubleLink link = new DoubleLink(Names);
                link.NextLink = theFirst;
                if (theFirst != null)//inserts the data into the new node and resets the neighbors
                    theFirst.PreviousLink = link;
                theFirst = link;
                return link;

            }

            public DoubleLink Delete()
            {
                //gets the first item, and sets it to be the one it is linked to
                DoubleLink temp = theFirst;
                if(theFirst !=null)
                {
                    //deletes the node and resets the other nodes next to it
                    theFirst = theFirst.NextLink;
                    if (theFirst != null)
                        theFirst.PreviousLink = null;
                }
                return temp;

            }

            public override string ToString()
            {
                //converts the items that are inserted to strings so that they may be readable
                DoubleLink currentLink = theFirst;
                StringBuilder builder = new StringBuilder();
                while(currentLink!=null)
                {
                    builder.Append(currentLink);
                    currentLink = currentLink.NextLink;
                }

                return builder.ToString();
            }

            public void InsertAfter(DoubleLink link, string Names)
            {
                if (link == null || string.IsNullOrEmpty(Names))
                    return;
                DoubleLink newLink = new DoubleLink(Names);
                newLink.PreviousLink = link;
                //update the after link's next reference, so it's previous points to the new one
                if (link.NextLink != null)
                    link.NextLink.PreviousLink = newLink;
                //steal the next link of the node, and set the after so it links to the new one
                newLink.NextLink = link.NextLink;
                link.NextLink = newLink;

            }

        }
    }
}
